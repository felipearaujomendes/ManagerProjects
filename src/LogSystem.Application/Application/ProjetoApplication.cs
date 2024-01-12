using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using System;
using System.Collections.Generic;

namespace LogSystem.Application.Application
{
    public class ProjetoApplication : IProjetosApplication
    {
        private readonly IRepository _repository;

        public ProjetoApplication(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void InsereDados(Projeto projeto)
        {
            _repository.InsereDadosProjetos(projeto);
        }

        public List<Projeto> ObterTodosProjetos()
        {
            return _repository.ObterTodosProjetos();
        }

        public bool TarefaPorProjeto(int idProjeto)
        {
            var tarefasCount = _repository.TarefaPorProjeto(idProjeto).Count;
            return tarefasCount == 0;
        }

        public void DesativarProjeto(int idProjeto)
        {
            _repository.DesativarProjeto(idProjeto);
        }
    }
}
