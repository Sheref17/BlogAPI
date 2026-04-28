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

        public CreateTagHandler(IPostRepository postRepository) { _postRepository = postRepository  ; }
    

        public async Task<bool> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            if(post is null) throw new Exception("Post not found");
            var tag = new CoreLayer.Entities.Tag(request.Name, request.PostId);
            post.AddTag(tag);
            await _postRepository.SaveChangesAsync();
            return true;






        }
    }
}
