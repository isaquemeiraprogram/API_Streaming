using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Streaming.Models
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public Genero Genero { get; set; }
        public ICollection<Artista> Artistas { get; set; } = new List<Artista>();

        public Musica()
        {
            
        }

    }
}
