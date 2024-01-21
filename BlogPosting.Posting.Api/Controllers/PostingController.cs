using BlogPosting.Posting.Application.Commands;
using BlogPosting.Posting.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogPosting.Posting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostingController : ControllerBase
    {

        private readonly IMediator _mediator;
        public PostingController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PublishPostAsync([FromBody] PublishPostCommand publishPostCommand)
        {
            PostingViewModel result = await _mediator.Send(publishPostCommand);
            return StatusCode(HttpStatusCode.Created.GetHashCode(), result);
        }
    }
}
