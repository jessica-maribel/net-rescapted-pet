using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rescaptepet.Application.DTOs
{
    public class RegisterDTO
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int? IdRol { get; set; }
    }
}
