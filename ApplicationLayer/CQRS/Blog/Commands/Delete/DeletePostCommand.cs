using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Delete
{
    public class DeletePostCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
