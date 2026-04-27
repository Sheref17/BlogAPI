using ApplicationLayer.Common;
using ApplicationLayer.CQRS.Blog.BlogDtos;
using ApplicationLayer.CQRS.Comment.CommentDtos;
using ApplicationLayer.CQRS.Tag.TagDtos;
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

        public async Task<PostDetailsDto?> GetByIdAsync(int id, int page, int pageSize)
        {
      
            var post = await _context.Posts
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    CategoryName = p.Category.Name,
                    Status = p.Status.ToString(),
                    p.CreatedAt,
                    Tags = p.Tags.Select(t => new TagDto
                    {
                        Id = t.Id,
                        Name = t.Name
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (post == null) return null;

         
            var commentsQuery = _context.Comments
                .Where(c => c.BlogPostId == id);

            var totalCount = await commentsQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (page > totalPages)
                page = totalPages == 0 ? 1 : totalPages;

            var comments = await commentsQuery
                .OrderByDescending(c => c.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    UserName = _context.Users
                        .Where(u => u.Id == c.UserId)
                        .Select(u => u.FullName)
                        .FirstOrDefault()
                })
                .ToListAsync();

        
            return new PostDetailsDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CategoryName = post.CategoryName,
                Status = post.Status,
                CreatedAt = post.CreatedAt,
                Tags = post.Tags,
             

             
                CommentsPagination = new PagedResponse<CommentDto>
                {
                    Page = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    Data = comments
                }
            };
        }

        public async Task<PagedResponse<PostResponseDto>> GetAllAsync(int page, int pageSize)
        {
            var query = _context.Posts.AsQueryable();

            var totalCount = await query.CountAsync();

         
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (page > totalPages)
                page = totalPages == 0 ? 1 : totalPages;

            var data = await query
                .OrderBy(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
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

            return new PagedResponse<PostResponseDto>
            {
                Data = data,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }
    }
}