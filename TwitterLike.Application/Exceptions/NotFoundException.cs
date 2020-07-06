using System;

namespace TwitterLike.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity) : base($"{entity} was not found.")
        {
            
        }
    }
}