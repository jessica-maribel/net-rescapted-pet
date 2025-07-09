using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Padrino
{
    public int IdPadrino { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdAnimal { get; set; }

    public string? TipoApadrinamiento { get; set; }

    public string? DescripcionAporte { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual Animale? IdAnimalNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
