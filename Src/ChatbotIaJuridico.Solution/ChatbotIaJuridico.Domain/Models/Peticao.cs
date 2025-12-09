using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("peticao")]
public partial class Peticao
{
    [Key]
    [Column("pet_id")]
    public int PetId { get; set; }

    [Column("pProc_caminho")]
    [StringLength(500)]
    public string PProcCaminho { get; set; } = null!;

    [Column("pProc_descricao")]
    [StringLength(255)]
    public string? PProcDescricao { get; set; }

    [Column("pProc_dataCriacao", TypeName = "datetime")]
    public DateTime? PProcDataCriacao { get; set; }

    [Column("pet_tipo")]
    public EPeticaoTipo PetTipo { get; set; }

    [Column("adv_id")]
    public int AdvId { get; set; }

    [ForeignKey("AdvId")]
    [InverseProperty("Peticaos")]
    public virtual Advogado Adv { get; set; } = null!;
}
