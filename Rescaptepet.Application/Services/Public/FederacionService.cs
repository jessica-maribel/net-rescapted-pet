
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;

namespace Rescaptepet.Application.Services.Public
{
    public class FederacionService(IFederacionRepository _federacionRepository) : IFederacionService
    {
        public Task<Federacione> AddAsync(Federacione federacione)
        {
            return _federacionRepository.AddAsync(federacione);
        }

        public Task<Federacione> ChangeStateAsync(Federacione federacione)
        {
            return _federacionRepository.ChangeStateAsync(federacione);
        }

        public Task<IEnumerable<Federacione>> GetAllAsync()
        {
            return _federacionRepository.GetAllAsync();
        }

        public Task<Federacione?> GetByIdAsync(int id)
        {
            return _federacionRepository.GetByIdAsync(id);
        }

        public Task<Federacione?> UpdateAsync(Federacione federacione)
        {
            return _federacionRepository.UpdateAsync(federacione);
        }
    }
}
