using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class UserLogin
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public string? UserLogin1 { get; set; }

    public string Password { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? EmailPassword { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual ICollection<UserProcess> UserProcesses { get; set; } = new List<UserProcess>();
}
