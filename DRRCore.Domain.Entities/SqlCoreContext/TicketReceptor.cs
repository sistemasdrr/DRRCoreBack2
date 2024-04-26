using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TicketReceptor
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public bool? IsEnFecha { get; set; }

    public bool? IsDobleFecha { get; set; }

    public int? IdCountry { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }
}
