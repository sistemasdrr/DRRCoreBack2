using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Personal
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public string? Type { get; set; }

    public string? Code { get; set; }

    public bool? Internal { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual ICollection<PersonalPrice> PersonalPrices { get; set; } = new List<PersonalPrice>();
}
