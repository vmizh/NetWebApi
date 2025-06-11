using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class SignatureType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public Guid DbId { get; set; }

    public virtual DataSource Db { get; set; } = null!;

    public virtual ICollection<SignatureSchemesInfo> SignatureSchemesInfos { get; set; } = new List<SignatureSchemesInfo>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
