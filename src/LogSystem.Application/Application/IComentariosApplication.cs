﻿using LogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Application.Application
{
    public interface IComentariosApplication
    {
        void SalvaComentario (Comentario comentario);
    }
}
