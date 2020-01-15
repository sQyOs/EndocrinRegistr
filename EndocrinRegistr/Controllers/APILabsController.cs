using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EndocrinRegistr.Models;

namespace EndocrinRegistr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APILabsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public APILabsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/APILabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lab>>> GetLabs()
        {
            return await _context.Labs.Where(p => p.Deleted != true).ToListAsync();
        }

        // GET: api/APILabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lab>> GetLab(short id)
        {
            var lab = await _context.Labs.FindAsync(id);

            if (lab == null)
            {
                return NotFound();
            }

            return lab;
        }

        // PUT: api/APILabs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLab(short id, Lab lab)
        {
            if (id != lab.LabId)
            {
                return BadRequest();
            }
            if (lab.LabName == "deleted")
            {
                lab = _context.Labs.Where(p => p.LabId == id).FirstOrDefault();
                lab.Deleted = true;
            }
            _context.Entry(lab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(lab);
        }

        // POST: api/APILabs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Lab>> PostLab(Lab lab)
        {
            _context.Labs.Add(lab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLab", new { id = lab.LabId }, lab);
        }

        // DELETE: api/APILabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lab>> DeleteLab(short id)
        {
            var lab = await _context.Labs.FindAsync(id);
            if (lab == null)
            {
                return NotFound();
            }

            _context.Labs.Remove(lab);
            await _context.SaveChangesAsync();

            return lab;
        }

        private bool LabExists(short id)
        {
            return _context.Labs.Any(e => e.LabId == id);
        }
    }
}
