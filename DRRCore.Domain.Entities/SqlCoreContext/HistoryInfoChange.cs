using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class HistoryInfoChange
{
    public int Id { get; set; }

    public int? LastUser { get; set; }

    public int? IdTicket { get; set; }

    public int? IdCompany { get; set; }

    public int? IdPerson { get; set; }

    public string IdentifierTraduction { get; set; } = null!;

    public string Module { get; set; } = null!;

    public string Action { get; set; } = null!;

    public DateTime CreationDate { get; set; }
}
