using System;
using MediatR;

namespace TwitterLike.Application.Queries.GetUserTimeline
{
    public class GetUserTimelineQuery : IRequest<GetUserTimelineViewModel>
    {
        public GetUserTimelineQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}