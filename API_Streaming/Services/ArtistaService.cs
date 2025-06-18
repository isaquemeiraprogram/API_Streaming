using API_Streaming.Context;
using API_Streaming.DTOs;
using API_Streaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Streaming.Services
{
    public class ArtistaService
    {
        private readonly DataBase _context;

        public ArtistaService(DataBase _context)
        {
            this._context = _context;
        }

        public async Task<List<Artista>> ObterTodosArtistas()
        {
            return await _context.Artistas.ToListAsync();
        }

        public async Task<Artista> ObterArtistaPorId(Guid id)
        {
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null) throw new Exception("Artista não encontrado");
            return artista;
        }

        public async Task<string> AdicionarArtista(ArtistaDto Dto)
        {
            Genero genero = await _context.Generos.FindAsync(Dto.GeneroId);
            if (genero == null) throw new Exception("Genero não encontrado");

            Artista artista = new Artista()
            {
                Id = Guid.NewGuid(),
                Nome = Dto.Nome,
                Genero = genero,
                Biografia = Dto.Biografia,
            };
            await _context.Artistas.AddAsync(artista);
            await _context.SaveChangesAsync();
            return "Artista adicionado com sucesso";
        }

        public async Task<string> AtualizarArtista( ArtistaDto dto,Guid id)
        {
            Artista artista = await _context.Artistas.FindAsync(id);
            if (artista == null) throw new Exception("Artista não encontrado");

            Genero genero = await _context.Generos.FindAsync(dto.GeneroId);
            if (genero == null) throw new Exception("Genero não encontrado");


            artista.Nome = dto.Nome;
            artista.Genero = genero;
            artista.Biografia = dto.Biografia;

            await _context.SaveChangesAsync();

            return "Musica atualizada com sucesso";
        }
        
        public async Task<string> RemoverArtista(Guid id)
        {
            Artista artista = await _context.Artistas.FindAsync(id);
            if (artista == null) throw new Exception("Artista não encontrado.");

            _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();

            return "Artista Removido com sucesso";
        }
    }
}
