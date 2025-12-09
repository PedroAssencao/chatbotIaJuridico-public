using ChatbotIaJuridico.Domain.Models.JsonOpenAiModels;
using ChatbotIaJuridico.Infra.Storage.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;
using iTextSharp.text;


namespace ChatbotIaJuridico.Infra.Storage.Repository
{
    public class FileManager : IFileManager
    {
        public async Task<string> saveFileLocal(string fileName, byte[] fileContent, string fileExtensions)
        {
            try
            {
                var folderPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "arquivos");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var dateTimeSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmssSSS");
                var newFileName = $"{System.IO.Path.GetFileName(fileName)}_{dateTimeSuffix}.{fileExtensions}";

                var filePath = System.IO.Path.Combine(folderPath, newFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await fileStream.WriteAsync(fileContent, 0, fileContent.Length);
                }

                return $"arquivos/{newFileName}";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<byte[]> GetFileLocal(string filePath)
        {
            try
            {
                var absolutePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), filePath);

                if (!File.Exists(absolutePath))
                {
                    throw new FileNotFoundException("arquivo não encontrado", absolutePath);
                }

                return await File.ReadAllBytesAsync(absolutePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> GeneratePeticao(GeneratePeticaoRecaive.Root Model)
        {
            try
            {
                var list = new List<string>();

                list.Add(GerarDocx(Model));
                list.Add(await GerarPdf(Model));

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<PdfWriter> PdfWriter_GetInstanceAsync(iTextSharp.text.Document document, FileStream FS)
        {
            PdfWriter writer = null;

            for (int Times = 0; Times < 20; Times++)
            {
                try
                {
                    writer = PdfWriter.GetInstance(document, FS); // Tenta criar o PdfWriter
                    break; // Se criado com sucesso, sai do loop
                }
                catch
                {
                    await Task.Delay(250); // Aguarda 250ms de forma assíncrona
                }
            }

            if (writer == null) // Verifica se o PdfWriter foi instanciado
            {
                throw new Exception("iTextSharp PdfWriter is null");
            }

            return writer;
        }

        private async Task<string> GerarPdf(GeneratePeticaoRecaive.Root Model)
        {
            var folderPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "arquivos");

            // Verifica e cria o diretório, se necessário
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var dateTimeSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmssSSS");
            var newFileName = $"Peticao_{dateTimeSuffix}.pdf";
            var filePath = System.IO.Path.Combine(folderPath, newFileName);

            try
            {
                using (FileStream arquivoPdf = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);

                    PdfWriter writer = await PdfWriter_GetInstanceAsync(document, arquivoPdf);

                    // Abre o documento com o método correto
                    document.Open();

                    // Definindo fontes
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font sectionFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font italicFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.ITALIC);

                    // Adicionando conteúdo ao PDF
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("PETIÇÃO INICIAL", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    document.Add(new iTextSharp.text.Paragraph("\n", normalFont));

                    document.Add(new iTextSharp.text.Paragraph($"REQUERENTE: {Model.Parte.Nome}", normalFont));
                    document.Add(new iTextSharp.text.Paragraph($"CPF: {Model.Parte.CPF}", normalFont));
                    document.Add(new iTextSharp.text.Paragraph($"Endereço: {Model.Parte.Endereco}", normalFont));
                    document.Add(new iTextSharp.text.Paragraph("\n", normalFont));

                    document.Add(new iTextSharp.text.Paragraph($"REQUERIDO: {Model.Reu.Nome}", normalFont));
                    document.Add(new iTextSharp.text.Paragraph($"CPF/CNPJ: {Model.Reu.CPFCNPJ}", normalFont));
                    document.Add(new iTextSharp.text.Paragraph($"Endereço: {Model.Reu.Endereco}", normalFont));
                    document.Add(new iTextSharp.text.Paragraph("\n", normalFont));

                    iTextSharp.text.Paragraph fatosTitle = new iTextSharp.text.Paragraph("1. DOS FATOS", sectionFont);
                    document.Add(fatosTitle);
                    foreach (var fato in Model.Fatos)
                    {
                        document.Add(new iTextSharp.text.Paragraph("- " + fato, normalFont));
                    }
                    document.Add(new iTextSharp.text.Paragraph("\n", normalFont));

                    iTextSharp.text.Paragraph direitoTitle = new iTextSharp.text.Paragraph("2. DO DIREITO", sectionFont);
                    document.Add(direitoTitle);
                    foreach (var fundamento in Model.DoDireito)
                    {
                        document.Add(new iTextSharp.text.Paragraph("- " + fundamento, normalFont));
                    }
                    document.Add(new iTextSharp.text.Paragraph("\n", normalFont));

                    iTextSharp.text.Paragraph pedidosTitle = new iTextSharp.text.Paragraph("3. DOS PEDIDOS", sectionFont);
                    document.Add(pedidosTitle);
                    foreach (var pedido in Model.Pedidos)
                    {
                        document.Add(new iTextSharp.text.Paragraph("- " + pedido, normalFont));
                    }

                    iTextSharp.text.Paragraph jurisPrudenciaTitle = new iTextSharp.text.Paragraph("4. Jurisprudência".ToUpper(), sectionFont);
                    document.Add(jurisPrudenciaTitle);
                    foreach (var jurisPrudencia in Model.JurisPrudencia)
                    {
                        var paragraph = new iTextSharp.text.Paragraph("- " + jurisPrudencia, italicFont);
                        paragraph.IndentationLeft = 20;
                        document.Add(paragraph);
                    }
                    document.Add(new iTextSharp.text.Paragraph("\n", normalFont));

                    // Fecha o documento com o método correto
                    document.Close();
                }

                return $"arquivos/{newFileName}";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string GerarDocx(GeneratePeticaoRecaive.Root Model)
        {
            var folderPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "arquivos");

            var dateTimeSuffix = DateTime.Now.ToString("yyyyMMdd_HHmmssSSS");
            var newFileName = $"Peticao_{dateTimeSuffix}.docx";
            var filePath = System.IO.Path.Combine(folderPath, newFileName);

            using (WordprocessingDocument doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                Body body = new Body();

                // Título
                body.Append(CreateParagraph("PETIÇÃO INICIAL", JustificationValues.Center, true, 18));
                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                // Parte - Requerente
                body.Append(CreateParagraph($"REQUERENTE: {Model.Parte.Nome}",null));
                body.Append(CreateParagraph($"CPF: {Model.Parte.CPF}", null));
                body.Append(CreateParagraph($"Endereço: {Model.Parte.Endereco}", null));
                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                // Parte - Requerido
                body.Append(CreateParagraph($"REQUERIDO: {Model.Reu.Nome}", null));
                body.Append(CreateParagraph($"CPF/CNPJ: {Model.Reu.CPFCNPJ}", null));
                body.Append(CreateParagraph($"Endereço: {Model.Reu.Endereco}", null));
                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                // Exposição dos fatos
                body.Append(CreateParagraph("1. DOS FATOS",null, true, 14));
                foreach (var fato in Model.Fatos)
                {
                    body.Append(CreateParagraph($"- {fato}", null));
                }
                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                // Fundamentação jurídica
                body.Append(CreateParagraph("2. DO DIREITO",null, true, 14));
                foreach (var fundamento in Model.DoDireito)
                {
                    body.Append(CreateParagraph($"- {fundamento}", null));
                }
                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                // Título da seção
                body.Append(CreateParagraph("4. JURISPRUDÊNCIA", null, true, 14));

                foreach (var jurisPrudencia in Model.JurisPrudencia)
                {
                    body.Append(CreateParagraph($"- {jurisPrudencia}", JustificationValues.Right, false, 12, true));
                }

                body.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }

            return $"arquivos/{newFileName}";
        }
        private DocumentFormat.OpenXml.Wordprocessing.Paragraph CreateParagraph(string text, JustificationValues? alignment, bool isBold = false, int fontSize = 12, bool isItalic = false)
        {
            if (alignment == null)
            {
                alignment = JustificationValues.Left;
            }   

            // Criando um novo parágrafo
            DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();

            // Definindo a formatação do parágrafo
            DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run();
            DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();

            // Se o texto for negrito
            if (isBold)
            {
                runProperties.Bold = new Bold();
            }

            // Aplicando itálico, se necessário
            if (isItalic)
            {
                runProperties.Append(new Italic());
            }

            // Definindo o tamanho da fonte
            runProperties.FontSize = new FontSize() { Val = (fontSize * 2).ToString() }; // Fonte é definida em pontos, e o valor é multiplicado por 2 para se ajustar ao OpenXml

            run.Append(runProperties);
            run.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(text));

            // Adicionando o conteúdo ao parágrafo
            paragraph.Append(run);

            // Definindo o alinhamento do parágrafo
            paragraph.ParagraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties()
            {
                Justification = new Justification() { Val = alignment }
            };

            return paragraph;
        }

    }
}
