using Rescaptepet.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Domain.Interfaces.Public
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animale>> GetAllAsync();
        Task<Animale?> GetByIdAsync(int id);
        Task<Animale> AddAsync(Animale animal);
        Task<Animale?> UpdateAsync(Animale animal);
        Task<bool> DeleteAsync(int id);
    }
}
