using Dapper;
using LogSystem.Domain.Configs;
using LogSystem.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LogSystem.Domain.Repository
{
    public class Repository : IRepository
    {
        private readonly IDapperContext _context;

        public Repository(IDapperContext context)
        {
            _context = context;
        }

        public void InsereDadosProjetos(Projeto projeto)
        {
            var query = "INSERT INTO Projeto (Nome, CriacaoProjeto, UsuarioId) VALUES (@Nome, @CriacaoProjeto, @UsuarioId)";
            var parameters = new DynamicParameters();
            parameters.Add("Nome", projeto.Nome, DbType.String);
            parameters.Add("CriacaoProjeto", projeto.CriacaoProjeto, DbType.DateTime);
            parameters.Add("UsuarioId", projeto.UsuarioId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public List<Projeto> ObterTodosProjetos()
        {
            var query = "SELECT * FROM Projeto";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Projeto>(query).ToList();
            }
        }

        public List<Tarefa> ObterTodasTarefas()
        {
            var query = "SELECT * FROM Tarefa";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Tarefa>(query).ToList();
            }
        }

        public void InsereDadosUsuario(Usuario usuario)
        {
            var query = "INSERT INTO Usuario (Nome) VALUES (@Nome)";
            var parameters = new DynamicParameters();
            parameters.Add("Nome", usuario.Nome, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void InsereDadosTarefas(Tarefa tarefa)
        {
            var query = "INSERT INTO Tarefa (Titulo, Descricao, DataVencimento, Prioridade, Status, ProjetoId) " +
                        "VALUES (@Titulo, @Descricao, @DataVencimento, @Prioridade, @Status, @ProjetoId)";
            var parameters = new DynamicParameters();
            parameters.Add("Titulo", tarefa.Titulo, DbType.String);
            parameters.Add("Descricao", tarefa.Descricao, DbType.String);
            parameters.Add("DataVencimento", tarefa.DataVencimento, DbType.DateTime);
            parameters.Add("Prioridade", (int)tarefa.Prioridade, DbType.Int32);
            parameters.Add("Status", (int)tarefa.Status, DbType.Int32);
            parameters.Add("ProjetoId", tarefa.ProjetoId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public List<Projeto> TarefaPorProjeto(int idProjeto)
        {
            var query = @"
                        SELECT p.*
                        FROM Projeto p
                        INNER JOIN Tarefa t ON p.Id = t.ProjetoId
                        WHERE p.Id = @idProjeto AND t.Status = 1";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Projeto>(query, new { idProjeto }).ToList();
            }
        }

        public void DesativarProjeto(int idProjeto)
        {
            var query = "UPDATE Projeto SET Ativo = 0 WHERE Id = @idProjeto";

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { idProjeto });
            }
        }

        public void AlterarStatusTarefa(int idTarefa, StatusTarefa statusTarefa)
        {
            var query = "UPDATE Tarefa SET Status = @statusTarefa WHERE Id = @idTarefa";

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { idTarefa, statusTarefa });
            }
        }

        public void SalvaHistorico(HistoricoRegistro historicoRegistro)
        {
            var query = "INSERT INTO Historico (Modificacao, Data, Usuario) " +
                    "VALUES (@Modificacao, @Data, @UsuarioHistorico)";
            var parameters = new DynamicParameters();
            parameters.Add("Modificacao", historicoRegistro.Modificacao, DbType.String);
            parameters.Add("Data", historicoRegistro.Data, DbType.DateTime);
            parameters.Add("UsuarioHistorico", historicoRegistro.UsuarioHistorico, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public List<Tarefa> AnaliseQuantidadeTarefas(int idProjeto)
        {
            var query = @"
                        SELECT  t.Id
                        FROM Projeto p
                        INNER JOIN Tarefa t ON p.Id = t.ProjetoId
                        WHERE p.Id = 1 ";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Tarefa>(query, new { idProjeto }).ToList();
            }
        }

        public void SalvaComentario(Comentario comentario)
        {
            var query = "INSERT INTO Comentarios (UsuarioId, Descricao, TarefaId) " +
                "VALUES (@UsuarioId, @Descricao, @TarefaId)";
            var parameters = new DynamicParameters();
            parameters.Add("UsuarioId", comentario.UsuarioId, DbType.Int32);
            parameters.Add("Descricao", comentario.Descricao, DbType.String);
            parameters.Add("TarefaId", comentario.TarefaId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
