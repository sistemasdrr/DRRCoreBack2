using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Abreviation { get; set; }

    public bool? IsNatural { get; set; }

    public bool? IsLegal { get; set; }

    public bool? IsNational { get; set; }

    public bool? Flag1 { get; set; }

    public bool? Flag2 { get; set; }

    public bool? Flag3 { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? EnglishName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Person> PersonIdDocumentTypeNavigations { get; set; } = new List<Person>();

    public virtual ICollection<Person> PersonRelationshipDocumentTypeNavigations { get; set; } = new List<Person>();
}
