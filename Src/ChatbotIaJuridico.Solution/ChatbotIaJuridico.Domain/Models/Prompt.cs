using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotIaJuridico.Infra;

[Table("prompt")]
public partial class Prompt
{
    [Key]
    [Column("promp_id")]
    public int PrompId { get; set; }

    [Column("promp_descricao")]
    [StringLength(255)]
    public string PrompDescricao { get; set; } = null!;

    [Column("promp_ativa")]
    public bool? PrompAtiva { get; set; }

    [Column("promp_valor")]
    public string? PrompValor { get; set; }
}
