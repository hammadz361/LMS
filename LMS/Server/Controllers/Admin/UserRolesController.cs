using LMS.Server.Data;
using LMS.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _identityRole;
        public UserRolesController(ApplicationDbContext context,
                                   RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _identityRole = roleManager;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<userRoles>>> GetRoles()
        {
            var qry = _identityRole.Roles.AsQueryable();
            var singleRow = new List<userRoles>();
            if (qry.Count() > 0)
            {
                singleRow = await qry.Select(x => new userRoles
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
                return singleRow;
            }
            return singleRow;
        }

        // GET api/<userRolesController>/5
        [HttpGet("{id}")]
        public async Task<userRoles?> GetRoleById(string? id)
        {
            var qry = _identityRole.Roles.Where(x => x.Id == id).AsQueryable();
            var singleRow = new userRoles();
            if (qry.Any())
            {
                singleRow = await qry.Select(x => new userRoles
                {
                    Id = x.Id,
                    Name = x.Name
                }).FirstOrDefaultAsync();
                return singleRow;
            }
            return null;
        }

        // POST api/<userRolesController>
        [HttpPost]
        public async Task<ActionResult<userRoles>> PostUserRole(userRoles UserRole)
        {
            await _identityRole.CreateAsync(UserRole);
            return CreatedAtAction("Get", new { id = UserRole.Id }, UserRole);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(string id, userRoles UserRole)
        {
            if (id != UserRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(UserRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/UploadedFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var Role = await _context.Roles.FindAsync(id);
            if (Role == null)
            {
                return NotFound();
            }
            await _identityRole.DeleteAsync(Role);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
