using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.WebApps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetosApplication _projetoApplication;

        public ProjetosController(IProjetosApplication projetoApplication)
        {
            _projetoApplication = projetoApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Projeto>> GetProjetos()
        {
            var projetos = _projetoApplication.ObterTodosProjetos();
            return Ok(projetos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProjeto([FromBody] Projeto projeto)
        {
            _projetoApplication.InsereDados(projeto);
            return Ok("Projeto criado com sucesso");
        }

        [HttpDelete("{idProjeto}")]
        public async Task<IActionResult> RemoveProjeto(int idProjeto)
        {
            var temTarefasPendentes = _projetoApplication.TarefaPorProjeto(idProjeto);

            if (temTarefasPendentes)
                return BadRequest("Não foi possível remover o projeto, tarefas pendentes vinculadas");

            _projetoApplication.DesativarProjeto(idProjeto);

            return Ok("Projeto removido com sucesso!");
        }
    }
}
