﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Groware.Datos.Repositorios.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITareasRepositorio Tareas { get; }

    }
}
