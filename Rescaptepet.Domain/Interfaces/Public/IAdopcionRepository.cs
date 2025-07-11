
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Domain.Interfaces.Public
{
    public interface IAdopcionRepository
    {
        Task<IEnumerable<Adopcione>> GetAllAsync();
        Task<Adopcione?> GetByIdAsync(int id);
        Task<Adopcione> AddAsync(Adopcione adopcione);
        Task<Adopcione?> UpdateAsync(Adopcione adopcione);
        Task<bool> DeleteAsync(int id);
    }
}
