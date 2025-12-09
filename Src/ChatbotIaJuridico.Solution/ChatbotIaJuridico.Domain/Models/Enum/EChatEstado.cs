namespace ChatbotIaJuridico.Domain.Models.Enum
{
    public enum EChatEstado
    {
        Envio = 1,
        AguardandoCpf = 2,
        GerandoPeticao = 3,
        AguardandoPreProcesso = 4,
        AguardandoNomeCliente = 5,
        AguardandoNomePreProcesso = 6,
        AguardandoNomePreProcessoForce = 12,
        AguardandoDescricaoPreProcesso = 7,
        AguardandoDescricaoPreProcessoForce = 13,
        AguardandoSelecionarClienteParaRedirecionarParaPreProcesso = 8,
        AguardandoSelecionarPreProcessoParaRedirecionarParaEnvio = 9,
        AguardandoCpfOuNomeClienteModoBusca = 10,
        AguardandoCodigoOuNomePreProcessoModoBusca = 11,
        AguardandoSelecionarOpcaoDoMenuDeComando = 12,
        AguardandoSelecionarClienteParaGerarPeticao = 14,
        AguardandoSelecionarPreProcessoParaGerarPeticao = 15,
        AguardandoGeracaoPeticao = 16,
        AguardandoTerminoGeracaoPeticao = 17,
        AguardandoSelecionarOpcaoAposMenuDeInteraçãoIA = 18,
    }
}
