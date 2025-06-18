using API_Streaming.DTOs;
using API_Streaming.Models;
using API_Streaming.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_Streaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly GeneroServise _servise;

        public GeneroController(GeneroServise _servise)
        {
            this._servise = _servise;
        }


        [HttpGet]
        public async Task<List<Genero>> ObterTodosGeneros()
        {
            return await _servise.ObterTodosGeneros();
        }

        [HttpGet("{id}")]
        public async Task<Genero> ObterGeneroPorId(Guid id)
        {
            return await _servise.ObterGeneroPorId(id);
        }

        [HttpPost]
        public async Task<string> AdicionarGenero([FromBody] GeneroDto Dto)
        {
            return await _servise.AdicionarGenero(Dto);
        }

        [HttpPut("{id}")]
        public async Task<string> AtualizarGenero([FromBody] GeneroDto Dto, Guid id)
        {
            return await _servise.AtualizarGenero(Dto, id);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeletarGenero(Guid id)
        {
            return await _servise.DeletarGenero(id);
        }
    }
}
