﻿using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class BusineesActivity
{
    public int Id { get; set; }

    public string? EnglishName { get; set; }

    public string Name { get; set; } = null!;

    public int? IdBusinessBranch { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual BusinessBranch? IdBusinessBranchNavigation { get; set; }
}
