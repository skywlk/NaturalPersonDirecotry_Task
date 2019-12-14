using MediatR;
using NPD.Infrastructure.RequestStash;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class DispatcherCommandHandler<T, R> : IRequestHandler<DispatcherCommand<T, R>, R> where T : IRequest<R>
    {
        private readonly IMediator _mediator;
        private readonly IRequestManager _requestManager;

        public DispatcherCommandHandler(IMediator mediator, IRequestManager requestManager)
        {
            _mediator = mediator;
            _requestManager = requestManager;
        }

        //This handler should log recived request to database and then send it again for hendling
        public async Task<R> Handle(DispatcherCommand<T, R> request, CancellationToken cancellationToken)
        {
            await _requestManager.CreateRequestLogForCommandAsync(request.Command, request.Id);
            try
            {
                var result = await _mediator.Send(request.Command);
                return result;
            }
            catch
            {
                return default;
            }
        }
    }
}
