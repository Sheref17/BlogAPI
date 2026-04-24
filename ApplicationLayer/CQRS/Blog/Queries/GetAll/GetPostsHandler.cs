using ApplicationLayer.CQRS.Blog.BlogDtos;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Queries.GetAll
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, List<PostResponseDto>>
    {
        private readonly IPostQueryService _queryService;

        public GetPostsHandler(IPostQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<List<PostResponseDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _queryService.GetAllAsync();
        }
    }
}
