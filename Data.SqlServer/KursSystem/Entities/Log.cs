﻿using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class Log
{
    public int Id { get; set; }

    public string? MachineName { get; set; }

    public DateTime? Logged { get; set; }

    public string? Level { get; set; }

    public string? Message { get; set; }

    public string? Logger { get; set; }

    public string? Callsite { get; set; }

    public string? ProgramName { get; set; }

    public string? UserName { get; set; }
}
