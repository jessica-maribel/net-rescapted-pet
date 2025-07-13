using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rescaptepet.Domain.Entities.Public
{
    public partial class ReporteRescate
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public string Longitud { get; set; } = null!;

        public string Latitud { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public string? Foto { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string Estado { get; set; } = null!;

        public bool? Activo { get; set; }

        [JsonIgnore]
        public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
    }
}
