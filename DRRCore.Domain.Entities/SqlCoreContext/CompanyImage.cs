using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyImage
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? ImgDesc1 { get; set; }

    public string? Path1 { get; set; }

    public string? ImgDesc2 { get; set; }

    public string? Path2 { get; set; }

    public string? ImgDesc3 { get; set; }

    public string? Path3 { get; set; }

    public string? ImgDesc4 { get; set; }

    public string? Path4 { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
