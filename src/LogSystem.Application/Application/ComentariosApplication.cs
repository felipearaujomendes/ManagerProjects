using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using System;

namespace LogSystem.Application.Application
{
    public class ComentariosApplication : IComentariosApplication
    {
        private readonly IRepository _repository;

        public ComentariosApplication(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void SalvaComentario(Comentario comentario)
        {
            if (comentario == null)
            {
                throw new ArgumentNullException(nameof(comentario));
            }

            _repository.SalvaComentario(comentario);

            var historico = new HistoricoRegistro
            {
                Data = DateTime.Now,
                UsuarioHistorico = comentario.UsuarioId,
                Modificacao = $"Salvo o comentário do usuário: {comentario.UsuarioId}"
            };

            _repository.SalvaHistorico(historico);
        }
    }
}
