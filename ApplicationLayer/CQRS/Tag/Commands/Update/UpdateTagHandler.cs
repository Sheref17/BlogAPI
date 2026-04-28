using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.AuthourizedExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using ApplicationLayer.Interfaces;
using CoreLayer.IRepos;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Tag.Commands.Update
{
    public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICurrentUserService _currentUser;


        public UpdateTagHandler(IPostRepository postRepository, ICurrentUserService currentUser)
        {
            _postRepository = postRepository;
            _currentUser = currentUser;
        }
        public async Task<bool> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
                if (!_currentUser.IsInRole("Admin") && !_currentUser.IsInRole("Editor"))
                    throw new NotAdminOrEditorException();

            var post = await _postRepository.GetByIdAsync(request.PostId);
            if(post is null) throw new PostNotFoundException(request.PostId);

             post.UpdateTag(request.TagId, request.Name);

            await _postRepository.SaveChangesAsync();

            return true;


        }
    }
}
