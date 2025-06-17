using API_Streaming.Context;
using API_Streaming.DTOs;
using API_Streaming.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_Streaming.Services
{
    public class MusicaService
    {
        private readonly DataBase _context;

        public MusicaService(DataBase _context)
        {
            this._context = _context;
        }

        public async Task<List<Musica>> ObterTodasMusicas()
        {
            return await _context.Musicas.Include(m => m.Genero).Include(m => m.Artistas).ToListAsync();
        }

        public async Task<ActionResult<Musica>> ObterMusica(Guid id)
        {

            Musica musica = await _context.Musicas
                 .Include(m => m.Artistas)
                 .Include(m => m.Genero)
                 .FirstAsync(m => m.Id == id);

            return musica;
        }

        public async Task<string> AdicionarMusica([FromBody] MusicaDto Dto)
        {
            Genero genero = await _context.Generos.FindAsync(Dto.Genero);
            if (genero == null) throw new Exception ("Genero Não registrado");

            List<Artista> art = await _context.Artistas
                   .Where(a => Dto.ArtistasIds
                   .Contains(a.Id))
                   .ToListAsync();


            Musica musica = new Musica()
            {
                Titulo = Dto.Titulo,
                Duracao = Dto.Duracao,
                Genero = genero,
                Artistas = art
            };

            await _context.Musicas.AddAsync(musica);
            await _context.SaveChangesAsync();
            return "musica adicionada com sucesso";
        }

        public async Task<string> AtualizarMusica([FromBody] MusicaDto Dto, Guid id)
        {
            Musica musica = await _context.Musicas.FindAsync(id);

            Genero genero = await _context.Generos.FindAsync(id);
            if (genero == null) throw new Exception("Genero Não registrado");

            List<Artista> art = await _context.Artistas
                .Where(a => Dto.ArtistasIds
                .Contains(a.Id)).ToListAsync();


            musica.Titulo = Dto.Titulo;
            musica.Duracao = Dto.Duracao;
            musica.Genero = genero;
            musica.Artistas = art;

            await _context.SaveChangesAsync();

            return "Musica Atualizado com sucesso";
        }

        public async Task<string> DeletarMusica(Guid id)
        {
            Musica musica = await _context.Musicas.FindAsync(id);
            if (musica == null) throw new Exception("Musica não encontrada");

            _context.Musicas.Remove(musica);
            await _context.SaveChangesAsync();

            return "Musica deletada com sucesso";
        }
    }
}
