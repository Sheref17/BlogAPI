using ApplicationLayer.Common;
using ApplicationLayer.CQRS.Blog.BlogDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Queries.GetAll
{
    public class GetAllPostsQuery : IRequest<PagedResponse<PostResponseDto>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
       

    }

}
