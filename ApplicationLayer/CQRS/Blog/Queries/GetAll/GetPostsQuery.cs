using ApplicationLayer.CQRS.Blog.BlogDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Queries.GetAll
{
    public class GetPostsQuery : IRequest<List<PostResponseDto>>
    {
    }

}
