using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndExamen1.Data;
using BackEndExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using org.mariuszgromada.math.mxparser;

namespace BackEndExamen1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        private readonly DataContext _context;
        public CalculadoraController(DataContext context)
        {
            _context = context;

        }

         public async Task<IActionResult> GetAll()
        {
            // var Categorias = await _context.Historiales.ToListAsync();
            // return Ok(Categorias);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Historial>> Post(Historial historial)
        {   
            Expression eh = new Expression(historial.Operacion);
            historial.Resultado = eh.calculate().ToString();
            historial.Fecha = DateTime.Today;
            _context.Historiales.Add(historial);
            await _context.SaveChangesAsync();
            return Ok(historial.Resultado);
            // return CreatedAtAction(nameof(GetHistorialById), new { id = Historial.Id }, Historial);
        }


    }
}