using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Domain.Entities
{
    public class HistoricoRegistro
    {
        public string Modificacao { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioHistorico { get; set; }
    }
}
