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
    public class OperacionesController : ControllerBase
    {
        private readonly LibreriaAFPContext _context;

        public OperacionesController(LibreriaAFPContext context)
        {
            _context = context;
        }

        // GET: api/Operaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacione>>> GetOperaciones()
        {
            return await _context.Operaciones.ToListAsync();
        }

        // GET: api/Operaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operacione>> GetOperacione(int id)
        {
            var operacione = await _context.Operaciones.FindAsync(id);

            if (operacione == null)
            {
                return NotFound();
            }

            return operacione;
        }

        // PUT: api/Operaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacione(int id, Operacione operacione)
        {
            if (id != operacione.Id)
            {
                return BadRequest();
            }

            _context.Entry(operacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacioneExists(id))
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

        // POST: api/Operaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operacione>> PostOperacione(Operacione operacione)
        {
            _context.Operaciones.Add(operacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacione", new { id = operacione.Id }, operacione);
        }

        // DELETE: api/Operaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperacione(int id)
        {
            var operacione = await _context.Operaciones.FindAsync(id);
            if (operacione == null)
            {
                return NotFound();
            }

            _context.Operaciones.Remove(operacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperacioneExists(int id)
        {
            return _context.Operaciones.Any(e => e.Id == id);
        }
    }
}
