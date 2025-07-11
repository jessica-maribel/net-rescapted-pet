using Microsoft.EntityFrameworkCore;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;

namespace Rescaptepet.Infraestrucutre.Repositories.Public;

public class AnimalRepository(MySqlDbContext _context) : IAnimalRepository
{
    public async Task<IEnumerable<Animale>> GetAllAsync()
    {
        return await _context.Animales
            .AsNoTracking()
            .Include(a => a.IdTipoAnimalNavigation)
            .Include(a => a.Adopciones)
            .ToListAsync();
    }

    public async Task<Animale?> GetByIdAsync(int id)
    {
        return await _context.Animales
            .AsNoTracking()
            .Include(a => a.IdTipoAnimalNavigation)//add include adopciones
            .FirstOrDefaultAsync(a=> a.IdAnimal == id);
    }

    public async Task<Animale> AddAsync(Animale animal)
    {
        await _context.Animales.AddAsync(animal);
        await _context.SaveChangesAsync();
        return animal;
    }

    public async Task<Animale?> UpdateAsync(Animale animal)
    {
        var existing = await _context.Animales.FindAsync(animal.IdAnimal);
        if (existing == null) return null;

        _context.Entry(existing).CurrentValues.SetValues(animal);
        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var animal = await _context.Animales.FindAsync(id);
        if (animal == null) return false;

        _context.Animales.Remove(animal);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
}

