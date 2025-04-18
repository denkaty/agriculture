﻿using Agriculture.Shared.Application.Abstractions.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Agriculture.Shared.Infrastructure.Persistences
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DatabaseFacade Database => _dbContext.Database;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int entitiesModifiedCount = await _dbContext.SaveChangesAsync(cancellationToken);

            return entitiesModifiedCount;
        }

    }
}
