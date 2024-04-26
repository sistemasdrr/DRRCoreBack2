using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class Order
{
    public int Id { get; set; }

    public string? Language { get; set; }

    public string? TypeOrder { get; set; }

    public string? TypeReport { get; set; }

    public DateTime? DateReport { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? RealExpirationDate { get; set; }

    public int? IdSubscriber { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? CreditAmount { get; set; }

    public string? Terms { get; set; }

    public int? IdCompany { get; set; }

    public int? IdPerson { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }

    public virtual Subscriber? IdSubscriberNavigation { get; set; }
}
