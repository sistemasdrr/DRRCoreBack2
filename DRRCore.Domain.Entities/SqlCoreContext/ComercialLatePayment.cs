using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class ComercialLatePayment
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? CreditorOrSupplier { get; set; }

    public string? DocumentType { get; set; }

    public string? Date { get; set; }

    public decimal? AmountNc { get; set; }

    public decimal? AmountFc { get; set; }

    public string? PendingPaymentDate { get; set; }

    public int? DaysLate { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public string? DocumentTypeEng { get; set; }

    public int? IdPerson { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
