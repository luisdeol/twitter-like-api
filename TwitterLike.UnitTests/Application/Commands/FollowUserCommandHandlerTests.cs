using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using TwitterLike.Application.Commands.FollowUser;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Repositories;
using Xunit;

namespace TwitterLike.UnitTests.Application.Commands
{
    public class FollowUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataOk_Called_ReturnUnit() {
            // Arrange
            var userId = Guid.NewGuid();
            var fixture = new Fixture();

            var followUserInputModel = fixture.Create<FollowUserInputModel>();

            var userRepositoryMock = new Mock<IUserRepository>();
            
            var followUserCommand = new FollowUserCommand(userId, followUserInputModel.FolloweeId);

            var followUserCommandHandler = new FollowUserCommandHandler(userRepositoryMock.Object);

            // Act
            var unitValue = await followUserCommandHandler.Handle(followUserCommand, new CancellationToken());

            // Assert
            var userFollower = new UserFollower(userId, followUserInputModel.FolloweeId);

            userRepositoryMock.Verify(ur => ur.AddFollowee(userId, followUserInputModel.FolloweeId), Times.Once);
        }
    }
}