using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Update
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagValidator()
        {
            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage("Tag Id must be valid");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required")
                .MinimumLength(2)
                .MaximumLength(30);
        }
    }
}
