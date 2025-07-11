using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Application.Interfaces.Public
{
    public interface IFederacionService
    {
        Task<IEnumerable<Federacione>> GetAllAsync();
        Task<Federacione?> GetByIdAsync(int id);
        Task<Federacione> AddAsync(Federacione federacione);
        Task<Federacione?> UpdateAsync(Federacione federacione);
        Task<Federacione> ChangeStateAsync(Federacione federacione);
    }
}
