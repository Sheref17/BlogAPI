using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.AuthourizedExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.Entities;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Create
{
    public class CreateTagHandler : IRequestHandler<CreateTagCommand, bool>
    {

        private readonly IPostRepository _postRepository;
        private readonly ICurrentUserService _currentUser;

        public CreateTagHandler(IPostRepository postRepository, ICurrentUserService currentUser) 
        { 
            _postRepository = postRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsInRole("Admin") && !_currentUser.IsInRole("Editor"))
                throw new NotAdminOrEditorException();

            var post = await _postRepository.GetByIdAsync(request.PostId);
            if(post is null) throw new PostNotFoundException(request.PostId);

            var tag = new CoreLayer.Entities.Tag(request.Name, request.PostId);
            post.AddTag(tag);

            await _postRepository.SaveChangesAsync();

            return true;






        }
    }
}
