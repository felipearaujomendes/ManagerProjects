using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LogSystem.WebApps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InserirUsuario([FromBody] Usuario usuario)
        {
            _usuarioApplication.InsereDados(usuario);
            return Ok(null);
        }
    }
}
