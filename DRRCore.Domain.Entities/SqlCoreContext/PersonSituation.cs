using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PersonSituation
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnglishName { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
