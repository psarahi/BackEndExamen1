using System;

namespace BackEndExamen1.Models
{
    public class Historial
    {
        public int Id { get; set; }
        
        public string Operacion { get; set; }

        public string Resultado { get; set; }

        public DateTime Fecha { get; set; }

    }
}