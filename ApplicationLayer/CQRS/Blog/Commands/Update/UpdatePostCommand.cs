using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Update
{
    using MediatR;

    public class UpdatePostCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public int CategoryId { get; set; }
    }
}
