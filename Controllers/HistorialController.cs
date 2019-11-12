using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndExamen1.Data.UnitsOfWork;
using BackEndExamen1.Models;
using BackEndExamen1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using org.mariuszgromada.math.mxparser;

namespace BackEndExamen1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;
        public HistorialController(IUnitOfWork unitOfWork, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<IActionResult> GetAll()
        {
            var historial = await _unitOfWork.Historial.GetAll();
            return Ok(historial);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Operacion>> GetOperacionById(int id)
        {
            var operacion = await _unitOfWork.Historial.GetById(id);

            if (operacion == null)
            {
                return NotFound();
            }

            return Ok(operacion);
        }

        [HttpPost]
        public async Task<ActionResult<Operacion>> PostOperacion(Operacion operacion)
        {

            await _unitOfWork.Historial.Add(operacion); 
            await _unitOfWork.Complete();
            return Ok(operacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacion(int id, Operacion operacion)
        {
            if (id != operacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(operacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Operacion>> DeleteOperacion(int id)
        {
            var operacion = await _context.Historial.FindAsync(id);

            if (operacion == null)
            {
                return NotFound();
            }

            _context.Historial.Remove(operacion);
            await _context.SaveChangesAsync();

            return operacion;
        }

    }
}