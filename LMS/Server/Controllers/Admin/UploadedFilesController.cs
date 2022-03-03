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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadedFilesController : ControllerBase
    {
        private IWebHostEnvironment _Environment;
        private readonly ApplicationDbContext _context;

        public UploadedFilesController(ApplicationDbContext context, 
                                       IWebHostEnvironment environment)
        {
            _context = context;
            _Environment = environment;
        }

        // GET: api/UploadedFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadedFile>>> GetUploadedFile()
        {
            return await _context.UploadedFile.ToListAsync();
        }

        // GET: api/UploadedFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UploadedFile>> GetUploadedFile(int id)
        {
            var uploadedFile = await _context.UploadedFile.FindAsync(id);

            if (uploadedFile == null)
            {
                return NotFound();
            }

            return uploadedFile;
        }

        // PUT: api/UploadedFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUploadedFile(int id, UploadedFile uploadedFile)
        {
            if (id != uploadedFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(uploadedFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadedFileExists(id))
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

        // POST: api/UploadedFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UploadedFile>> PostUploadedFile(UploadedFile uploadedFile)
        {
            _context.UploadedFile.Add(uploadedFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUploadedFile", new { id = uploadedFile.Id }, uploadedFile);
        }
        [HttpGet]
        public ActionResult<UploadedFile> GetDirectory()
        {
            UploadedFile uploadedFile = new();
            string root = _Environment.WebRootPath;
            string[] split = root.Split("\\");
            foreach(string s in split)
            {
                if(s == "Server" || s == "server")
                    uploadedFile.Path = uploadedFile.Path + "Client\\";
                else
                    uploadedFile.Path = uploadedFile.Path + s + "\\";
            }
            uploadedFile.Path = string.Concat(uploadedFile.Path, "images\\");
            return uploadedFile;
        }

        // DELETE: api/UploadedFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUploadedFile(int id)
        {
            var uploadedFile = await _context.UploadedFile.FindAsync(id);
            if (uploadedFile == null)
            {
                return NotFound();
            }

            _context.UploadedFile.Remove(uploadedFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UploadedFileExists(int id)
        {
            return _context.UploadedFile.Any(e => e.Id == id);
        }
    }
}
