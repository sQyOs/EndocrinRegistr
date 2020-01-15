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
    public class APILabCasesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public APILabCasesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/APILabCases?caseRecordId=1
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<LabCase>>> GetLabCases()
        //{
        //    return await _context.LabCases.ToListAsync();
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabCase>>> GetLabCases(int? caseRecordId)
        {
            return await _context.LabCases.Include(p => p.Lab).Where(p => p.CaseRecordId == caseRecordId).ToListAsync();
        }

        // GET: api/APILabCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabCase>> GetLabCase(int id)
        {
            var labCase = await _context.LabCases.FindAsync(id);

            if (labCase == null)
            {
                return NotFound();
            }

            return labCase;
        }

        // PUT: api/APILabCases/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabCase(int id, LabCase labCase)
        {
            if (id != labCase.LabCaseId)
            {
                return BadRequest();
            }

            _context.Entry(labCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabCaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(labCase);
        }

        // POST: api/APILabCases
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LabCase>> PostLabCase(LabCase labCase)
        {
            _context.LabCases.Add(labCase);
            await _context.SaveChangesAsync();

            return await _context.LabCases.Include(l => l.Lab).FirstOrDefaultAsync(l => l.LabCaseId == labCase.LabCaseId);
        }

        // DELETE: api/APILabCases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LabCase>> DeleteLabCase(int id)
        {
            var labCase = await _context.LabCases.FindAsync(id);
            if (labCase == null)
            {
                return NotFound();
            }

            _context.LabCases.Remove(labCase);
            await _context.SaveChangesAsync();

            return labCase;
        }

        private bool LabCaseExists(int id)
        {
            return _context.LabCases.Any(e => e.LabCaseId == id);
        }
    }
}
