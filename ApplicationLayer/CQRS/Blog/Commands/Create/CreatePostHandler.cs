using ApplicationLayer.CustomExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.Entities;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Commands.Create
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostRepository _repo;
        private readonly ICurrentUserService _currentUser;
        private readonly ICategroyRepository _categroyRepository;

        public CreatePostHandler(IPostRepository repo, ICurrentUserService currentUser , ICategroyRepository categroyRepository)
        {
            _repo = repo;
            _currentUser = currentUser;
           _categroyRepository = categroyRepository;
        }
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await _categroyRepository.GetByIdAsync(request.CategoryId);
            if (categoryExist is null)
            {
                throw new CategroyNotFoundException($"Category With This Id : {request.CategoryId} not found");
            }

            var post = new BlogPost(
                request.Title,
                request.Content,
                _currentUser.UserId,
                request.CategoryId

            );

            await _repo.AddAsync(post);
            await _repo.SaveChangesAsync();

            return post.Id;
        }
    }
}
