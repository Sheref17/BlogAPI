using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.IRepos
{
    public interface IPostRepository : IGenericRepository<BlogPost>
    {
    
     
        Task AddCommentAsync(Comment comment);
        Task AddTagAsync(Tag tag);

    }
}
