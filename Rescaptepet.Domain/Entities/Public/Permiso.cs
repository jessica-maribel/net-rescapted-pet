using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string? NombrePermiso { get; set; }

    
    public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}
