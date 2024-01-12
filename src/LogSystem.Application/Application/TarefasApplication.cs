using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using System;
using System.Collections.Generic;

namespace LogSystem.Application.Application
{
    public class TarefasApplication : ITarefasApplication
    {
        private readonly IRepository _repository;

        public TarefasApplication(IRepository repository)
        {
            _repository = repository;
        }
        public bool InsereDados(Tarefa tarefa)
        {
            var quantidadeTarefa = _repository.AnaliseQuantidadeTarefas(tarefa.ProjetoId).Count;

            if (quantidadeTarefa <= 20)
            {
                _repository.InsereDadosTarefas(tarefa);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Tarefa> ObterTodasTarefas()
        {
            return _repository.ObterTodasTarefas();
        }

        public void AlterarStatusTarefa(int idTarefa, StatusTarefa statusTarefa, int idUsuario)
        {
            _repository.AlterarStatusTarefa(idTarefa, statusTarefa);

            var historico = new HistoricoRegistro
            {
                Data = DateTime.Now,
                UsuarioHistorico = idUsuario,
                Modificacao = $"Alteração de status da tarefa, status: {statusTarefa}"
            };

            _repository.SalvaHistorico(historico);
        }
    }
}
