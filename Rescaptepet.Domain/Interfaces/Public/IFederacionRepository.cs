
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Domain.Interfaces.Public
{
    public interface IFederacionRepository
    {
        Task<IEnumerable<Federacione>> GetAllAsync();
        Task<Federacione?> GetByIdAsync(int id);
        Task<Federacione> AddAsync(Federacione federacione);
        Task<Federacione?> UpdateAsync(Federacione federacione);
        Task<Federacione> ChangeStateAsync(Federacione federacione);
    }
}
