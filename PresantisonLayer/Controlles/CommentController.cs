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
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("AddComment/{postId}")]
        public async Task<IActionResult> AddComment(int postId, [FromBody] AddCommentCommand command)
        {
            command.PostId = postId;

            await _mediator.Send(command);

            return Ok("Comment Added Successfully");
        }
        [Authorize(Roles = "Admin")]
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
