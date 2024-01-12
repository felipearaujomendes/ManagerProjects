using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.WebApps.API.Controllers
{
    [Route("api/projetos/tarefas")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasApplication _tarefasApplication;

        public TarefasController(ITarefasApplication tarefasApplication)
        {
            _tarefasApplication = tarefasApplication;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> GetTarefas()
        {
            var tarefas = _tarefasApplication.ObterTodasTarefas();
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> InserirTarefa([FromBody] Tarefa tarefa)
        {
            var insercaoSucesso = _tarefasApplication.InsereDados(tarefa);

            if (insercaoSucesso)
                return Ok("Tarefa inserida com sucesso!");
            else
                return BadRequest("Não inserida! Já existem mais de 20 tarefas vinculadas a esse projeto!");
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarStatusTarefa(int idTarefa, StatusTarefa statusTarefa, int idUsuario)
        {
            _tarefasApplication.AlterarStatusTarefa(idTarefa, statusTarefa, idUsuario);
            return Ok(null);
        }
    }
}
