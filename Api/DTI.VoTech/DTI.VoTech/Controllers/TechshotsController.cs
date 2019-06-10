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
    public class TechshotsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TechshotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Techshot>>> GetTechshots()
        {
            return await _context.Techshots.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Techshot>> GetTechshot(int id)
        {
            var techshot = await _context.Techshots.FindAsync(id);

            if (techshot == null)
            {
                return NotFound();
            }

            return techshot;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechshot(int id, Techshot techshot)
        {
            if (id != techshot.TechshotId)
            {
                return BadRequest();
            }

            _context.Entry(techshot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechshotExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Techshot>> PostTechshot(Techshot techshot)
        {
            _context.Techshots.Add(techshot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechshot", new { id = techshot.TechshotId }, techshot);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Techshot>> DeleteTechshot(int id)
        {
            var techshot = await _context.Techshots.FindAsync(id);
            if (techshot == null)
            {
                return NotFound();
            }

            _context.Techshots.Remove(techshot);
            await _context.SaveChangesAsync();

            return techshot;
        }

        private bool TechshotExists(int id)
        {
            return _context.Techshots.Any(e => e.TechshotId == id);
        }
    }
}
