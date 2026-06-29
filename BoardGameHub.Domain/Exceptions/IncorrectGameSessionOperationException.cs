using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameHub.Domain.Exceptions
{
    public class IncorrectGameSessionOperationException : DomainException
    {
        public IncorrectGameSessionOperationException(string? message) : base(message)
        {
        }
    }
}
