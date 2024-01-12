using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Domain.Entities
{
    public class Comentario
    {
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
        public int TarefaId { get; set; }
    }
}
