using System.Text.Json.Serialization;

namespace Rescaptepet.Domain.Entities.Public;

public partial class TipoAnimal
{
    public int IdTipoAnimal { get; set; }

    public string NombreTipo { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Animale> Animales { get; set; } = new List<Animale>();
}
