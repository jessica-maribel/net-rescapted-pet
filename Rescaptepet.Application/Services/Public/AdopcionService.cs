
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;

namespace Rescaptepet.Application.Services.Public
{
    public class AdopcionService(IAdopcionRepository _adopcionRepository) : IAdopcionService
    {
        public Task<Adopcione> AddAsync(Adopcione adopcion)
        {
            return _adopcionRepository.AddAsync(adopcion);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Adopcione>> GetAllAsync()
        {
            return _adopcionRepository.GetAllAsync();
        }

        public async Task<Adopcione?> GetByIdAsync(int id)
        {
            return await _adopcionRepository.GetByIdAsync(id);
        }

        public async Task<Adopcione> UpdateAsync(Adopcione adopcion)
        {
            return await _adopcionRepository.UpdateAsync(adopcion);
        }
    }
}
