using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class Error
{
    public Guid Id { get; set; }

    public Guid DbId { get; set; }

    public Guid UserId { get; set; }

    public string Host { get; set; } = null!;

    public string ErrorText { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime Moment { get; set; }

    public virtual DataSource Db { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
