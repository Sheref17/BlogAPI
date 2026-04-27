using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Create
{
    public class CreateTagCommand : IRequest<bool>
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Tag name is required.")]
        public string Name { get; set; } = default!;
    }
}
