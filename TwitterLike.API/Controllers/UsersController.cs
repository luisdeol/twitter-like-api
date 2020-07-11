using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TwitterLike.Application.Commands.CreateTweet;
using TwitterLike.Application.Commands.DeleteTweet;
using TwitterLike.Application.Commands.FollowUser;
using TwitterLike.Application.Commands.SignUp;
using TwitterLike.Application.Queries.GetTweet;
using TwitterLike.Application.Queries.GetUser;

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

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId) {
            var getUserQuery = new GetUserQuery(userId);

            var getUserViewModel = await _mediator.Send(getUserQuery);

            if (getUserViewModel == null) {
                return NotFound();
            }

            return Ok(getUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpInputModel signUpInputModel) {
            var signUpCommand = new SignUpCommand(signUpInputModel);

            var signUpViewModel = await _mediator.Send(signUpCommand);

            return CreatedAtAction(nameof(GetUserById), new { userId = signUpViewModel.UserId }, signUpViewModel);
        }

        [HttpGet("{userId}/tweets/{tweetId}")]
        public async Task<IActionResult> GetById(Guid userId, Guid tweetId) {
            var getTweetQueryQuery = new GetTweetQuery(userId, tweetId);

            var getTweetViewModel = await _mediator.Send(getTweetQueryQuery);

            return Ok(getTweetViewModel);
        }
        
        [HttpPost("{userId}/tweets")]
        public async Task<IActionResult> Create(Guid userId, [FromBody]CreateTweetInputModel createTweetInputModel) {
            var createTweetCommand = new CreateTweetCommand(createTweetInputModel, userId);

            var createTweetViewModel = await _mediator.Send(createTweetCommand);

            return CreatedAtAction(nameof(GetById), new { userId = userId, tweetId = createTweetViewModel.Id }, createTweetViewModel);
        }

        [HttpDelete("{userId}/tweets/{tweetId}")]

        public async Task<IActionResult> Delete(Guid userId, Guid tweetId) {
            var deleteTweetCommand = new DeleteTweetCommand(userId, tweetId);

            await _mediator.Send(deleteTweetCommand);

            return NoContent();
        }

        [HttpPost("{userId}/followees")]
        public async Task<IActionResult> Follow(Guid userId, [FromBody]FollowUserInputModel followUserInputModel) {
            var followUserCommand = new FollowUserCommand(userId, followUserInputModel.FolloweeId);

            await _mediator.Send(followUserCommand);

            return NoContent();
        }
    }
}