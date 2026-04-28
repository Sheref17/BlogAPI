using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Create
{
    public class CreateCommentValidator : AbstractValidator<AddCommentCommand>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.PostId)
                .GreaterThan(0).WithMessage("Post Id is invalid");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Comment content is required")
                .MinimumLength(2)
                .MaximumLength(500);
        }
    }
}
