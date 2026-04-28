using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Create
{
    public class CreateTagValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tag name is required")
                .MinimumLength(2).WithMessage("Tag name must be at least 2 characters")
                .MaximumLength(30).WithMessage("Tag name must not exceed 30 characters");
            RuleFor(x => x.PostId)
                      .GreaterThan(0).WithMessage("PostId must be greater than 0");


        }
    }
}
