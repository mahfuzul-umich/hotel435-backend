using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;
using Microsoft.EntityFrameworkCore;

namespace hotel435.Services
{
    public class DbOperationsBase<TEntity> : IDbOperationsBase<TEntity> where TEntity: class
    {
        private readonly Hotel435DbContext _dbContext;

        public DbOperationsBase(Hotel435DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity model)
        {
            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            var resource = await _dbContext.FindAsync<TEntity>(id);
            return resource;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var resources = await _dbContext.Set<TEntity>().ToListAsync();
            return resources;
        }

        public virtual async Task DeleteAsync(string id)
        {
            var resource = await GetByIdAsync(id);
            _dbContext.Set<TEntity>().Remove(resource);
            await _dbContext.SaveChangesAsync();
        }
    }
}
