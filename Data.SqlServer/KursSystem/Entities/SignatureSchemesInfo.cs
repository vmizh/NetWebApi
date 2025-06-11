using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class SignatureSchemesInfo
{
    public Guid Id { get; set; }

    public Guid SignId { get; set; }

    public Guid? ParentId { get; set; }

    public bool IsRequired { get; set; }

    public string? Note { get; set; }

    public Guid SchemeId { get; set; }

    public virtual ICollection<SignatureSchemesInfo> InverseParent { get; set; } = new List<SignatureSchemesInfo>();

    public virtual SignatureSchemesInfo? Parent { get; set; }

    public virtual SignatureScheme Scheme { get; set; } = null!;

    public virtual SignatureType Sign { get; set; } = null!;
}
