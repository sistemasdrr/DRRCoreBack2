using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Process
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Menu { get; set; }

    public int? OrderItem { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? Path { get; set; }

    public string? Icon { get; set; }

    public int? Level { get; set; }

    public int? Father { get; set; }

    public virtual Process? FatherNavigation { get; set; }

    public virtual ICollection<Process> InverseFatherNavigation { get; set; } = new List<Process>();

    public virtual ICollection<UserProcess> UserProcesses { get; set; } = new List<UserProcess>();
}
