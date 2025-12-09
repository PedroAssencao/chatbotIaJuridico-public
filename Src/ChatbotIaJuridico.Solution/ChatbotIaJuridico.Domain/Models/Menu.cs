using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChatbotIaJuridico.Domain.Models.Enum;

namespace ChatbotIaJuridico.Infra;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Column("men_id")]
    public int MenId { get; set; }

    [Column("men_header")]
    [StringLength(255)]
    public string? MenHeader { get; set; }

    [Column("men_footer")]
    [StringLength(255)]
    public string? MenFooter { get; set; }

    [Column("men_body")]
    [StringLength(255)]    
    public string MenBody { get; set; } = null!;

    [Column("men_tipo")]
    public ETipoMenu MenTipo { get; set; }

    [Column("men_title")]
    [StringLength(255)]
    public string MenTitle { get; set; } = null!;

    [InverseProperty("Men")]
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
