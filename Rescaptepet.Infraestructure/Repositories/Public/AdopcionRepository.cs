using Microsoft.EntityFrameworkCore;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;

namespace Rescaptepet.Infraestructure.Repositories.Public;

public class AdopcionRepository(MySqlDbContext _context) : IAdopcionRepository
{
    public async Task<Adopcione> AddAsync(Adopcione adopcione)
    {
        await _context.Adopciones.AddAsync(adopcione);
        await _context.SaveChangesAsync();
        return adopcione;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var adopcion = await _context.Animales.FindAsync(id);
        if (adopcion == null) return false;

        _context.Animales.Remove(adopcion);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }

    public async Task<IEnumerable<Adopcione>> GetAllAsync()
    {
        return await _context.Adopciones
            .AsNoTracking()
            .Include(a => a.IdAnimalNavigation)
            .Include(a => a.IdUsuarioNavigation)
            .ToListAsync();
    }

    public async Task<Adopcione?> GetByIdAsync(int id)
    {
        return await _context.Adopciones
            .AsNoTracking()
            .Include(a => a.IdAnimalNavigation)
            .FirstOrDefaultAsync(a => a.IdAnimal == id);
    }

    public async Task<Adopcione?> UpdateAsync(Adopcione adopcione)
    {
        var existing = await _context.Adopciones.FindAsync(adopcione.IdAdopcion);
        if (existing == null) return null;
        _context.Entry(existing).CurrentValues.SetValues(adopcione);
        await _context.SaveChangesAsync();
        return existing;
    }
}
