using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndExamen1.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using BackEndExamen1.Models;


namespace BackEndExamen1.Data.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
         IHistorialRepository Historial {get;}

         Task<Operacion> Calculate(Operacion operacion);

         Task<int> Complete();
    }
}