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
        public int Page { get; set; } 
        public int PageSize { get; set; } 
        public string? Title { get; set; }
        public string? Tag { get; set; }
        public int? CategoryId { get; set; }

        public string? Status { get; set; }


    }

}
