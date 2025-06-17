using API_Streaming.DTOs;
using API_Streaming.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Streaming.Context
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options) { }

        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
