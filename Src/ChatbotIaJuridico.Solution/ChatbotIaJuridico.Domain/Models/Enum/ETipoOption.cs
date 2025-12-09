namespace ChatbotIaJuridico.Domain.Models.Enum
{
    public enum ETipoOption
    {
        optionDeResposta = 1,
        optionParaAguardoDeInput_cpf = 2,
        optionParaCriacao_cpf = 5,
        optionParaAguardoDeInput_preProcesso = 4,
        optionParaAguardoDeInputGerarPeticao_preProcesso = 8,
        optionParaCriacao_preProcesso = 3,
        optionParaEnchaminhamento_Preprocesso = 6,
        optionParaEnchaminhamento_Envio = 7,
        optionParaAguardoDeInputGerarPeticaoPosResumo_GerarPeticao_preProcesso = 9,
        optionParaAguardoDeInputGerarPeticaoPosResumo_InserirInsumo_preProcesso = 10,
        optionParaAguardoDeInputGerarPeticaoPosResumo_CancelarGeracao_preProcesso = 11,
    }
}
