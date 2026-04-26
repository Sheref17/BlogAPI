using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Create
{
    public class AddCommentCommand : IRequest<bool>
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
