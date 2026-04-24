using ApplicationLayer.CQRS.Comment.CommentDtos;
using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.BlogDtos
{
    public class PostDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string CategoryName { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public List<CommentDto> Comments { get; set; }
        public List<string> Tags { get; set; }
    }
}
