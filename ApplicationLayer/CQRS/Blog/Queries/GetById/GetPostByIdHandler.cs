using ApplicationLayer.CQRS.Blog.BlogDtos;
using ApplicationLayer.CustomExceptions;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Queries.GetById
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, PostDetailsDto>
    {

        private readonly IPostQueryService _queryService;

        public GetPostByIdHandler(IPostQueryService queryService)
        {
            _queryService = queryService;
        }
        public async Task<PostDetailsDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _queryService.GetByIdAsync(request.Id);

            if (post == null)
                throw new PostNotFoundException("Post not found");

            return post;
        }
    }
}
