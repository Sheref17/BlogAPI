using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.IRepos
{
    public interface IPostRepository
    {
        Task AddAsync(BlogPost post);

        Task<BlogPost?> GetByIdAsync(int id);
        Task DeleteAsync(BlogPost post);
        Task<bool> ExistCategroy(int categoryId);

        Task SaveChangesAsync();
    }
}
