using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CouponBillingSubscriberHistory
{
    public int Id { get; set; }

    public int? IdCouponBilling { get; set; }

    public int? IdEmployee { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public int? CouponAmount { get; set; }

    public decimal? CouponUnitPrice { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual CouponBillingSubscriber? IdCouponBillingNavigation { get; set; }
}
