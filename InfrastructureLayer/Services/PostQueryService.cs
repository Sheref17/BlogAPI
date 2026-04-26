using ApplicationLayer.CQRS.Blog.BlogDtos;
using ApplicationLayer.CQRS.Comment.CommentDtos;
using ApplicationLayer.Interfaces;
using InfrastructureLayer.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer.Services
{
    public class PostQueryService : IPostQueryService
    {
        private readonly ApplicationDbContext _context;

        public PostQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PostDetailsDto?> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new PostDetailsDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CategoryName = p.Category.Name,
                    Status = p.Status.ToString(),
                    CreatedAt = p.CreatedAt,

                    Comments = p.Comments.Select(c => new CommentDto
                    {
                        Id = c.Id,
                        Content = c.Content,


                        UserName = _context.Users
                            .Where(u => u.Id == c.UserId)
                            .Select(u => u.FullName)
                            .FirstOrDefault()
                    }).ToList(),

                    Tags = p.Tags.Select(t => t.Name).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<PostResponseDto>> GetAllAsync()
        {
            return await _context.Posts
                .Select(p => new PostResponseDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CategoryName = p.Category.Name,
                    Status = p.Status.ToString(),
                    CreatedAt = p.CreatedAt
                })
                .ToListAsync();
        }
    }
}