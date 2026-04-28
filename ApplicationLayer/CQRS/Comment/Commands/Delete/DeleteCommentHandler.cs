using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.AuthourizedExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.IRepos;
using MediatR;
using MediatR.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Comment.Commands.Delete
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly IPostRepository _repo;
        private readonly ICurrentUserService _currentUser;

        public DeleteCommentHandler(IPostRepository repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _currentUser = currentUser;
        }
        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsInRole("Admin") )
                throw new NotAdminOrEditorException("You Are Not Admin To Delete");

            var post = await _repo.GetByIdAsync(request.PostId);
            if (post is null) throw new PostNotFoundException(request.PostId);

            var comment = post.Comments.FirstOrDefault(c => c.Id == request.CommentId);
            if (comment == null)
                throw new CommentNotFoundException(request.CommentId);

            post.RemoveComment(request.CommentId);
            await _repo.SaveChangesAsync();

            return true;



        }
    }
}
