using NPD.Infrastructure.Context;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace NPD.Infrastructure.RequestStash
{
    public class RequestManager : IRequestManager
    {
        private readonly NPDContext _context;

        public RequestManager(NPDContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateRequestLogForCommandAsync<T>(T request, Guid id)
        {
            var clientRequest = new ClientRequest()
            {
                Id = id,
                Name = typeof(T).Name,
                Time = DateTime.UtcNow,
                CommandJsonObj = JsonSerializer.Serialize(request)
            };

            _context.Add(request);

            await _context.SaveChangesAsync();
        }
    }
}
