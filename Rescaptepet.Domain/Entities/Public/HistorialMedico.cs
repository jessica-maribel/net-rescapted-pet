using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class HistorialMedico
{
    public int IdHistorial { get; set; }

    public int? IdAnimal { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Veterinario { get; set; }

    public virtual Animale? IdAnimalNavigation { get; set; }
}
