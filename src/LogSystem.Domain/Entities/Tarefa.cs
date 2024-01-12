using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Domain.Entities
{
    public class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Prioridade Prioridade { get; set; }
        public StatusTarefa Status { get; set; }
        public int ProjetoId { get; set; }
    }
}
