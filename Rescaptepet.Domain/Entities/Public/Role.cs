using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Role
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    
    public virtual ICollection<Permiso> IdPermisos { get; set; } = new List<Permiso>();
}
