using ApplicationLayer.CQRS.Categroy.CategoryDtos;
using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Queries.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesCommand, IEnumerable<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        public GetAllCategoriesHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
          var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories is not null || categories.Any())
                return categories;

            return Array.Empty<CategoryDto>();
        }
    }
}
