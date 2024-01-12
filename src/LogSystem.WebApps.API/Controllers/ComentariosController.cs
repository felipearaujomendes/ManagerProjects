using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LogSystem.WebApps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosApplication _comentariosApplication;

        public ComentariosController(IComentariosApplication comentariosApplication)
        {
            _comentariosApplication = comentariosApplication ?? throw new ArgumentNullException(nameof(comentariosApplication));
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostComentario([FromBody] Comentario comentario)
        {
            try
            {
                _comentariosApplication.SalvaComentario(comentario);
                return Ok("Comentário salvo com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o comentário: {ex.Message}");
            }
        }
    }
}
