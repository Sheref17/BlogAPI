using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Delete
{
    public class DeleteTagCommand : IRequest<bool>
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
