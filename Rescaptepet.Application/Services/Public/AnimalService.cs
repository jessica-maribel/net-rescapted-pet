using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;

namespace Rescaptepet.Application.Services.Public
{
    public class AnimalService(IAnimalRepository _animalRepository) : IAnimalService
    {
        public Task<Animale> AddAsync(Animale animal)
        {
            if (animal.Edad < 0) throw new Exception("invalid-age");
            return _animalRepository.AddAsync(animal);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Animale>> GetAllAsync()
        {
            return _animalRepository.GetAllAsync();
        }

        public Task<Animale?> GetByIdAsync(int id) =>
        _animalRepository.GetByIdAsync(id);

        public Task<Animale?> UpdateAsync(Animale animal)
        {
            return _animalRepository.UpdateAsync(animal);
        }
    }
}
