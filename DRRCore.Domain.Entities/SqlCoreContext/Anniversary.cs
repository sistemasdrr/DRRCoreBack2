﻿using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Anniversary
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Type { get; set; }

    public string? Observations { get; set; }

    public string? ClassName { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }
}
