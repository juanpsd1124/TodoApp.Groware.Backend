using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Groware.Datos.Repositorios.Interfaces;

namespace TodoApp.Groware.Datos.Repositorios.Implementaciones
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITareasRepositorio Tareas { get; }

        public UnitOfWork(ITareasRepositorio tareas) 
        { 
            Tareas = tareas;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }


    }
}
