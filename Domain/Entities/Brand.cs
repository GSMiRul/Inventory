using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("ct_Brands")]
public class Brand : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string? BarandName { get; set; }
    [StringLength(20)]
    public string? ShortName { get; set; }
    public string? Summary { get; set; }
}
