using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class EmailConfiguration
{
    public int IdEmailConfiguration { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? Enable { get; set; }

    public bool? HasParameter { get; set; }

    public bool? HasTable { get; set; }

    public bool? HasAttachment { get; set; }

    public bool? FlagFooter { get; set; }
}
