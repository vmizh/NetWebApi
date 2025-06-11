using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class UserMenuOrder
{
    public Guid Id { get; set; }

    public bool IsGroup { get; set; }

    public Guid UserId { get; set; }

    public int TileId { get; set; }

    public int? Order { get; set; }
}
