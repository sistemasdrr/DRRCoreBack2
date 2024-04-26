using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class PersonProperty
{
    public int Id { get; set; }

    public int? IdPerson { get; set; }

    public string? PropertiesCommentary { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? LastUpdateUser { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public virtual Person? IdPersonNavigation { get; set; }
}
