using System;
using System.Threading.Tasks;
using FluxoCaixa.Infrastructure.Commands.Exceptions;
using FluxoCaixa.Infrastructure.Commands.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infrastructure.Commands
{
    public class CommandsProcessor : ICommandsProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandsProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public Task Process<TCommand>(TCommand command)
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new UnknownCommandException($"Handler for command \"{command.GetType().Name}\" not found.");

            return handler.Execute(command);
        }
    }
}