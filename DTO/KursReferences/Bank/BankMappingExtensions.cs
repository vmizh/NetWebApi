using Data.SqlServer.KursReferences.Entities;

namespace DTO.KursReferences.Bank;

public static class BankMappingExtensions
{
    public static BankDto MapToBankDto(this SD_44 entity)
    {
        return new BankDto
        {
            DocCode = entity.DOC_CODE,
            Name = entity.BANK_NAME,
            CorrespAcc = entity.CORRESP_ACC,
            PostCode = entity.POST_CODE,
            Address = entity.ADDRESS,
            NickName = entity.BANK_NICKNAME,
            UpdateDate = entity.UpdateDate
        };
    }

    public static SD_44 MapToSD_44(this BankDto dto)
    {
        return new SD_44
        {
            DOC_CODE = dto.DocCode,
            BANK_NAME = dto.Name,
            CORRESP_ACC = dto.CorrespAcc,
            POST_CODE = dto.PostCode,
            ADDRESS = dto.Address,
            BANK_NICKNAME = dto.NickName,
            UpdateDate = dto.UpdateDate,
        };
    }
}
