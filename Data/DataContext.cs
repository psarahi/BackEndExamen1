using Microsoft.EntityFrameworkCore;
using BackEndExamen1.Models;

namespace BackEndExamen1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Historial> Historiales { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}