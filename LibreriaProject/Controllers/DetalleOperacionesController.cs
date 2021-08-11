using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaProject.Data;
using LibreriaProject.Models;

namespace LibreriaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOperacionesController : ControllerBase
    {
        private readonly LibreriaAFPContext _context;

        public DetalleOperacionesController(LibreriaAFPContext context)
        {
            _context = context;
        }

        // GET: api/DetalleOperaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOperacion>>> GetDetalleOperacions()
        {
            return await _context.DetalleOperacions.ToListAsync();
        }

        // GET: api/DetalleOperaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOperacion>> GetDetalleOperacion(int id)
        {
            var detalleOperacion = await _context.DetalleOperacions.FindAsync(id);

            if (detalleOperacion == null)
            {
                return NotFound();
            }

            return detalleOperacion;
        }

        // PUT: api/DetalleOperaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleOperacion(int id, DetalleOperacion detalleOperacion)
        {
            if (id != detalleOperacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleOperacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleOperacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetalleOperaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleOperacion>> PostDetalleOperacion(DetalleOperacion detalleOperacion)
        {
            _context.DetalleOperacions.Add(detalleOperacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleOperacion", new { id = detalleOperacion.Id }, detalleOperacion);
        }

        // DELETE: api/DetalleOperaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleOperacion(int id)
        {
            var detalleOperacion = await _context.DetalleOperacions.FindAsync(id);
            if (detalleOperacion == null)
            {
                return NotFound();
            }

            _context.DetalleOperacions.Remove(detalleOperacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleOperacionExists(int id)
        {
            return _context.DetalleOperacions.Any(e => e.Id == id);
        }
    }
}
