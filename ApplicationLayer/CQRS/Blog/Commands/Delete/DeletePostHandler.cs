using ApplicationLayer.CustomExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Delete
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IPostRepository _repo;
        private readonly ICurrentUserService _currentUser;

        public DeletePostHandler(IPostRepository repo, ICurrentUserService currentUser)
        {
            _repo = repo;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsInRole("Admin"))
                throw new UnauthorizedAccessException("Not allowed");
            var post = await _repo.GetByIdAsync(request.Id);
            if (post is null)
                throw new PostNotFoundException("Post not found");
            await _repo.DeleteAsync(post);
            await _repo.SaveChangesAsync();

            return true;
        }
    }
}
