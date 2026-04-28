using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Create
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Status { get; set; } 
        public int CategoryId { get; set; }
    }
}
