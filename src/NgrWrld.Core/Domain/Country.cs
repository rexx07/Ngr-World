using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NgrWrld.Core.Domain;

[Table("Countries")]
[Index(nameof(Name))]
[Index(nameof(ISO2))]
[Index(nameof(ISO3))]
public class Country: BaseEntity
{
    /// <summary>
    /// Country name (in UTF8 format)
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Country code (in ISO 3166-1 ALPHA-2 format)
    /// </summary>
    public string ISO2 { get; set; } = null!;
    /// <summary>
    /// Country code (in ISO 3166-1 ALPHA-3 format)
    /// </summary>
    public string ISO3 { get; set; } = null!;
    /// <summary>
    /// A collection of all the cities related to this country.
    /// </summary>
    public ICollection<City>? Cities { get; set; } = null!;
}