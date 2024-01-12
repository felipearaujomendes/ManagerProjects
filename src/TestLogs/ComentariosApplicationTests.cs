using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using Moq;


namespace TestLogs
{
    [TestClass]
    public class ComentariosApplicationTests
    {
        [TestMethod]
        public void SalvaComentario_Should_Save_Comment_And_History()
        {
            var repositoryMock = new Mock<IRepository>();
            var comentariosApplication = new ComentariosApplication(repositoryMock.Object);

            var comentario = new Comentario
            {
                UsuarioId = 1,
            };

            // Act
            comentariosApplication.SalvaComentario(comentario);

            // Assert
            repositoryMock.Verify(repo => repo.SalvaComentario(It.Is<Comentario>(c => c.UsuarioId == 1)), Times.Once);

            repositoryMock.Verify(repo => repo.SalvaHistorico(It.IsAny<HistoricoRegistro>()), Times.Once);
        }
    }
}