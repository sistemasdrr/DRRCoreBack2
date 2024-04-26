using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SQLContext;

public partial class AttachmentsNotSend
{
    public int IdAttachmentsNotSend { get; set; }

    public int IdEmailHistory { get; set; }

    public string FileName { get; set; } = null!;

    public string AttachmentsUrl { get; set; } = null!;

    public virtual EmailHistory IdEmailHistoryNavigation { get; set; } = null!;
}
