using Common.Helper.Interfaces.Identity;

namespace DTO.Common;

public record IdentityDto(object Id) : IBaseIdentity
{
    public object Id { set; get; } = Id;
};
