using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class AnimalFederacion
{
    public int IdAnimalFed { get; set; }

    public int? IdAnimal { get; set; }

    public int? IdFederacion { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaSalida { get; set; }

    public string? Observaciones { get; set; }

    public virtual Animale? IdAnimalNavigation { get; set; }

    public virtual Federacione? IdFederacionNavigation { get; set; }
}
