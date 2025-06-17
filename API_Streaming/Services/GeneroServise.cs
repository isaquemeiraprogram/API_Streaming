using API_Streaming.Context;
using API_Streaming.DTOs;
using API_Streaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_Streaming.Services
{
    public class GeneroServise
    {
        private readonly DataBase _context;

        public GeneroServise(DataBase _context)
        {
            this._context = _context;
        }
        public async Task<List<Genero>> ObterTodosGeneros()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<Genero> ObterGeneroPorId(Guid id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null) throw new Exception("Genero não encontrado");
            return genero;
        }

        public async Task<string> AdicionarGenero([FromBody] GeneroDto Dto)
        {
            Genero genero = new Genero();

        }


    }
}
