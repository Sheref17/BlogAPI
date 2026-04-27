using ApplicationLayer.CQRS.Blog.Commands.Create;
using ApplicationLayer.CQRS.Blog.Commands.Delete;
using ApplicationLayer.CQRS.Blog.Commands.Update;
using ApplicationLayer.CQRS.Blog.Queries;
using ApplicationLayer.CQRS.Blog.Queries.GetAll;
using ApplicationLayer.CQRS.Blog.Queries.GetById;
using ApplicationLayer.CQRS.Comment.Commands.Create;
using ApplicationLayer.CQRS.Comment.Commands.Delete;
using ApplicationLayer.CQRS.Comment.Commands.Edit;
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
    [Route("api/blog")]
    public class BlogController : ControllerBase
    {



        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("CreateBlog")]
        public async Task<IActionResult> Create(CreatePostCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok($"Blog created successfully with ID: {id}");
        }
        [Authorize]
        [HttpPut("UpdateBlog")]
        public async Task<IActionResult> Update(UpdatePostCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok("Blog updated successfully.");
            }
            return BadRequest("Failed to update blog.");
        }

        [Authorize]
        [HttpDelete("DeleteBlog/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePostCommand { Id = id });
            return Ok("Post Deleted Successfully");
        }

        [Authorize]
        [HttpGet("GetBlogById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return Ok(result);
        }
        [Authorize]
        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetPostsQuery());
            return Ok(result);
        }
        
    }
}
