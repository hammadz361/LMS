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
    public class SchoolLevelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolLevel>>> GetSchoolLevels()
        {
            return await _context.SchoolLevels.ToListAsync();
        }

        // GET: api/SchoolLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolLevel>> GetSchoolLevel(int id)
        {
            var schoolLevel = await _context.SchoolLevels.FindAsync(id);

            if (schoolLevel == null)
            {
                return NotFound();
            }

            return schoolLevel;
        }

        // PUT: api/SchoolLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolLevel(int id, SchoolLevel schoolLevel)
        {
            if (id != schoolLevel.SchoolLevelId)
            {
                return BadRequest();
            }

            _context.Entry(schoolLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolLevelExists(id))
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

        // POST: api/SchoolLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolLevel>> PostSchoolLevel(SchoolLevel schoolLevel)
        {
            _context.SchoolLevels.Add(schoolLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolLevel", new { id = schoolLevel.SchoolLevelId }, schoolLevel);
        }

        // DELETE: api/SchoolLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolLevel(int id)
        {
            var schoolLevel = await _context.SchoolLevels.FindAsync(id);
            if (schoolLevel == null)
            {
                return NotFound();
            }

            _context.SchoolLevels.Remove(schoolLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolLevelExists(int id)
        {
            return _context.SchoolLevels.Any(e => e.SchoolLevelId == id);
        }
    }
}
