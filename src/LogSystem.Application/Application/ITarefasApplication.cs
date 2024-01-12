using LogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Application.Application
{
    public interface ITarefasApplication
    {
        bool InsereDados(Tarefa tarefas);
        List<Tarefa> ObterTodasTarefas();
        void AlterarStatusTarefa(int IdTarefa, StatusTarefa StatusTarefa, int IdUsuario);
    }
}
