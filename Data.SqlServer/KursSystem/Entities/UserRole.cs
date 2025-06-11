using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class UserRole
{
    public Guid id { get; set; }

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public virtual ICollection<KursMenuItem> Menus { get; set; } = new List<KursMenuItem>();
}
