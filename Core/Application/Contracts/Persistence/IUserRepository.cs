﻿using Core.Domain.Entities;

namespace Core.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
    }
}