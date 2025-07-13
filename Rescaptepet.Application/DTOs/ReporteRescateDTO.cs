using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Application.DTOs
{
    public class ReporteRescateDTO
    {
        public int IdUsuario { get; set; }
        public string Longitud { get; set; } = null!;
        public string Latitud { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public IFormFile Foto { get; set; } = null!;
    }
}
