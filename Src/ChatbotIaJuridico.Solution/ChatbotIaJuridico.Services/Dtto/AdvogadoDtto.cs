namespace ChatbotIaJuridico.Services.Dtto
{
    public class AdvogadoDtto
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? NumeroWhatsapp { get; set; }
        public class AdvogadoDttoGetForView : AdvogadoDtto
        {
            public int CodigoAdvogado { get; set; }
        }
    }
}
