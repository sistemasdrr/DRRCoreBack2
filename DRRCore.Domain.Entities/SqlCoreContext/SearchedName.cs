using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class SearchedName
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public int? IdPerson { get; set; }

    public string Type { get; set; } = null!;

    public string NameSearched { get; set; } = null!;

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
