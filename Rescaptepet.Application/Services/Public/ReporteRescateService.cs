using Rescaptepet.Domain.Entities.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Microsoft.AspNetCore.Hosting;
using Rescaptepet.Application.DTOs;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Rescaptepet.Application.Interfaces.Public;

namespace Rescaptepet.Application.Services.Public
{

    public class ReporteRescateService(IHostingEnvironment _hostingEnvironment, IReporteRescateRepository _reporteRescateRepository) : IReporteRescateService
    {
        public async Task<ReporteRescate> AddAsync(ReporteRescate reporteRescate, IFormFile formFile)
        {
            string baseUrl = "https://orca-app-pechy.ondigitalocean.app";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string imagesPath = Path.Combine(webRootPath, "images");

            if (!Directory.Exists(imagesPath))
                Directory.CreateDirectory(imagesPath);

            string extension = Path.GetExtension(formFile.FileName);
            string fileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(imagesPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            reporteRescate.Foto = $"{baseUrl}/images/{fileName}";
            reporteRescate.Fecha = DateTime.Now;
            reporteRescate.Estado = reporteRescate.Estado;
            reporteRescate.Activo = true;

            return await _reporteRescateRepository.AddAsync(reporteRescate);
           
        }


        public Task<ReporteRescate> ChangeStateAsync(ReporteRescate reporteRescate)
        {
            return _reporteRescateRepository.ChangeStateAsync(reporteRescate);
        }

        public Task<IEnumerable<ReporteRescate>> GetAllAsync()
        {
            return _reporteRescateRepository.GetAllAsync();
        }

        public Task<ReporteRescate?> GetByIdAsync(int id)
        {
            return _reporteRescateRepository.GetByIdAsync(id);
        }

        public Task<ReporteRescate> GetByIdUserAsync(int idUser)
        {
            return _reporteRescateRepository.GetByIdUserAsync(idUser);
        }

        public Task<ReporteRescate?> UpdateAsync(ReporteRescate reporteRescate)
        {
            return _reporteRescateRepository.UpdateAsync(reporteRescate);
        }

    }
}
