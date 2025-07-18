﻿using Data.SqlServer.KursSystem.Entities;

namespace Data.SqlServer.KursSystem.Repositories.UserRepository;

public interface IUserRepository
{
    Task<User?> GetByName(string name);

    Task<IEnumerable<UserMenuRight>?> GetRightsMenu(Guid userId, Guid dbId);

}
