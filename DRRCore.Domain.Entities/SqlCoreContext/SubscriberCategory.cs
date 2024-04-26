using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SubscriberCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnglishName { get; set; }

    public string? Abreviation { get; set; }

    public string? Observations { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public int? OldCode { get; set; }

    public string? RubCodigo { get; set; }

    public virtual ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
}
