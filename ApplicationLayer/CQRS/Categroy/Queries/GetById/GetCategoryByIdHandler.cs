using ApplicationLayer.CQRS.Categroy.CategoryDtos;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Queries.GetById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdHandler(ICategoryService categoryService)
        {
          _categoryService = categoryService;
        }
        public async Task<CategoryDto> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            if (category is null)
                throw new Exception("Category not found");
            return category;

    
          

        }
    }
}
