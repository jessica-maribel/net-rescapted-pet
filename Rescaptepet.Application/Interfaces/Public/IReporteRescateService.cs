using Microsoft.AspNetCore.Http;
using Rescaptepet.Domain.Entities.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Application.Interfaces.Public
{
    public interface IReporteRescateService
    {
        Task<IEnumerable<ReporteRescate>> GetAllAsync();
        Task<ReporteRescate?> GetByIdAsync(int id);
        Task<ReporteRescate> AddAsync(ReporteRescate reporteRescate);
        Task<ReporteRescate?> UpdateAsync(ReporteRescate reporteRescate);
        Task<ReporteRescate> ChangeStateAsync(ReporteRescate reporteRescate);
        Task<IEnumerable<ReporteRescate>> GetByIdUserAsync(int idUser);
    }
}
