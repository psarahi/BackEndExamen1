using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndExamen1.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndExamen1.Data.Repositories
{
    public class HistorialRepository : GenericRepository<Operacion>, IHistorialRepository
    {
        private bool disposed = false;
        private readonly DataContext _context;
        public HistorialRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)        
        {            
            if (!this.disposed)            
            {                
                if (disposing)                
                {                    
                    _context.Dispose();                
                }
            }            
            this.disposed = true;        
        }        
        
        public void Dispose()        
        {            
            Dispose(true);            
            GC.SuppressFinalize(this);        
        
        }

    }
}