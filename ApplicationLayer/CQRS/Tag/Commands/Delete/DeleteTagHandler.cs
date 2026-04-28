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

namespace ApplicationLayer.CQRS.Tag.Commands.Delete
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        private readonly ICurrentUserService _currentUser;


        public DeleteTagHandler(IPostRepository postRepository, ICurrentUserService currentUser) 
        { 
            _postRepository = postRepository;
            _currentUser = currentUser;
        }
       
        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsInRole("Admin") && !_currentUser.IsInRole("Editor"))
                throw new NotAdminOrEditorException();

            var post = await _postRepository.GetByIdAsync(request.PostId);
            if(post is null) throw new PostNotFoundException(request.PostId);

            var tag = post.Tags.FirstOrDefault(t=>t.Id == request.TagId);
            if(tag is null) throw new TagNotFoundException(request.TagId);

            post.RemoveTag(tag);

            await _postRepository.SaveChangesAsync();

            return true;

        }
    }
}
