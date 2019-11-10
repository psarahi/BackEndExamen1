using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndExamen1.Models;

namespace BackEndExamen1.Data.Repositories
{
    public interface IHistorialRepository : IGenericRepository<Operacion>, IDisposable
    {
        
    }
}