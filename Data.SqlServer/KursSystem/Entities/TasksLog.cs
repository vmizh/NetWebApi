using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class TasksLog
{
    public Guid Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string TaskInfo { get; set; } = null!;

    public DateTime ExecTime { get; set; }
}
