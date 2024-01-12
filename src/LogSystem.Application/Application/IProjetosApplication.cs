using LogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Application.Application
{
    public interface IProjetosApplication
    {
        void InsereDados(Projeto apoliceSeguro);
        List<Projeto> ObterTodosProjetos();
        bool TarefaPorProjeto(int idProjeto);
        void DesativarProjeto(int idProjeto);
    }
}
