using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.IRepos
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(int id);

        Task DeleteAsync(TEntity entity);
        Task SaveChangesAsync();

    }
}
