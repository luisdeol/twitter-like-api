using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TwitterLike.Application.Commands.CreateTweet;
using TwitterLike.Application.Queries.GetTweet;

namespace TwitterLike.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}/tweets/{tweetId}")]
        public async Task<IActionResult> GetById(Guid userId, Guid tweetId) {
            var getTweetQueryQuery = new GetTweetQuery(userId, tweetId);

            var getTweetViewModel = await _mediator.Send(getTweetQueryQuery);

            return Ok(getTweetViewModel);
        }
        
        [HttpPost("{userId}/tweets")]
        public async Task<IActionResult> Create(Guid userId, [FromBody]CreateTweetInputModel createTweetInputModel) {
            var createTweetCommand = new CreateTweetCommand(createTweetInputModel.Content, userId);

            var createTweetViewModel = await _mediator.Send(createTweetCommand);

            return CreatedAtAction(nameof(GetById), new { userId = userId, tweetId = createTweetViewModel.Id }, createTweetViewModel);
        }
    }
}