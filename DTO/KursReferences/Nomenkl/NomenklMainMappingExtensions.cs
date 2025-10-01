using Data.SqlServer.KursReferences.Entities;
using DTO.KursReferences.Unit;

namespace DTO.KursReferences.Nomenkl;

public static class NomenklMainMappingExtensions
{
    public static NomenklMainDto MapToNomenklMainDto(this NomenklMain entity)
    {
        return new NomenklMainDto
        {
            Id = entity.Id,
            Name = entity.Name,
            NomenklNumber = entity.NomenklNumber,
            Note = entity.Note,
            IsUsluga = entity.IsUsluga,
            Category = entity.CategoryDCNavigation.MapToNomenklGroupDto(),
            FullName = entity.FullName,
            IsNakladExpense = entity.IsNakladExpense,
            CountryId = entity.CountryId,
            Country = null,
            Unit = entity.UnitDCNavigation.MapToUnitDto(),
            IsComplex = entity.IsComplex,
            NomenklType = entity.TypeDCNavigation.MapToNomenklTypeDto(),
            IsDelete = entity.IsDelete,
            IsRentabelnost = entity.IsRentabelnost,
            IsCurrencyTransfer = entity.IsCurrencyTransfer,
            IsOnlyState = entity.IsOnlyState,
            UpdateDate = entity.UpdateDate
        };
    }

    public static NomenklMain MapToNomewnklMain(this NomenklMainDto dto)
    {
        return new NomenklMain
        {
            Id = dto.Id,
            Name = dto.Name,
            NomenklNumber = dto.NomenklNumber,
            Note = dto.Note,
            IsUsluga = dto.IsUsluga,
            CategoryDC = dto.Category.DocCode,
            FullName = dto.FullName,
            IsNakladExpense = dto.IsNakladExpense,
            CountryId = dto.CountryId,
            UnitDC = dto.Unit.DocCode,
            IsComplex = dto.IsComplex,
            TypeDC = dto.NomenklType.DocCode,
            IsDelete = dto.IsDelete,
            IsRentabelnost = dto.IsRentabelnost,
            IsCurrencyTransfer = dto.IsCurrencyTransfer,
            IsOnlyState = dto.IsOnlyState,
            UpdateDate = dto.UpdateDate
        };
    }
}
