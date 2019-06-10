using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTI.VoTech.Data;
using DTI.VoTech.Models;

namespace DTI.VoTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Temas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tema>>> GetTemas()
        {
            return await _context.Temas.ToListAsync();
        }

        // GET: api/Temas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetTema(int id)
        {
            var tema = await _context.Temas.FindAsync(id);

            if (tema == null)
            {
                return NotFound();
            }

            return tema;
        }

        // PUT: api/Temas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTema(int id, Tema tema)
        {
            if (id != tema.TemaId)
            {
                return BadRequest();
            }

            _context.Entry(tema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemaExists(id))
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

        // POST: api/Temas
        [HttpPost]
        public async Task<ActionResult<Tema>> PostTema(Tema tema)
        {
            _context.Temas.Add(tema);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTema", new { id = tema.TemaId }, tema);
        }

        // DELETE: api/Temas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tema>> DeleteTema(int id)
        {
            var tema = await _context.Temas.FindAsync(id);
            if (tema == null)
            {
                return NotFound();
            }

            _context.Temas.Remove(tema);
            await _context.SaveChangesAsync();

            return tema;
        }

        private bool TemaExists(int id)
        {
            return _context.Temas.Any(e => e.TemaId == id);
        }
    }
}
