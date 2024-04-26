using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PersonHome
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public bool? OwnHome { get; set; }

    public string? Value { get; set; }

    public string? HomeCommentary { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
