using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TwitterLike.Application.Queries.GetUserTimeline
{
    public class GetUserTimelineQueryHandler : IRequestHandler<GetUserTimelineQuery, GetUserTimelineViewModel>
    {
        public Task<GetUserTimelineViewModel> Handle(GetUserTimelineQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}