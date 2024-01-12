using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;

namespace LogSystem.Application.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IRepository _repository;

        public UsuarioApplication(IRepository repository)
        {
            _repository = repository;
        }

        public void InsereDados(Usuario usuario)
        {
            _repository.InsereDadosUsuario(usuario);
        }
    }
}
