using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("preInsumo")]
public partial class PreInsumo
{
    [Key]
    [Column("pIns_id")]
    public int pInsId { get; set; }

    [Column("pIns_data", TypeName = "datetime")]
    public DateTime? pInsData { get; set; }

    [Column("pIns_caminho")]
    public string? pInsCaminho { get; set; }

    [Column("pIns_descricao")]
    public string? pInsDescricao { get; set; }

    [Column("pIns_Waid")]
    public string? pInsWaid { get; set; }

    [Column("pIns_dataModificacao", TypeName = "datetime")]
    public DateTime? pInsDataModificacao { get; set; }

    [Column("pIns_tipo")]
    public ETipoPreInsumo pInsTipo { get; set; }

    [Column("adv_id")]
    public int AdvId { get; set; }

    [Column("cha_id")]
    public int ChaId { get; set; }

    [ForeignKey("AdvId")]
    [InverseProperty("PreInsumos")]
    public virtual Advogado Adv { get; set; } = null!;

    [ForeignKey("ChaId")]
    [InverseProperty("PreInsumos")]
    public virtual Chat Cha { get; set; } = null!;

    public static ETipoPreInsumo MapearTipoPreInsumo(ETipoRecebimentoMensagem tipo)
    {
        return tipo switch
        {
            ETipoRecebimentoMensagem.cpf => ETipoPreInsumo.cpf,
            ETipoRecebimentoMensagem.nomeCliente => ETipoPreInsumo.nomeCliente,
            ETipoRecebimentoMensagem.nomePreProcesso => ETipoPreInsumo.nomePreProcesso,
            ETipoRecebimentoMensagem.DescricaoPreProcesso => ETipoPreInsumo.descricaoPreProcesso,
            ETipoRecebimentoMensagem.audio => ETipoPreInsumo.audio,
            ETipoRecebimentoMensagem.imagem => ETipoPreInsumo.imagem,
            ETipoRecebimentoMensagem.video => ETipoPreInsumo.video,
            ETipoRecebimentoMensagem.documento => ETipoPreInsumo.documento,
            _ => ETipoPreInsumo.texto
        };
    }
}
