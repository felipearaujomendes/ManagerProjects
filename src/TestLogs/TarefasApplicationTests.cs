using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace LogSystem.Application.Tests
{
    [TestClass]
    public class TarefasApplicationTests
    {
        [TestMethod]
        public void InsereDados_Should_Insert_Task_When_Quantity_Less_Than_Or_Equal_To_20()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var tarefasApplication = new TarefasApplication(repositoryMock.Object);

            var projetoId = 1;
            var tarefa = new Tarefa
            {
                ProjetoId = projetoId,
            };

            repositoryMock.Setup(repo => repo.AnaliseQuantidadeTarefas(projetoId)).Returns(new List<Tarefa>(15));

            // Act
            var result = tarefasApplication.InsereDados(tarefa);

            // Assert
            Assert.IsTrue(result);
            repositoryMock.Verify(repo => repo.InsereDadosTarefas(It.IsAny<Tarefa>()), Times.Once);
        }

        [TestMethod]
        public void ObterTodasTarefas_Should_Return_All_Tasks_From_Repository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var tarefasApplication = new TarefasApplication(repositoryMock.Object);

            var expectedTasks = new List<Tarefa>
            {
                new Tarefa
                {
                    Titulo = "Tarefa 1",
                    Descricao = "Descrição da Tarefa 1",
                    DataVencimento = DateTime.Now.AddDays(7),
                    Prioridade = Prioridade.Alta,
                    Status = StatusTarefa.Pendente,
                    ProjetoId = 1
                },
                new Tarefa
                {
                    Titulo = "Tarefa 2",
                    Descricao = "Descrição da Tarefa 2",
                    DataVencimento = DateTime.Now.AddDays(14),
                    Prioridade = Prioridade.Media,
                    Status = StatusTarefa.EmAndamento,
                    ProjetoId = 2
                },
                new Tarefa
                {
                    Titulo = "Tarefa 3",
                    Descricao = "Descrição da Tarefa 3",
                    DataVencimento = DateTime.Now.AddDays(21),
                    Prioridade = Prioridade.Baixa,
                    Status = StatusTarefa.Concluida,
                    ProjetoId = 1
                }
            };

            repositoryMock.Setup(repo => repo.ObterTodasTarefas()).Returns(expectedTasks);

            // Act
            var result = tarefasApplication.ObterTodasTarefas();

            // Assert
            CollectionAssert.AreEqual(expectedTasks, result);
        }

        [TestMethod]
        public void AlterarStatusTarefa_Should_Call_Repository_Method_And_Save_History()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var tarefasApplication = new TarefasApplication(repositoryMock.Object);

            var idTarefa = 1; 
            var statusTarefa = StatusTarefa.Concluida; 
            var idUsuario = 123;

            // Act
            tarefasApplication.AlterarStatusTarefa(idTarefa, statusTarefa, idUsuario);

            // Assert
            repositoryMock.Verify(repo => repo.AlterarStatusTarefa(idTarefa, statusTarefa), Times.Once);

            repositoryMock.Verify(repo => repo.SalvaHistorico(It.IsAny<HistoricoRegistro>()), Times.Once);
        }
    }
}
