using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class KontragentCash
{
    public Guid Id { get; set; }

    public decimal KontragentDC { get; set; }

    public int Count { get; set; }

    public DateTime LastUpdate { get; set; }

    public Guid DBId { get; set; }

    public Guid UserId { get; set; }

    public virtual DataSource DB { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
