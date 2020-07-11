using System;

namespace TwitterLike.Application.Queries.GetUser
{
    public class GetUserViewModel
    {
        public GetUserViewModel(Guid userId, string name, string username, string email, int followeesCount)
        {
            UserId = userId;
            Name = name;
            Username = username;
            Email = email;
            FolloweesCount = followeesCount;
        }
        
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public int FolloweesCount { get; private set; }
    }
}