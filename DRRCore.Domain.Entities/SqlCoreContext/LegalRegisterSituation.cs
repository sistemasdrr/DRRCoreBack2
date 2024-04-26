using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class LegalRegisterSituation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? EnglishName { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? Abreviation { get; set; }

    public string? ApiCode { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
