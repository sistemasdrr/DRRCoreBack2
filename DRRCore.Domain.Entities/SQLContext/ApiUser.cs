using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class ApiUser
{
    public int IdApiUser { get; set; }

    public string CodigoAbonado { get; set; } = null!;

    public Guid Token { get; set; }

    public string Environment { get; set; } = null!;

    public bool? Active { get; set; }

    public bool? Enable { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<ApiHistory> ApiHistories { get; set; } = new List<ApiHistory>();
}
