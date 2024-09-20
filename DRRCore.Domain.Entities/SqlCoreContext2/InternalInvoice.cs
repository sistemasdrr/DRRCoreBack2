using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class InternalInvoice
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Cycle { get; set; }

    public string? Code { get; set; }

    public bool? Sended { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<InternalInvoiceDetail> InternalInvoiceDetails { get; set; } = new List<InternalInvoiceDetail>();
}
