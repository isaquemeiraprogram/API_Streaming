using API_Streaming.Models;

namespace API_Streaming.DTOs
{
    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public Guid Genero { get; set; }
        public List<Guid> ArtistasIds { get; set; } = new List<Guid>();
    }
}
