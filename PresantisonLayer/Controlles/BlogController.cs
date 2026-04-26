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
        [HttpGet("GetAllBlogs/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { Id = id });
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetPostsQuery());
            return Ok(result);
        }
        [Authorize]
        [HttpPost("AddComment/{postId}")]
        public async Task<IActionResult> AddComment(int postId, [FromBody] AddCommentCommand command)
        {
            command.PostId = postId;

            await _mediator.Send(command);

            return Ok("Comment Added Successfully");
        }
        [Authorize]
        [HttpDelete("{postId}/Comments/{commentId}")]
        public async Task<IActionResult> DeleteComment(int postId, int commentId)
        {
            await _mediator.Send(new DeleteCommentCommand
            {
                PostId = postId,
                CommentId = commentId
            });

            return Ok("Comment Deleted Successfully");
        }

        [Authorize]
        [HttpPut("{postId}/comments/{commentId}")]
        public async Task<IActionResult> UpdateComment(int postId, int commentId, [FromBody] string content)
        {
            await _mediator.Send(new UpdateCommentCommand
            {
                PostId = postId,
                CommentId = commentId,
                Content = content
            });

            return Ok("Comment Updated Successfully");
        }
    }
}
