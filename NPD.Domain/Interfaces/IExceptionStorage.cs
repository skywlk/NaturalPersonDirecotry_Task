using System;
using System.Threading.Tasks;

namespace NPD.Domain.Interfaces
{
    public interface IExceptionStorage
    {
        Task LogExeptionAsync(Exception exception, Guid uuid);
    }
}
