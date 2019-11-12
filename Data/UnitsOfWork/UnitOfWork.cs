using System.Threading.Tasks;
using BackEndExamen1.Data.Repositories;
using org.mariuszgromada.math.mxparser;
using BackEndExamen1.Models;
using System;

namespace BackEndExamen1.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IHistorialRepository Historial { get; }


        public UnitOfWork(DataContext context)
        {
            _context = context;
            Historial = new HistorialRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Operacion> Calculate(Operacion operacion)
        {
            Expression expresion = new Expression(operacion.expresion);
            operacion.Resultado = expresion.calculate().ToString();
            operacion.Fecha = DateTime.Today;   
            await Historial.Add(operacion);
            return operacion;
        }

        public void Dispose()
        {
            
        }
    }
}