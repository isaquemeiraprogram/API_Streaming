using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using API_Streaming.Context;
using API_Streaming.DTOs;
using API_Streaming.Models;
using API_Streaming.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Streaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly MusicaService _musicServices;

        public MusicaController(MusicaService _musicServices)
        {
            this._musicServices = _musicServices;
        }

        [HttpGet]
        public async Task<List<Musica>> ObterTodasMusicas()
        {
            return await _musicServices.ObterTodasMusicas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Musica>> GetMusicByID(Guid id)
        {
            return await _musicServices.ObterMusica(id);
        }

        [HttpPost]
        public async Task<string> AdicionarMusica([FromBody] MusicaDto Dto)
        {
            return await _musicServices.AdicionarMusica(Dto);
        }


        [HttpPut("{id}")]
        public async Task<string> AtualizarMusica([FromBody] MusicaDto Dto, Guid id)
        {
            return await _musicServices.AtualizarMusica(Dto, id);
        }


        [HttpDelete("{id}")]
        public async Task<string> DeletarMusica(Guid id)
        {
            return await _musicServices.DeletarMusica(id);
        }

    }

}
