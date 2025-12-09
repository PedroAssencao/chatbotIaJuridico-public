using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotIaJuridico.Infra;

[Table("cliente")]
public partial class Cliente
{
    [Key]
    [Column("cli_id")]
    public int CliId { get; set; }

    [Column("cli_nome")]
    [StringLength(255)]
    public string? CliNome { get; set; }

    [Column("cli_dataCriacao", TypeName = "datetime")]
    public DateTime? CliDataCriacao { get; set; }

    [Column("cli_dataModificacao", TypeName = "datetime")]
    public DateTime? CliDataModificacao { get; set; }

    [Column("cli_cpf")]
    [StringLength(14)]
    public string CliCpf { get; set; } = null!;

    [Column("adv_id")]
    public int AdvId { get; set; }

    [ForeignKey("AdvId")]
    [InverseProperty("Clientes")]
    public virtual Advogado Adv { get; set; } = null!;

    [InverseProperty("Cli")]
    public virtual ICollection<PreProcesso> PreProcessos { get; set; } = new List<PreProcesso>();
    public string? maskCpf()
    {
        if (CliCpf?.Length == 11)
        {
            return $"{CliCpf.Substring(0, 3)}.{CliCpf.Substring(3, 3)}.{CliCpf.Substring(6, 3)}-{CliCpf.Substring(9, 2)}";
        }
        return CliCpf;
    }
    public string? maskNome()
    {
        if (CliNome?.Length >= 20)
        {
            return $"{CliNome.Substring(0, 19)}.".ToString();
        }
        return CliNome;
    }

}
