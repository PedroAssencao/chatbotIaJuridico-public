using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("chat")]
public partial class Chat
{
    [Key]
    [Column("cha_id")]
    public int ChaId { get; set; }

    [Column("cha_estado")]
    public EChatEstado ChaEstado { get; set; }

    [Column("adv_id")]
    public int AdvId { get; set; }

    [ForeignKey("AdvId")]
    [InverseProperty("Chats")]
    public virtual Advogado Adv { get; set; } = null!;

    [InverseProperty("Cha")]
    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    [InverseProperty("Cha")]
    public virtual ICollection<PreInsumo> PreInsumos { get; set; } = new List<PreInsumo>();
}
