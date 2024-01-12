using LogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Domain.Repository
{
    public interface IRepository
    {
        void InsereDadosUsuario(Usuario Usuario);
        void InsereDadosProjetos(Projeto Projeto);
        void InsereDadosTarefas(Tarefa Tarefas);
        List<Projeto> ObterTodosProjetos();
        List<Tarefa> ObterTodasTarefas();
        List<Projeto> TarefaPorProjeto(int IdProjeto);
        void DesativarProjeto(int IdProjeto);
        void AlterarStatusTarefa(int idTarefa, StatusTarefa statusTarefa);
        void SalvaHistorico(HistoricoRegistro Historico);
        List<Tarefa> AnaliseQuantidadeTarefas(int IdProjeto);
        void SalvaComentario(Comentario Historico);


    }
}
