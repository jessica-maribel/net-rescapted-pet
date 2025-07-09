using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Federacione
{
    public int IdFederacion { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Responsable { get; set; }

    public virtual ICollection<AnimalFederacion> AnimalFederacions { get; set; } = new List<AnimalFederacion>();
}
