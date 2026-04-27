using ApplicationLayer.Common;
using ApplicationLayer.CQRS.Blog.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
    public interface IPostQueryService
    {
        Task<PostDetailsDto?> GetByIdAsync(int id , int page, int pageSize);
        Task<PagedResponse<PostResponseDto>> GetAllAsync(int page, int pageSize);
    }
}
