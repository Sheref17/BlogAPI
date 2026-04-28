using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Delete
{
    public class DeleteTagValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagValidator()
        {
            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage("Tag Id must be valid");
        }
    }
}
