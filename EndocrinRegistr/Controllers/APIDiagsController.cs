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
    public class APIDiagsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public APIDiagsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/APIDiags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diag>>> GetDiags()
        {
            return await _context.Diags.Where(p => p.Deleted != true && p.DiagId != 1).ToListAsync();
        }

        // GET: api/APIDiags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diag>> GetDiag(short id)
        {
            var diag = await _context.Diags.FindAsync(id);

            if (diag == null)
            {
                return NotFound();
            }

            return diag;
        }

        // PUT: api/APIDiags/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiag(short id, Diag diag)
        {
            if (id != diag.DiagId)
            {
                return BadRequest();
            }
            if (diag.NameDiag == "deleted")
            {
                diag = _context.Diags.Where(p => p.DiagId == id).FirstOrDefault();
                diag.Deleted = true;
            }
            _context.Entry(diag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(diag);
        }

        // POST: api/APIDiags
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Diag>> PostDiag(Diag diag)
        {
            _context.Diags.Add(diag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiag", new { id = diag.DiagId }, diag);
        }

        // DELETE: api/APIDiags/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Diag>> DeleteDiag(short id)
        //{
        //    var diag = await _context.Diags.FindAsync(id);
        //    if (diag == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Diags.Remove(diag);
        //    await _context.SaveChangesAsync();

        //    return diag;
        //}

        private bool DiagExists(short id)
        {
            return _context.Diags.Any(e => e.DiagId == id);
        }
    }
}
