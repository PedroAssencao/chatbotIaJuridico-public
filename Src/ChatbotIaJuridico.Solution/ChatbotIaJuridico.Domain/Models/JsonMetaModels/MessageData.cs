using System.Text.Json;

namespace ChatbotIaJuridico.Domain.Models.JsonMetaModels
{
    public class MessageData
    {
        public string? WaId { get; set; }
        public string? MensagemWaId { get; set; }
        public JsonDocument? RawRequest { get; set; }
    }
}
