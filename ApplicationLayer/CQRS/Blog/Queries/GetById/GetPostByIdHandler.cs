using ApplicationLayer.CQRS.Blog.BlogDtos;
using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
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
        private readonly ICurrentUserService _currentUser;

        public GetPostByIdHandler(IPostQueryService queryService , ICurrentUserService currentUser)
        {
            _queryService = queryService;
            _currentUser = currentUser;
        }
        public async Task<PostDetailsDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.Page <= 0) request.Page = 1;
            if (request.PageSize <= 0 || request.PageSize > 5) request.PageSize = 5;

            var canViewAllStatuses =_currentUser.IsInRole("Admin") || _currentUser.IsInRole("Editor");
            var post = await _queryService.GetByIdAsync(request.Id ,request.Page ,request.PageSize , canViewAllStatuses);

            if (post == null)
                throw new PostNotFoundException(request.Id);

            return post;
        }
    }
}
