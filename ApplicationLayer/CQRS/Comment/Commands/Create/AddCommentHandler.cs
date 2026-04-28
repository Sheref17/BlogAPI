using ApplicationLayer.CustomExceptions;

using CoreLayer.Entities;
using ApplicationLayer.Interfaces;

using CoreLayer.IRepos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;

namespace ApplicationLayer.CQRS.Comment.Commands.Create
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICurrentUserService _currentUserService;

        public AddCommentHandler(IPostRepository postRepository, ICurrentUserService currentUserService)
        {
            _postRepository = postRepository;
            _currentUserService = currentUserService;
        }
        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            if (post is null)
                throw new PostNotFoundException(request.PostId);


            var comment = new CoreLayer.Entities.Comment(
                  _currentUserService.UserId,
                  request.Content,
                  request.PostId
            );


            await _postRepository.AddCommentAsync(comment);

            await _postRepository.SaveChangesAsync();


            return true;
        }
    }
}
