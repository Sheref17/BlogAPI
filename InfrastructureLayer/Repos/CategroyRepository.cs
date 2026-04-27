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
    public class CategroyRepository : ICategroyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategroyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Category entity) => await _dbContext.Categories.AddAsync(entity);

        public async Task<bool> CategoryNameExist(string name)
        {
            return await _dbContext.Categories
                .AnyAsync(c => c.Name == name);
        }

        public  Task DeleteAsync(Category entity)
        { 
       
           _dbContext.Categories.Remove(entity);
            return  Task.CompletedTask;
           

        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            return category;
        }

        public async Task SaveChangesAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
