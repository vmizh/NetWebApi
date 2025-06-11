using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class UserMenuRight
{
    public Guid Id { get; set; }

    public Guid DBId { get; set; }

    public string LoginName { get; set; } = null!;

    public int MenuId { get; set; }

    public bool IsReadOnly { get; set; }

    public virtual DataSource DB { get; set; } = null!;

    public virtual KursMenuItem Menu { get; set; } = null!;
}
