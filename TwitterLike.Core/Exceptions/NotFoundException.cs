using System;

namespace TwitterLike.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity) : base($"{entity} was not found.")
        {
            
        }
    }
}