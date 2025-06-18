using API_Streaming.Context;
using API_Streaming.DTOs;
using API_Streaming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_Streaming.Services
{
    public class GeneroService
    {
        private readonly DataBase _context;

        public GeneroService(DataBase _context)
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

        public async Task<string> AdicionarGenero(GeneroDto Dto)
        {
            if(Dto.Nome == null) throw new Exception("Nome do genero não encontrado");
            Genero genero = new Genero()
            {
                ID = Guid.NewGuid(),
                Nome = Dto.Nome
            };

            await _context.Generos.AddAsync(genero);
            await _context.SaveChangesAsync();
            return "Genero adiconado com sucesso";
        }

        public async Task<string> AtualizarGenero(GeneroDto Dto, Guid id)
        {
            Genero genero = await _context.Generos.FindAsync(id);
            if (genero == null) throw new Exception("Genero não encontrado");

            genero.Nome = Dto.Nome;

            _context.Generos.Update(genero);

            await _context.SaveChangesAsync();
            return "Genero atualizado com sucesso";
        }

        public async Task<string> DeletarGenero(Guid id)
        {
            Genero genero = await _context.Generos.FindAsync(id);
            if (genero == null) throw new Exception("Genero não encontrado");

            _context.Generos.Remove(genero);

            await _context.SaveChangesAsync();
            return "Genero deletado com sucesso";
        }
    }
}
