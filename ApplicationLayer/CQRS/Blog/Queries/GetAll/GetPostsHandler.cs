using ApplicationLayer.Common;
using ApplicationLayer.CQRS.Blog.BlogDtos;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApplicationLayer.CQRS.Blog.Queries.GetAll
{
    public class GetPostsHandler : IRequestHandler<GetAllPostsQuery, PagedResponse<PostResponseDto>>
    {
        private readonly IPostQueryService _queryService;

        public GetPostsHandler(IPostQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<PagedResponse<PostResponseDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            if(request.Page <=0 ) request.Page = 1;
            if(request.PageSize <= 0 || request.PageSize > 5) request.PageSize = 5;
      
            var posts = await _queryService.GetAllAsync(request.Page, request.PageSize);
        
            return posts;
        }
    }
}
