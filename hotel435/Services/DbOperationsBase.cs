using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;

namespace hotel435.Services
{
    public class DbOperationsBase<TEntity> : IDbOperationsBase<TEntity> where TEntity: class
    {
        private readonly Hotel435DbContext _dbContext;

        public DbOperationsBase(Hotel435DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> InsertAsync(TEntity model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var resource = await _dbContext.FindAsync<TEntity>(id);
            return resource;
        }
    }
}
