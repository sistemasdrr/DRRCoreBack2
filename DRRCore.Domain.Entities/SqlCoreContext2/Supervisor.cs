using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class Supervisor
{
    public int Id { get; set; }

    public int? IdUserLogin { get; set; }

    public string? AsignedTo { get; set; }

    public string? Type { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? Enable { get; set; }

    public virtual UserLogin? IdUserLoginNavigation { get; set; }
}
