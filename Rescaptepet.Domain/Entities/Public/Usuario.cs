using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public int? IdRol { get; set; }

    public bool? Activo { get; set; }
    public virtual ICollection<Adopcione> Adopciones { get; set; } = new List<Adopcione>();
    
    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Padrino> Padrinos { get; set; } = new List<Padrino>();

    public virtual ICollection<TrazabilidadAnimal> TrazabilidadAnimals { get; set; } = new List<TrazabilidadAnimal>();
}
