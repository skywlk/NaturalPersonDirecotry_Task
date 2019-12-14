using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPD.Infrastructure.RequestStash
{
    public interface IRequestManager
    {
        Task CreateRequestLogForCommandAsync<T>(T request, Guid id);
    }
}
