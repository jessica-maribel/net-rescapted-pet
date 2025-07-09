using System;
using System.Collections.Generic;

namespace Rescaptepet.Domain.Entities.Public;

public partial class ReportesMejora
{
    public int IdReporte { get; set; }

    public int? IdAnimal { get; set; }

    public DateTime? Fecha { get; set; }

    public string? EvaluacionGeneral { get; set; }

    public string? EstadoAnimo { get; set; }

    public string? Comportamiento { get; set; }

    public string? Recomendaciones { get; set; }

    public virtual Animale? IdAnimalNavigation { get; set; }
}
