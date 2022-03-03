#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS.Server.Data;
using LMS.Shared.Models;

namespace LMS.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class TehsilsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TehsilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tehsils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tehsil>>> GetTehsils()
        {
            return await _context.Tehsils.Include(x => x.District).ToListAsync();
        }

        // GET: api/Tehsils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tehsil>> GetTehsil(int id)
        {
            var tehsil = await _context.Tehsils.FindAsync(id);

            if (tehsil == null)
            {
                return NotFound();
            }

            return tehsil;
        }

        // PUT: api/Tehsils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTehsil(int id, Tehsil tehsil)
        {
            if (id != tehsil.TehsilId)
            {
                return BadRequest();
            }

            _context.Entry(tehsil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TehsilExists(id))
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

        // POST: api/Tehsils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tehsil>> PostTehsil(Tehsil tehsil)
        {
            _context.Tehsils.Add(tehsil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTehsil", new { id = tehsil.TehsilId }, tehsil);
        }

        // DELETE: api/Tehsils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTehsil(int id)
        {
            var tehsil = await _context.Tehsils.FindAsync(id);
            if (tehsil == null)
            {
                return NotFound();
            }

            _context.Tehsils.Remove(tehsil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TehsilExists(int id)
        {
            return _context.Tehsils.Any(e => e.TehsilId == id);
        }
    }
}
