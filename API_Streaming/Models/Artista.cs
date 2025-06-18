using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace API_Streaming.Models
{
    public class Artista
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Genero Genero { get; set; }
        public string Biografia { get; set; }

        [JsonIgnore]
        public ICollection<Musica> Musicas { get; set; } = new List<Musica>();


    }
}
