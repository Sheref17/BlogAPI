using ApplicationLayer.CQRS.Blog.BlogDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Blog.Queries.GetById
{
    public class GetPostByIdQuery : IRequest<PostDetailsDto>
    {
        public int Id { get; set; }

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}

