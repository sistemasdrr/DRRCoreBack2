using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext2;

public partial class TraductionPerson
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public string? TPnacionality { get; set; }

    public string? TPbirthPlace { get; set; }

    public string? TPmarriedTo { get; set; }

    public string? TPprofession { get; set; }

    public string? TPnewcomm { get; set; }

    public string? TPreputation { get; set; }

    public string? TDvalue { get; set; }

    public string? TDresidence { get; set; }

    public string? TCcurjob { get; set; }

    public string? TCstartDate { get; set; }

    public string? TCenddt { get; set; }

    public string? TCincome { get; set; }

    public string? TCdetails { get; set; }

    public string? TAotherAct { get; set; }

    public string? TPrdetails { get; set; }

    public string? TSbsantecedente { get; set; }

    public string? TSbsrickCnt { get; set; }

    public string? TSbscommentSbs { get; set; }

    public string? TSbscommentBank { get; set; }

    public string? TSbslitig { get; set; }

    public string? THdetails { get; set; }

    public string? TIgdetails { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UploadDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
