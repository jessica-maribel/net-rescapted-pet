using Rescaptepet.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Domain.Interfaces.Public
{
    public interface IReporteRescateRepository
    {
        Task<IEnumerable<ReporteRescate>> GetAllAsync();
        Task<ReporteRescate?> GetByIdAsync(int id);
        Task<ReporteRescate> AddAsync(ReporteRescate reporteRescate);
        Task<ReporteRescate?> UpdateAsync(ReporteRescate reporteRescate);
        Task<ReporteRescate> ChangeStateAsync(ReporteRescate reporteRescate);
        Task<ReporteRescate> GetByIdUserAsync(int idUser);
    }
}
