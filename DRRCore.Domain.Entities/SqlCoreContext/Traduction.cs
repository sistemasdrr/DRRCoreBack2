using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Traduction
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? IdPerson { get; set; }

    public string Identifier { get; set; } = null!;

    public int? IdLanguage { get; set; }

    public string? ShortValue { get; set; }

    public string? LargeValue { get; set; }

    public decimal? NumberValue { get; set; }

    public int? IntValue { get; set; }

    public bool? Flag1 { get; set; }

    public bool? Flag2 { get; set; }

    public bool? Flag3 { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdaterUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Language? IdLanguageNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
