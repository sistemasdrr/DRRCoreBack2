using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class CompanyImage
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? Img1 { get; set; }

    public string? ImgDesc1 { get; set; }

    public string? ImgDescEng1 { get; set; }

    public bool? ImgPrint1 { get; set; }

    public string? Img2 { get; set; }

    public string? ImgDesc2 { get; set; }

    public string? ImgDescEng2 { get; set; }

    public bool? ImgPrint2 { get; set; }

    public string? Img3 { get; set; }

    public string? ImgDesc3 { get; set; }

    public string? ImgDescEng3 { get; set; }

    public bool? ImgPrint3 { get; set; }

    public string? Img4 { get; set; }

    public string? ImgDesc4 { get; set; }

    public string? ImgDescEng4 { get; set; }

    public bool? ImgPrint4 { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? LastUserUpdate { get; set; }

    public bool? Enable { get; set; }
}
