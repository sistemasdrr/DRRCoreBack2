using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PhotoPerson
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public int? NumImg { get; set; }

    public string? Base64 { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? Description { get; set; }

    public string? DescriptionEng { get; set; }

    public bool? PrintImg { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
