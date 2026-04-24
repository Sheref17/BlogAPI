using ApplicationLayer.CustomExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Update
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand , bool>
    {
        private readonly IPostRepository _repo;
        private readonly ICurrentUserService _currentUser;
        public UpdatePostHandler(IPostRepository repo , ICurrentUserService currentUser)
        {
            _repo = repo;
            _currentUser = currentUser;
        }
        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _repo.GetByIdAsync(request.Id);
            if (post is null) throw new PostNotFoundException("Post Not Found");
            var categroyExist = await _repo.ExistCategroy(request.CategoryId);
            if (!categroyExist)
                throw new CategroyNotFoundException($"Category With This Id : {request.CategoryId} not found");
            if (post.AuthorId != _currentUser.UserId) throw new UnauthorizedAccessException("You are not the author of this post");
            post.Update(request.Title, request.Content);
            post.ChangeCategory(request.CategoryId);
            await _repo.SaveChangesAsync();
            return true;
          ;
      





        }
    }
}
