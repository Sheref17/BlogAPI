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

        public UpdateTagHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.PostId);
            if(post is null) throw new Exception("Post not found");
             post.UpdateTag(request.TagId, request.Name);
            await _postRepository.SaveChangesAsync();
            return true;


        }
    }
}
