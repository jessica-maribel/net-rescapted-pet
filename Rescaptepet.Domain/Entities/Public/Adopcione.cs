using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Adopcione
{
    public int IdAdopcion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdAnimal { get; set; }

    public DateTime? FechaAdopcion { get; set; }

    public string? Estado { get; set; }

    [JsonIgnore]
    public virtual Animale? IdAnimalNavigation { get; set; }
    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
