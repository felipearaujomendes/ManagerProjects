using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriacaoProjeto { get; set; }
        public bool Ativo { get; set; }
        public int UsuarioId { get; set; }
    }
}
