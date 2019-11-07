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
    public class HistorialController : ControllerBase
    {

        private readonly DataContext _context;
        public HistorialController(DataContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> GetAll()
        {
            // var Categorias = await _context.Historiales.ToListAsync();
            // return Ok(Categorias);
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorialById(int id)
        {
            var Historial = await _context.Historiales.FindAsync(id);

            if (Historial == null)
            {
                return NotFound();
            }

            return Historial;
        }

        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(Historial Historial)
        {
            _context.Historiales.Add(Historial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHistorialById), new { id = Historial.Id }, Historial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(int id, Historial Historial)
        {
            if (id != Historial.Id)
            {
                return BadRequest();
            }

            _context.Entry(Historial).State = EntityState.Modified;

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
        public async Task<ActionResult<Historial>> DeleteHistorial(int id)
        {
            var Historial = await _context.Historiales.FindAsync(id);

            if (Historial == null)
            {
                return NotFound();
            }

            _context.Historiales.Remove(Historial);
            await _context.SaveChangesAsync();

            return Historial;
        }

    }
}