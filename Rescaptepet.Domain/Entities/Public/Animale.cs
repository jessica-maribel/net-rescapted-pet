using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Rescaptepet.Domain.Entities.Public;

public partial class Animale
{
    public int IdAnimal { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public string? Sexo { get; set; }

    public string? Color { get; set; }

    public string? Descripcion { get; set; }

    public string? EstadoSalud { get; set; }

    public string? EstadoAdopcion { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? FotoUrl { get; set; }

    public int? IdTipoAnimal { get; set; }

    public virtual ICollection<Adopcione> Adopciones { get; set; } = new List<Adopcione>();
    [JsonIgnore]
    public virtual ICollection<AnimalFederacion> AnimalFederacions { get; set; } = new List<AnimalFederacion>();
    [JsonIgnore]
    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();
    [JsonIgnore]
    public virtual TipoAnimal? IdTipoAnimalNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Padrino> Padrinos { get; set; } = new List<Padrino>();
    [JsonIgnore]
    public virtual ICollection<ReportesMejora> ReportesMejoras { get; set; } = new List<ReportesMejora>();
    [JsonIgnore]
    public virtual ICollection<TrazabilidadAnimal> TrazabilidadAnimals { get; set; } = new List<TrazabilidadAnimal>();
}
