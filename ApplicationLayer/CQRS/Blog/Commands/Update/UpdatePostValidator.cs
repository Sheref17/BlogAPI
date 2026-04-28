using CoreLayer.Entities.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Update
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Post Id must be valid");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .MinimumLength(10);

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.Status)
                .Must(status =>
                    string.IsNullOrWhiteSpace(status) ||
                    Enum.TryParse<PostStatus>(status, true, out _))
                .WithMessage("Invalid post status");
        }
    }
}
