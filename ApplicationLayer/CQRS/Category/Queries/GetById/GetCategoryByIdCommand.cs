using ApplicationLayer.CQRS.Categroy.CategoryDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Queries.GetById
{
    public class GetCategoryByIdCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
