using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.Application.Interfaces.Public
{
    public interface IAnimalService
    {
        Task<IEnumerable<Animale>> GetAllAsync();
        Task<Animale?> GetByIdAsync(int id);
        Task<Animale> AddAsync(Animale animal);
        Task<Animale?> UpdateAsync(Animale animal);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Animale>> GetAllByAdoption();

    }
}
