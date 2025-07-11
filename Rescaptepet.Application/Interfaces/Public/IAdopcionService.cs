using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Application.Interfaces.Public
{
    public interface IAdopcionService
    {
        Task<IEnumerable<Adopcione>> GetAllAsync();
        Task<Adopcione> GetByIdAsync(int id);
        Task<Adopcione> AddAsync(Adopcione adopciones);
        Task<Adopcione> UpdateAsync(Adopcione adopciones);
        Task<bool> DeleteAsync(int id);

    }
}
