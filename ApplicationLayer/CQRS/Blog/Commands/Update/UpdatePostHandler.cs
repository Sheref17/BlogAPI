using ApplicationLayer.CustomExceptions;
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

namespace ApplicationLayer.CQRS.Blog.Commands.Update
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, bool>
    {
        private readonly IPostRepository _repo;
        private readonly ICurrentUserService _currentUser;
        private readonly ICategroyRepository _categroyRepository;

        public UpdatePostHandler(IPostRepository repo, ICurrentUserService currentUser , ICategroyRepository categroyRepository)
        {
            _repo = repo;
            _currentUser = currentUser;
            _categroyRepository = categroyRepository;
        }
        public async Task<bool> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsInRole("Admin") && !_currentUser.IsInRole("Editor"))
                throw new NotAdminOrEditorException();

            var post = await _repo.GetByIdAsync(request.Id);
            if (post is null) throw new PostNotFoundException(request.Id);

            var categroyExist = await _categroyRepository.GetByIdAsync(request.CategoryId); 
            if (categroyExist is null)
                throw new CategroyNotFoundException(request.CategoryId);

           
            post.Update(request.Title, request.Content , request.Status);

            if(post.CategoryId != request.CategoryId)
                post.ChangeCategory(request.CategoryId);

            await _repo.SaveChangesAsync();
            return true;
            ;






        }
    }
}
