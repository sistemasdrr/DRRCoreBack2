using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Parameter
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Description { get; set; }

    public string? Value { get; set; }

    public bool? Flag { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }
}
