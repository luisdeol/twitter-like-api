using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TwitterLike.Core.Entities;
using TwitterLike.Core.Exceptions;
using TwitterLike.Core.Repositories;

namespace TwitterLike.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            if (user == null) {
                throw new NotFoundException(nameof(User));
            }

            var getUserViewModel = new GetUserViewModel(user.Id, user.Name, user.Username, user.Email);

            return getUserViewModel;
        }
    }
}