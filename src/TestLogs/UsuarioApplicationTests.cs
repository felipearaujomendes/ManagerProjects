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
    public class UsuarioApplicationTests
    {
        [TestMethod]
        public void InsereDados_Should_Call_Repository_Method()
        {
            var repositoryMock = new Mock<IRepository>();
            var usuarioApplication = new UsuarioApplication(repositoryMock.Object);

            var usuario = new Usuario
            {
                Nome = "João Silva"
            };

            // Act
            usuarioApplication.InsereDados(usuario);

            // Assert
            repositoryMock.Verify(repo => repo.InsereDadosUsuario(It.IsAny<Usuario>()), Times.Once);
        }
    }
}