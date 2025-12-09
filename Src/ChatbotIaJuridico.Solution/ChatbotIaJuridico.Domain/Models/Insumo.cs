using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("insumo")]
public partial class Insumo
{
    [Key]
    [Column("ins_id")]
    public int InsId { get; set; }

    [Column("ins_data", TypeName = "datetime")]
    public DateTime? InsData { get; set; }

    [Column("ins_caminho")]
    public string? InsCaminho { get; set; }

    [Column("ins_descricao")]
    public string? InsDescricao { get; set; }
    [Column("ins_transcricao")]
    public string? InsTranscricao { get; set; }

    [Column("ins_Waid")]
    public string? InsWaid { get; set; }

    [Column("ins_tipo")]
    public ETipoInsumo InsTipo { get; set; }

    [Column("adv_id")]
    public int AdvId { get; set; }

    [Column("pProc_id")]
    public int PProcId { get; set; }

    [Column("cha_id")]
    public int ChaId { get; set; }

    [ForeignKey("AdvId")]
    [InverseProperty("Insumos")]
    public virtual Advogado Adv { get; set; } = null!;

    [ForeignKey("ChaId")]
    [InverseProperty("Insumos")]
    public virtual Chat Cha { get; set; } = null!;

    [ForeignKey("PProcId")]
    [InverseProperty("Insumos")]
    public virtual PreProcesso PProc { get; set; } = null!;

    public static ETipoInsumo MapearTipoInsumo(ETipoPreInsumo tipo)
    {
        return tipo switch
        {
            ETipoPreInsumo.audio => ETipoInsumo.audio,
            ETipoPreInsumo.imagem => ETipoInsumo.imagem,
            ETipoPreInsumo.texto => ETipoInsumo.texto,
            ETipoPreInsumo.documento => ETipoInsumo.documento,
            _ => ETipoInsumo.video
        };

    }
}
