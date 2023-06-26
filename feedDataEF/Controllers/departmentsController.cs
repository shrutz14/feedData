using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using feedDataEF.Model;

namespace feedDataEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public departmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<department>>> Getdepartment()
        {
          if (_context.department == null)
          {
              return NotFound();
          }
            return await _context.department.ToListAsync();
        }

        // GET: api/departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<department>> Getdepartment(int id)
        {
          if (_context.department == null)
          {
              return NotFound();
          }
            var department = await _context.department.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdepartment(int id, department department)
        {
            if (id != department.DeptId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departmentExists(id))
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

        // POST: api/departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<department>> Postdepartment(department department)
        {
          if (_context.department == null)
          {
              return Problem("Entity set 'ApplicationDbContext.department'  is null.");
          }
            _context.department.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdepartment", new { id = department.DeptId }, department);
        }

        // DELETE: api/departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedepartment(int id)
        {
            if (_context.department == null)
            {
                return NotFound();
            }
            var department = await _context.department.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.department.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool departmentExists(int id)
        {
            return (_context.department?.Any(e => e.DeptId == id)).GetValueOrDefault();
        }
    }
}
