using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using API_Streaming.Context;
using API_Streaming.DTOs;
using API_Streaming.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Streaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly DataBase _context;

        public MusicaController(DataBase _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<List<Musica>> ObterTodasMusicas()
        {
            return (await _context.Musicas.Include(m => m.Genero).Include(m => m.Artistas).ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Musica>> ObterMusica(Guid id)
        {

            Musica musica = await _context.Musicas
                 .Include(m => m.Artistas)
                 .Include(m => m.Genero)
                 .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(musica);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AdicionarMusica([FromBody] MusicaDto Dto)
        {
             var art = await _context.Artistas
                    .Where(a => Dto.ArtistasIds
                    .Contains(a.Id))
                    .ToListAsync();

            var genero = await _context.Generos.FindAsync(Dto.Genero);

            Musica musica = new Musica()
            {
                Id = Dto.Id,
                Titulo = Dto.Titulo,
                Duracao = Dto.Duracao,
                Genero = Dto.Genero,
                Artistas = art
            };
            
            await _context.Musicas.AddAsync(musica);
            await _context.SaveChangesAsync();
            return Ok("musica adicionada com sucesso");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<string>> AtualizarMusica([FromBody] MusicaDto Dto, Guid id)
        {
            Musica musica = await _context.Musicas.FindAsync(id);

            Musica musica1 = new Musica();

            musica.Id = Dto.Id;
            musica.Titulo = Dto.Titulo;

            return Ok();
        }
    }

}
