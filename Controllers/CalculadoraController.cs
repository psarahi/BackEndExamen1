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
using BackEndExamen1.Data.UnitsOfWork;

namespace BackEndExamen1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CalculadoraController(DataContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> GetAll()
        {
            // var Categorias = await _context.Historiales.ToListAsync();
            // return Ok(Categorias);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Operacion>> Post(Operacion operacion)
        {
            // Expression eh = new Expression(operacion.expresion);
            // operacion.Resultado = eh.calculate().ToString();
            // operacion.Fecha = DateTime.Today;
            // _context.Historial.Add(operacion);
            // await _context.SaveChangesAsync();
            Operacion _result = await _unitOfWork.Calculate(operacion);
            _unitOfWork.Complete();
            return Ok(_result.Resultado);
            // return CreatedAtAction(nameof(GetHistorialById), new { id = Historial.Id }, Historial);
        }


    }
}