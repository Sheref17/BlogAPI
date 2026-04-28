
using ApplicationLayer.CustomExceptions.AuthourizedExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Edit
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly IPostRepository _repo;
        private readonly ICurrentUserService _currentUser;

        public UpdateCommentHandler(IPostRepository repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _repo.GetByIdAsync(request.PostId);

            if (post == null)
                throw new PostNotFoundException(request.PostId);

            var comment = post.Comments.FirstOrDefault(c => c.Id == request.CommentId);

            if (comment == null)
                throw new CommentNotFoundException(request.CommentId);

            if (comment.UserId != _currentUser.UserId)
                throw new ForbiddenException("You are not this Authour of this comment");


            post.UpdateComment(request.CommentId, request.Content);
            await _repo.SaveChangesAsync();
            return true;




        }
    }
}
