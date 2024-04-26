using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class EmailHistory
{
    public int IdEmailHistory { get; set; }

    public string Subject { get; set; } = null!;

    public string? Htmlbody { get; set; }

    public DateTime? Date { get; set; }

    public string FromMails { get; set; } = null!;

    public string ToMails { get; set; } = null!;

    public string? CcMails { get; set; }

    public string? CcoMails { get; set; }

    public string Domain { get; set; } = null!;

    public bool? Success { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string InsertUser { get; set; } = null!;

    public string? UpdateUser { get; set; }

    public bool? Enable { get; set; }

    public virtual ICollection<AttachmentsNotSend> AttachmentsNotSends { get; set; } = new List<AttachmentsNotSend>();
}
