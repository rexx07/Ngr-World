using System.ComponentModel.DataAnnotations;

namespace NgrWrld.Core.Domain;

public class BaseEntity
{
    [Key]
    [Required]
    public int Id { get; set; }
}