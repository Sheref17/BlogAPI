using ApplicationLayer.CQRS.Categroy.CategoryDtos;
using ApplicationLayer.CQRS.Categroy.Commands.Create;
using ApplicationLayer.CQRS.Categroy.Commands.Delete;
using ApplicationLayer.CQRS.Categroy.Commands.Update;
using ApplicationLayer.CQRS.Categroy.Queries.GetAll;
using ApplicationLayer.CQRS.Categroy.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresantisonLayer.Controlles
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok("Category created successfully");
        }
        [Authorize]
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok("Category updated successfully.");
            }
            return BadRequest("Failed to update category.");
        }
        [Authorize]
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return Ok("Category Deleted Successfully");

        }
        [Authorize]
        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesCommand());
            return categories;
        }
        [Authorize]
        [HttpGet("GetCategoryById/{id}")]
        public async Task<CategoryDto> GetCategoryById([FromRoute] int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdCommand { Id = id });
            return category;
        }
    }
}
