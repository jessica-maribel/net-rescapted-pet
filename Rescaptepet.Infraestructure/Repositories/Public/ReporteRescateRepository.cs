using Microsoft.EntityFrameworkCore;
using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;

namespace Rescaptepet.Infraestructure.Repositories.Public
{
    public class ReporteRescateRepository(MySqlDbContext _context) : IReporteRescateRepository
    {
        public async Task<ReporteRescate> AddAsync(ReporteRescate reporteRescate)
        {
            await _context.ReporteRescates.AddAsync(reporteRescate);
            await _context.SaveChangesAsync();
            return reporteRescate;
        }

        public async Task<ReporteRescate> ChangeStateAsync(ReporteRescate reporteRescate)
        {
            ReporteRescate finded = await _context.ReporteRescates
                .FirstAsync(r => r.Id == reporteRescate.Id);

            finded.Activo = reporteRescate.Activo;

            await _context.SaveChangesAsync();
            return finded;
        }

        public async Task<IEnumerable<ReporteRescate>> GetAllAsync()
        {
            return await _context.ReporteRescates
                .AsNoTracking()
                .Where(r => r.Activo == true)
                .ToListAsync();
        }

        public async Task<ReporteRescate?> GetByIdAsync(int id)
        {
            return await _context.ReporteRescates
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.IdUsuario == id);
        }

        public async Task<IEnumerable<ReporteRescate>> GetByIdUserAsync(int idUser)
        {
            return await _context.ReporteRescates
                .AsNoTracking()
                .Where(r => r.IdUsuario == idUser)
                .ToListAsync();
        }

        public async Task<ReporteRescate?> UpdateAsync(ReporteRescate reporteRescate)
        {
            var existing = await _context.ReporteRescates.FindAsync(reporteRescate.Id);
            if (existing == null) return null; 
            _context.Entry(existing).CurrentValues.SetValues(reporteRescate);
            await _context.SaveChangesAsync();
            return existing;
        }

 
    }
}
