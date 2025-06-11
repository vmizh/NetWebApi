using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

public partial class FormLayout
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string FormName { get; set; } = null!;

    public string ControlName { get; set; } = null!;

    public string Layout { get; set; } = null!;

    public int? FormId { get; set; }

    public DateTime UpdateDate { get; set; }

    public string? WindowState { get; set; }

    public int? Version { get; set; }

    public virtual KursMenuItem? Form { get; set; }

    public virtual User User { get; set; } = null!;
}
