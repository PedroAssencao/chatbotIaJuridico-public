using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatbotIaJuridico.Infra;

[Table("advogado")]
public partial class Advogado
{
    [Key]
    [Column("adv_id")]
    public int AdvId { get; set; }

    [Column("adv_senha")]
    [StringLength(255)]
    public string AdvSenha { get; set; } = null!;

    [Column("adv_waid")]
    [StringLength(255)]
    public string AdvWaid { get; set; } = null!;

    [Column("adv_nome")]
    [StringLength(255)]
    public string AdvNome { get; set; } = null!;

    [Column("adv_cpf")]
    [StringLength(14)]
    public string AdvCpf { get; set; } = null!;

    [InverseProperty("Adv")]
    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    [InverseProperty("Adv")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("Adv")]
    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    [InverseProperty("Adv")]
    public virtual ICollection<PreInsumo> PreInsumos { get; set; } = new List<PreInsumo>();

    [InverseProperty("Adv")]
    public virtual ICollection<Peticao> Peticaos { get; set; } = new List<Peticao>();

    [InverseProperty("Adv")]
    public virtual ICollection<PreProcesso> PreProcessos { get; set; } = new List<PreProcesso>();
    public string? maskCpf()
    {
        if (AdvCpf?.Length == 11)
        {
            return $"{AdvCpf.Substring(0, 3)}.{AdvCpf.Substring(3, 3)}.{AdvCpf.Substring(6, 3)}-{AdvCpf.Substring(9, 2)}";
        }
        return AdvCpf;
    }
}
