using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class TipoAnimal
{
    public int IdTipoAnimal { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Animale> Animales { get; set; } = new List<Animale>();
}
