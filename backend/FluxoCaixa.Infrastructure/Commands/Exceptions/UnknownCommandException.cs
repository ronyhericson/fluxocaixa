using System;

namespace FluxoCaixa.Infrastructure.Commands.Exceptions
{
    public class UnknownCommandException : Exception
    {
        public UnknownCommandException(string message) : base(message) { }
    } 
}