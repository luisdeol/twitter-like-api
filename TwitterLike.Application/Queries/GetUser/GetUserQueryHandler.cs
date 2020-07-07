using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TwitterLike.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserViewModel>
    {
        public Task<GetUserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetUserViewModel());
        }
    }
}