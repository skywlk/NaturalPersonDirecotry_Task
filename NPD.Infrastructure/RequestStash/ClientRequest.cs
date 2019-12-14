using System;

namespace NPD.Infrastructure.RequestStash
{
    public class ClientRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public string CommandJsonObj { get; set; }
    }
}
