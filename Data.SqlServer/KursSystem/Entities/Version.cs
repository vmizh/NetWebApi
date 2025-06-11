using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class Version
{
    public Guid Id { get; set; }

    public int SystemNum { get; set; }

    public int TestNum { get; set; }

    public int VersionNum { get; set; }

    public string ServerPath { get; set; } = null!;

    public DateOnly DateCreate { get; set; }

    public bool IsActive { get; set; }
}
