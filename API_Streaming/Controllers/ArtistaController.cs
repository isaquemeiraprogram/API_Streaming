using API_Streaming.DTOs;
using API_Streaming.Models;
using API_Streaming.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Streaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {

        private readonly ArtistaService _service;

        public ArtistaController(ArtistaService _service)
        {
            this._service = _service;
        }

        [HttpGet]
        public async Task<List<Artista>> ObterTodosArtistas()
        {
            return await _service.ObterTodosArtistas();
        }

        [HttpGet("{id}")]
        public async Task<Artista> ObterArtistaPorId(Guid id)
        {
            return await _service.ObterArtistaPorId(id);
        }

        [HttpPost]
        public async Task<string> AdicionarArtista(ArtistaDto Dto)
        {
            return await _service.AdicionarArtista(Dto);
        }

        [HttpPut("{id}")]
        public async Task<string> AtualizarArtista([FromBody] ArtistaDto dto, Guid id)
        {
            return await _service.AtualizarArtista(dto,id);
        }

        [HttpDelete("{id}")]
        public async Task<string> RemoverArtista(Guid id)
        {
            return await _service.RemoverArtista(id);
        }
    }
}
