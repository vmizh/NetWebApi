using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

/// <summary>
/// тАБЛИЦА ФОРМИРОВАНИЯ ГЛАВНОГО ЭКРАНА. ГРУППЫ
/// </summary>
public partial class KursMenuGroup
{
    /// <summary>
    /// Ключ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование группы
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// пРИМЕЧАНИЯ
    /// </summary>
    public string? Note { get; set; }

    public int OrderBy { get; set; }

    public byte[]? Picture { get; set; }

    public int? ParentId { get; set; }

    public virtual ICollection<KursMenuGroup> InverseParent { get; set; } = new List<KursMenuGroup>();

    public virtual ICollection<KursMenuItem> KursMenuItems { get; set; } = new List<KursMenuItem>();

    public virtual KursMenuGroup? Parent { get; set; }
}
