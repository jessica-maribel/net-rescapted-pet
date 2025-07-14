using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Domain.Interfaces.Public
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animale>> GetAllAsync();
        Task<Animale?> GetByIdAsync(int id);
        Task<Animale> AddAsync(Animale animal);
        Task<Animale?> UpdateAsync(Animale animal);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Animale>> GetAllByAdoption();
    }
}
