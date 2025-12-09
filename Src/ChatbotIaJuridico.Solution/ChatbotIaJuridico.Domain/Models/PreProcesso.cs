using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("preProcesso")]
public partial class PreProcesso
{
    [Key]
    [Column("pProc_id")]
    public int PProcId { get; set; }

    [Column("pProc_nome")]
    [StringLength(255)]    
    public string PProcNome { get; set; } = null!;

    [Column("pProc_descricao")]
    [StringLength(255)]
    public string? PProcDescricao { get; set; }

    [Column("pProc_dataCriacao", TypeName = "datetime")]
    public DateTime? PProcDataCriacao { get; set; }
    [Column("pProc_dataModificacao", TypeName = "datetime")]
    public DateTime? PProcDataModificacao { get; set; }

    [Column("pProc_estado")]
    public EPreProcessoEstado? PProcEstado { get; set; }

    [Column("pProc_tipo")]
    public ETipoPreProcesso PProcTipo { get; set; }

    [Column("adv_id")]
    public int AdvId { get; set; }

    [Column("cli_id")]
    public int CliId { get; set; }

    [ForeignKey("AdvId")]
    [InverseProperty("PreProcessos")]
    public virtual Advogado Adv { get; set; } = null!;

    [ForeignKey("CliId")]
    [InverseProperty("PreProcessos")]
    public virtual Cliente Cli { get; set; } = null!;

    [InverseProperty("PProc")]
    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();
    public string? maskNome()
    {
        if (PProcNome?.Length >= 20)
        {
            return $"{PProcNome.Substring(0, 19)}.".ToString();
        }
        return PProcNome;
    }
}
