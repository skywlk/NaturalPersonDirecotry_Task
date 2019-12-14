using NPD.Domain.Common;
using System.Threading.Tasks;

namespace NPD.Domain.Interfaces
{
    public interface IRepository<T> where T : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> FindByIdAsync(int Id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
