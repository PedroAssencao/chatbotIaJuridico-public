using ChatbotIaJuridico.Infra.Common.Interfaces;
using ChatbotIaJuridico.Infra.OpenAi.Interface;
using Newtonsoft.Json;
using System.Text;

namespace ChatbotIaJuridico.Infra.OpenAi.Clients
{
    public class OpenAiRequest : IOpenAiRequest
    {
        protected readonly IInsumoConverter _InsumoConverter;
        private readonly IHttpClientConfiguration _configurationClient;
        public OpenAiRequest(IInsumoConverter insumoConverter, IHttpClientConfiguration configuration)
        {
            _InsumoConverter = insumoConverter;
            _configurationClient = configuration;
        }

        public async Task<string> sendRequestToGeneratePeticao(List<Insumo> Insumos, string url, string Authorization, string prompt)
        {
            try
            {
                await _InsumoConverter.getInsumosText(Insumos, Authorization);

                _configurationClient.InstanceClient("OpenAI-API");

                _configurationClient.AddHeaders(new Dictionary<string, string>
                {
                    {nameof(Authorization), $"Bearer {Authorization}"}
                });

                var Comando = "";

                foreach (var item in Insumos)
                {
                    Comando += $"nome arquivo: {item.InsDescricao}, tipo arquivo: {item.InsTipo}, Transcrição arquivo: {item.InsTranscricao}, ";
                }

                if (Comando.Length > 100000)
                {
                    Comando = Comando.Substring(0, 100000);
                }

                var requestBody = new
                {
                    model = "gpt-4o",
                    messages = new[]
                    {
                        new { role = "system", content = prompt },
                        new { role = "user", content = Comando }
                    },
                    max_tokens = 3000                    
                };


                var httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await _configurationClient.PostAsync($"{url}", httpContent);

                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
                string content = jsonResponse.choices[0].message.content.ToString();

                return content.Replace("{{","{").Replace("}}","}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> sendRequestToGenerateText(List<Insumo> Insumos, string url, string Authorization, string prompt)
        {
            try
            {
                _configurationClient.InstanceClient("OpenAI-API");

                _configurationClient.AddHeaders(new Dictionary<string, string>
                {
                    {nameof(Authorization), $"Bearer {Authorization}"}
                });

                var Comando = "";

                foreach (var item in Insumos)
                {
                    Comando += $"nome arquivo: {item.InsDescricao}, tipo arquivo: {item.InsTipo}, Transcrição arquivo: {item.InsTranscricao}, ";
                }

                if (Comando.Length > 100000)
                {
                    Comando = Comando.Substring(0, 100000);
                }

                var requestBody = new
                {
                    model = "gpt-4o-mini-search-preview",
                    messages = new[]
                    {
                        new { role = "system", content = prompt },
                        new { role = "user", content = Comando }
                    },
                    max_tokens = 1000
                };


                var httpContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
                var response = await _configurationClient.PostAsync($"{url}", httpContent);

                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
                string content = jsonResponse.choices[0].message.content.ToString();

                return content.Replace("{{", "{").Replace("}}", "}");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
