using API_Streaming.Models;
using System.Text.Json.Serialization;

namespace API_Streaming.DTOs
{
    public class ArtistaDto
    {
        public string Nome { get; set; }
        public string Biografia { get; set; }
        public Guid GeneroId { get; set; }
        public List<Guid> Musicas { get; set; } = new List<Guid>();
    }
}
