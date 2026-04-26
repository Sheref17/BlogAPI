using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<bool>
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
    }
}
