using Data.SqlServer.KursReferences.Employee;

namespace DTO.KursReferences.Project;
using Data.SqlServer.KursReferences.Entities;

public record ProjectDto
{
    public required Guid Id { set; get; }
    public required string Name { set; get; }
    public required string? Note { set; get; }
    public required bool IsDeleted { get; set; }
    public required bool IsClosed { get; set; }
    public required DateOnly DateStart { get; set; }
    public required DateOnly? DateEnd { get; set; }
    public decimal? ManagerDC => Manager?.DocCode;
    public required EmployeeDto? Manager { get; set; }
    public required Guid? ParentId { get; set; }
    public required DateTime? UpdateDate { get; set; }
    public required bool? IsExcludeFromProfitAndLoss { get; set; }
}

public static class ProjectMappingExtensions
{
    public static ProjectDto MapToProjectDto(this Project entity)
    {
        return new ProjectDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Note = entity.Note,
            IsDeleted = entity.IsDeleted,
            IsClosed = entity.IsClosed,
            DateStart = entity.DateStart,
            DateEnd = entity.DateEnd,
            Manager = entity.ManagerDCNavigation?.MapToEmployeeDto(),
            ParentId = entity.ParentId,
            UpdateDate = entity.UpdateDate,
            IsExcludeFromProfitAndLoss = entity.IsExcludeFromProfitAndLoss
        };
    }
}
