using System;

namespace TwitterLike.Core.Exceptions
{
    public class InvalidStateException : Exception
    {
        public InvalidStateException(string entity) : base($"{entity} is in an invalid state.")
        {
            
        }
    }
}