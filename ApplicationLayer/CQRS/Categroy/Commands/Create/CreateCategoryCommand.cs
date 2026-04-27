using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Commands.Create
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public string Name { get; set; } = default!;
    }
}
