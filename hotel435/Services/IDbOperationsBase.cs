using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel435.Services
{
    public interface IDbOperationsBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> InsertAsync(TEntity model);
        Task<TEntity> GetByIdAsync(string id);
        Task DeleteAsync(string id);
    }
}
