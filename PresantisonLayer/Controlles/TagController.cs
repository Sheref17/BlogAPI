using ApplicationLayer.CQRS.Tag.Commands.Create;
using ApplicationLayer.CQRS.Tag.Commands.Update;
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
    [Route("api/tag")]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpPost("AddTag")]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok("Tag Added Successfully");
           
        }
        [Authorize]
        [HttpPut("{postId}/UpdateTag/{id}")]
        public async Task<IActionResult> UpdateTag( [FromRoute] int postId, [FromRoute] int id, [FromBody] string name)
        {
            var result = await _mediator.Send(new UpdateTagCommand { PostId = postId, TagId = id , Name = name });
            if (result)
            {
                return Ok("Tag updated successfully.");
            }
            return BadRequest("Failed to update tag.");
        }
        [Authorize]
        [HttpDelete("{postId}/DeleteTag/{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int postId, [FromRoute] int id )
        {
            await _mediator.Send(new ApplicationLayer.CQRS.Tag.Commands.Delete.DeleteTagCommand { TagId = id , PostId = postId });
            return Ok("Tag Deleted Successfully");
        }


    }
}
