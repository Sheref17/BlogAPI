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

        public DeleteTagHandler(IPostRepository postRepository) { _postRepository = postRepository; }
       
        public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            if(post is null) throw new Exception("Post not found");
            var tag = post.Tags.FirstOrDefault(t=>t.Id == request.TagId);
            if(tag is null) throw new Exception("Tag not found");
            post.RemoveTag(tag);
            await _postRepository.SaveChangesAsync();
            return true;

        }
    }
}
