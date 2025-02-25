using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class TraductionCompany
{
    public int Id { get; set; }

    public int? IdCompany { get; set; }

    public string? TEcomide { get; set; }

    public string? TEduration { get; set; }

    public string? TEreputation { get; set; }

    public string? TEnew { get; set; }

    public string? TBduration { get; set; }

    public string? TBregisterIn { get; set; }

    public string? TBpublicRegis { get; set; }

    public string? TBpaidCapital { get; set; }

    public string? TBincreaseDate { get; set; }

    public string? TBtacRate { get; set; }

    public string? TBlegalBack { get; set; }

    public string? TBhistory { get; set; }

    public string? TRsalePer { get; set; }

    public string? TRcreditPer { get; set; }

    public string? TRterritory { get; set; }

    public string? TRextSales { get; set; }

    public string? TRnatiBuy { get; set; }

    public string? TRinterBuy { get; set; }

    public string? TRtotalArea { get; set; }

    public string? TRotherLocals { get; set; }

    public string? TRprincAct { get; set; }

    public string? TRadiBus { get; set; }

    public string? TFjob { get; set; }

    public string? TFcomment { get; set; }

    public string? TFprincActiv { get; set; }

    public string? TFselectFin { get; set; }

    public string? TFanalistCom { get; set; }

    public string? TFtabComm { get; set; }

    public string? TScommentary { get; set; }

    public string? TSbancarios { get; set; }

    public string? TSavales { get; set; }

    public string? TSlitig { get; set; }

    public string? TScredHis { get; set; }

    public string? TOqueryCredit { get; set; }

    public string? TOsugCredit { get; set; }

    public string? TOcommentary { get; set; }

    public string? TIgeneral { get; set; }

    public string? TRmainAddress { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UploadDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }
}
