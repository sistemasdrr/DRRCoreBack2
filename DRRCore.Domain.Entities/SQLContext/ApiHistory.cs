using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class ApiHistory
{
    public int IdApiHistory { get; set; }

    public int IdApiUser { get; set; }

    public string Search { get; set; } = null!;

    public bool Success { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Languaje { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ApiUser IdApiUserNavigation { get; set; } = null!;
}
