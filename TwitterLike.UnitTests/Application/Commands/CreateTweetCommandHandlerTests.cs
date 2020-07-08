using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using TwitterLike.Application.Commands.CreateTweet;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;
using Xunit;

namespace TwitterLike.UnitTests.Application.Commands
{
    public class CreateTweetCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Called_ReturnViewModelWithCorrectValues() {
            // Arrange
            var fixture = new Fixture();

            var createTweetInputModel = fixture.Create<CreateTweetInputModel>();
            var userId = Guid.NewGuid();

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(ur => ur.AddTweet(userId, It.IsAny<Tweet>())).Verifiable();
            
            var createTweetCommand = new CreateTweetCommand(createTweetInputModel, userId);
            var createTweetCommandHandler = new CreateTweetCommandHandler(userRepository.Object);

            // Act
            var createTweetViewModel = await createTweetCommandHandler.Handle(createTweetCommand, new CancellationToken());

            // Assert
            Assert.NotNull(createTweetViewModel);
            Assert.Equal(createTweetInputModel.Content, createTweetViewModel.Content);
            Assert.Equal(userId, createTweetViewModel.UserId);

            userRepository.Verify(ur => ur.AddTweet(userId, It.IsAny<Tweet>()), Times.Once);
        }

        [Fact]
        public async Task ContentIsEmpty_Called_ThrowArgumentNullException() {
            // Arrange
            var createTweetInputModel = new CreateTweetInputModel {
                Content = null
            };

            var userId = Guid.NewGuid();

            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(ur => ur.AddTweet(userId, It.IsAny<Tweet>())).Verifiable();
            
            var createTweetCommand = new CreateTweetCommand(createTweetInputModel, userId);
            var createTweetCommandHandler = new CreateTweetCommandHandler(userRepository.Object);

            // Act
            Func<Task> funcHandle = () => createTweetCommandHandler.Handle(createTweetCommand, new CancellationToken());

            // Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(funcHandle);
            Assert.Equal("Content parameter is invalid.", exception.Message);
        }    
    }
}