﻿using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class CouponBillingSubscriber
{
    public int Id { get; set; }

    public int? IdSubscriber { get; set; }

    public decimal? NumCoupon { get; set; }

    public decimal? PriceT1 { get; set; }

    public decimal? PriceT2 { get; set; }

    public decimal? PriceT3 { get; set; }

    public decimal? PriceT0 { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<CouponBillingSubscriberHistory> CouponBillingSubscriberHistories { get; set; } = new List<CouponBillingSubscriberHistory>();

    public virtual Subscriber? IdSubscriberNavigation { get; set; }
}
