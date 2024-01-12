using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using Moq;

namespace LogSystem.Application.Tests
{
    [TestClass]
    public class ProjetoApplicationTests
    {
        [TestMethod]
        public void InsereDados_Should_Call_Repository_Method()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var projetoApplication = new ProjetoApplication(repositoryMock.Object);

            var projeto = new Projeto
            {
                Id = 1,
                Nome = "Projeto de Teste",
                CriacaoProjeto = DateTime.Now.AddDays(-7),
                Ativo = true,
                UsuarioId = 123 
            };

            // Act
            projetoApplication.InsereDados(projeto);

            // Assert
            repositoryMock.Verify(repo => repo.InsereDadosProjetos(It.IsAny<Projeto>()), Times.Once);
        }

        [TestMethod]
        public void ObterTodosProjetos_Should_Return_All_Projects_From_Repository()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var projetoApplication = new ProjetoApplication(repositoryMock.Object);

            var expectedProjects = new List<Projeto>
            {
                new Projeto
                {
                    Id = 1,
                    Nome = "Projeto A",
                    CriacaoProjeto = DateTime.Now.AddDays(-10),
                    Ativo = true,
                    UsuarioId = 101
                },
                new Projeto
                {
                    Id = 2,
                    Nome = "Projeto B",
                    CriacaoProjeto = DateTime.Now.AddDays(-5),
                    Ativo = true,
                    UsuarioId = 102
                },
                new Projeto
                {
                    Id = 3,
                    Nome = "Projeto C",
                    CriacaoProjeto = DateTime.Now.AddDays(-2),
                    Ativo = false,
                    UsuarioId = 103
                }
            };

            repositoryMock.Setup(repo => repo.ObterTodosProjetos()).Returns(expectedProjects);

            // Act
            var result = projetoApplication.ObterTodosProjetos();

            // Assert
            CollectionAssert.AreEqual(expectedProjects, result);
        }


        [TestMethod]
        public void DesativarProjeto_Should_Call_Repository_Method()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var projetoApplication = new ProjetoApplication(repositoryMock.Object);

            var idProjeto = 1; 

            // Act
            projetoApplication.DesativarProjeto(idProjeto);

            // Assert
            repositoryMock.Verify(repo => repo.DesativarProjeto(idProjeto), Times.Once);
        }
    }
}
