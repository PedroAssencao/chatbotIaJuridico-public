using Newtonsoft.Json;

namespace ChatbotIaJuridico.Domain.Models.JsonOpenAiModels
{
    public class GeneratePeticaoRecaive
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Parte
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string Endereco { get; set; }
        }

        public class Reu
        {
            public string Nome { get; set; }

            [JsonProperty("CPF/CNPJ")]
            public string CPFCNPJ { get; set; }
            public string Endereco { get; set; }
        }

        public class Root
        {
            public string PeticaoTipo { get; set; }
            public Parte Parte { get; set; }
            public Reu Reu { get; set; }
            public List<string> Fatos { get; set; }
            public List<string> DoDireito { get; set; }
            public List<string> Pedidos { get; set; }
            public List<string> JurisPrudencia { get; set; }
        }
    }
}
