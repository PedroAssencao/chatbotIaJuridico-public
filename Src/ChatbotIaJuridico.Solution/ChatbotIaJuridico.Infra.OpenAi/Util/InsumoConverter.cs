using System.Text;
using DocumentFormat.OpenXml.Packaging;
using ChatbotIaJuridico.Domain.Models.Enum;
using ChatbotIaJuridico.Infra.OpenAi.Interface;
using ChatbotIaJuridico.Services.Storage.Interface;
using Newtonsoft.Json;
using OpenAI.Audio;
using ChatbotIaJuridico.Services.Interfaces;

namespace ChatbotIaJuridico.Infra.OpenAi.Util
{
    public class InsumoConverter : IInsumoConverter
    {
        protected readonly IFileManagerServices _fileManagerServices;
        protected readonly IInsumoServices _insumoServices;
        protected string _apikey = "";

        public InsumoConverter(IFileManagerServices fileManagerServices, IInsumoServices insumo)
        {
            _fileManagerServices = fileManagerServices;
            _insumoServices = insumo;
        }

        public async Task<List<Insumo>> getInsumosText(List<Insumo> insumos, string apikey)
        {
            _apikey = apikey;

            foreach (var insumo in insumos.Where(x => string.IsNullOrEmpty(x.InsTranscricao)).ToList())
            {
                if (insumo.InsTipo == ETipoInsumo.documento)
                {
                    insumo.InsTranscricao = await ExtractTextFromBytes(await _fileManagerServices.GetFileLocal(insumo.InsCaminho), insumo.InsCaminho, insumo);
                }

                if (insumo.InsTipo == ETipoInsumo.audio || insumo.InsTipo == ETipoInsumo.video)
                {
                    insumo.InsTranscricao = await TranscreverAudioComOpenAI(await _fileManagerServices.GetFileLocal(insumo.InsCaminho));
                }
                
                if (insumo.InsTipo == ETipoInsumo.imagem)
                {
                    insumo.InsTranscricao = await ExtrairTextoDeImagemComOpenAI(await _fileManagerServices.GetFileLocal(insumo.InsCaminho));
                }
                
                if (insumo.InsTipo == ETipoInsumo.texto)
                {
                    insumo.InsTranscricao = insumo.InsDescricao;
                }

                await _insumoServices.updateAsync(insumo);
            }

            return insumos;
        }

        private async Task<string> ExtractTextFromBytes(byte[] fileBytes, string fileName, Insumo insumo)
        {
            string extension = Path.GetExtension(fileName).ToLowerInvariant();

            if (extension.Contains("ogg") || extension.Contains("mp4") || extension.Contains("mpeg") || extension.Contains("mp3"))
            {
                return await TranscreverAudioComOpenAI(await _fileManagerServices.GetFileLocal(insumo.InsCaminho));
            }            

            try
            {
                return extension switch
                {
                    ".pdf" => ExtractTextFromPdf(fileBytes),
                    ".docx" => ExtractTextFromDocx(fileBytes),
                    ".txt" => ExtractTextFromTxt(fileBytes),
                    _ => $"Extensão '{extension}' não suportada."
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string ExtractTextFromPdf(byte[] fileBytes)
        {
            using var stream = new MemoryStream(fileBytes);
            using var document = UglyToad.PdfPig.PdfDocument.Open(stream);
            var textBuilder = new StringBuilder();
            foreach (var page in document.GetPages())
            {
                textBuilder.AppendLine(page.Text);
            }
            return textBuilder.ToString();
        }

        private static string ExtractTextFromDocx(byte[] fileBytes)
        {
            using var stream = new MemoryStream(fileBytes);
            using var wordDoc = WordprocessingDocument.Open(stream, false);
            return wordDoc.MainDocumentPart.Document.Body.InnerText;
        }

        private static string ExtractTextFromTxt(byte[] fileBytes)
        {
            return Encoding.UTF8.GetString(fileBytes);
        }

        private async Task<string> TranscreverAudioComOpenAI(byte[] audioBytes)
        {
            AudioClient client = new AudioClient("whisper-1", _apikey);

            AudioTranscriptionOptions options = new AudioTranscriptionOptions()
            {
                ResponseFormat = AudioTranscriptionFormat.Verbose,
                TimestampGranularities = AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment,
            };

            string transcriptionString = string.Empty;

            using (MemoryStream stream = new MemoryStream(audioBytes))
            {
                AudioTranscription transcription = await client.TranscribeAudioAsync(stream, "audio.mp3", options);
                transcriptionString += $"{transcription.Text} ";
            }
            return transcriptionString;
        }

        private async Task<string> ExtrairTextoDeImagemComOpenAI(byte[] imageBytes)
        {
            var base64Image = Convert.ToBase64String(imageBytes);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apikey}");

                var requestBody = new
                {
                    model = "gpt-4o-mini",
                    messages = new[]
                    {
                        new
                        {
                            role = "user",
                            content = new object[]
                            {
                                new { type = "text", text = "Transcreva o texto nesta imagem. Se não houver texto, retorne 'No text in this image'." },
                                new { type = "image_url", image_url = new { url = $"data:image/jpeg;base64,{base64Image}" } }
                            }
                        }
                    }
                };

                var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);
                    return responseObject.choices[0].message.content;
                }
                else
                {
                    throw new Exception($"Erro na requisição: {response.StatusCode} - {responseString}");
                }
            }
        }
    }
}
