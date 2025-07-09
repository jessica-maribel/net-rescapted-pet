using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class TrazabilidadAnimal
{
    public int IdTraza { get; set; }

    public int? IdAnimal { get; set; }

    public DateTime? FechaEvento { get; set; }

    public string? DescripcionEvento { get; set; }

    public string? TipoEvento { get; set; }

    public int? RegistradoPor { get; set; }

    public virtual Animale? IdAnimalNavigation { get; set; }

    public virtual Usuario? RegistradoPorNavigation { get; set; }
}
