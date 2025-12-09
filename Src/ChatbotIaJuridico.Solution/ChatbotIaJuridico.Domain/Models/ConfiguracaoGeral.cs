using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotIaJuridico.Infra;

[Table("configuracaoGeral")]
public partial class ConfiguracaoGeral
{
    [Key]
    [Column("confg_id")]
    public int ConfgId { get; set; }

    [Column("conf_descricao")]
    [StringLength(255)]
    public string ConfDescricao { get; set; } = null!;

    [Column("confg_ativa")]
    public bool? ConfgAtiva { get; set; }

    [Column("confg_valor")]
    [StringLength(500)]
    public string? ConfgValor { get; set; }
}
