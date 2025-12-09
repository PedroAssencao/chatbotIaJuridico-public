using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("options")]
public partial class Option
{
    [Key]
    [Column("opt_id")]
    public int OptId { get; set; }
    [NotMapped]
    public string? OptIdForMenus { get; set; }

    [Column("opt_data", TypeName = "datetime")]
    public DateTime? OptData { get; set; }

    [Column("opt_descricao")]
    [StringLength(500)]
    public string? OptDescricao { get; set; }

    [Column("opt_finalizar")]
    public bool? OptFinalizar { get; set; }

    [Column("opt_resposta")]
    [StringLength(500)]
    public string? OptResposta { get; set; }

    [Column("opt_tipo")]
    public ETipoOption OptTipo { get; set; }

    [Column("opt_title")]
    [StringLength(24)]
    public string? OptTitle { get; set; }

    [Column("men_id")]
    public int MenId { get; set; }

    [ForeignKey("MenId")]
    [InverseProperty("Options")]
    public virtual Menu Men { get; set; } = null!;

    public string maskDescricao()
    {
        if (OptDescricao.Length >= 69)
        {
            return OptDescricao.Substring(0, 69) + "...";
        }
        return OptDescricao;
    }
}
