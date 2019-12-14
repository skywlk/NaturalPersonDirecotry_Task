using MediatR;
using System;

namespace NPD.API.Application.Commands
{
    public class DispatcherCommand<T, R> : IRequest<R> where T : IRequest<R>
    {
        public T Command { get; }
        public Guid Id { get; }
        public DispatcherCommand(T command)
        {
            Command = command;
            Id = Guid.NewGuid();
        }
    }
}
