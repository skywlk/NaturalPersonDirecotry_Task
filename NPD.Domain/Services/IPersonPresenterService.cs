using NPD.Domain.DTOs;
using System.Threading.Tasks;

namespace NPD.Domain.Services
{
    public interface IPersonPresenterService
    {
        Task<PersonDTO> GetPersonFullInfoAsync(int personId);
    }
}
