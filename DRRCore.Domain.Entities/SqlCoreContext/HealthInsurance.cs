using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class HealthInsurance
{
    public int Id { get; set; }

    public int? IdEmployee { get; set; }

    public string? NameHolder { get; set; }

    public int? IdFamilyBondType { get; set; }

    public string? DocumentNumber { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual FamilyBondType? IdFamilyBondTypeNavigation { get; set; }
}
