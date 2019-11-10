using System;

namespace BackEndExamen1.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        
        public string expresion { get; set; }

        public string Resultado { get; set; }

        public DateTime Fecha { get; set; }

    }
}