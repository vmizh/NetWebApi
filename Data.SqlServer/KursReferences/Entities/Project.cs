using System.Diagnostics.CodeAnalysis;

namespace Data.SqlServer.KursReferences.Entities;

[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
public class Project
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsClosed { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    public decimal? ManagerDC { get; set; }

    public Guid? ParentId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool? IsExcludeFromProfitAndLoss { get; set; }

    public virtual ICollection<Project> InverseParent { get; set; } = new List<Project>();

    public virtual SD_2? ManagerDCNavigation { get; set; }

    public virtual Project? Parent { get; set; }
}
