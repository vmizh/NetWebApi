using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class SignatureScheme
{
    public Guid Id { get; set; }

    public Guid DbId { get; set; }

    public string Name { get; set; } = null!;

    public int DocumentTYpeId { get; set; }

    public string? Note { get; set; }

    public virtual DataSource Db { get; set; } = null!;

    public virtual KursMenuItem DocumentTYpe { get; set; } = null!;

    public virtual ICollection<SignatureSchemesInfo> SignatureSchemesInfos { get; set; } = new List<SignatureSchemesInfo>();
}
