using ApplicationLayer.CQRS.Comment.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Edit
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.PostId)
                .GreaterThan(0).WithMessage("Post Id is invalid");

            RuleFor(x => x.CommentId)
                .GreaterThan(0).WithMessage("Comment Id must be valid");

            RuleFor(x => x.Content)
             .NotEmpty().WithMessage("Comment content is required")
             .MinimumLength(2)
             .MaximumLength(500);
        }
    }
}
