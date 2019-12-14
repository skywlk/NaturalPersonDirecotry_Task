using MediatR;
using Microsoft.Extensions.Logging;
using NPD.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.DomainEventHandlers
{
    public class PhoneNumberEddedEventHandler : INotificationHandler<PhoneNumberAddedEvent>
    {
        private readonly ILogger _logger;

        public PhoneNumberEddedEventHandler(ILogger<PhoneNumberEddedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(PhoneNumberAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{notification.Person.Firstname} added new phonenumber {notification.PhoneNumber}");
        }
    }
}
