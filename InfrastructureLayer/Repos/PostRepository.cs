using CoreLayer.Entities;
using CoreLayer.IRepos;
using InfrastructureLayer.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repos
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BlogPost post)
        {
            await _context.Posts.AddAsync(post);
        }

        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.Comments).Include(p => p.Tags).Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _context.Posts
                .Include(p => p.Comments).Include(p => p.Tags).Include(p => p.Category)
                .ToListAsync();
        }

        public Task DeleteAsync(BlogPost post)
        {
            _context.Posts.Remove(post);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistCategroy(int categoryId)
        {
            var result = await _context.Categories.FindAsync(categoryId);
            if (result is null) return false;
            else return true;

        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
        }
    }
}
