
using Microsoft.EntityFrameworkCore;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;

namespace Rescaptepet.Infraestructure.Repositories.Public
{
    public class FederacionRepository(MySqlDbContext _context) : IFederacionRepository
    {
        public async Task<Federacione> AddAsync(Federacione federacione)
        {
            await _context.Federaciones.AddAsync(federacione);
            await _context.SaveChangesAsync();
            return federacione;
        }

        public async Task<Federacione> ChangeStateAsync(Federacione federacione)
        {
            Federacione finded = await _context.Federaciones
                .FirstAsync(c => c.IdFederacion == federacione.IdFederacion);

            finded.Activo = federacione.Activo;

            await _context.SaveChangesAsync();
            return finded;
        }

        public async Task<IEnumerable<Federacione>> GetAllAsync()
        {
            return await _context.Federaciones
                .AsNoTracking()
                //.Include(f => f.AnimalFederacions)
                .ToListAsync();
        }

        public async Task<Federacione?> GetByIdAsync(int id)
        {
            return await _context.Federaciones
                .AsNoTracking()
                .Include(f => f.AnimalFederacions)
                .FirstOrDefaultAsync(f => f.IdFederacion == id);
        }

        public async Task<Federacione?> UpdateAsync(Federacione federacione)
        {
            var existing = await _context.Federaciones.FindAsync(federacione.IdFederacion);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(federacione);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
