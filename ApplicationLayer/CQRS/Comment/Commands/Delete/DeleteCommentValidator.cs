using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Delete
{
    public class DeleteCommentValidator:  AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentValidator()
        {
            RuleFor(x => x.PostId)
                .GreaterThan(0).WithMessage("Post Id is invalid");

            RuleFor(x => x.CommentId)
                .GreaterThan(0).WithMessage("Comment Id must be valid");
        }
    }
}
