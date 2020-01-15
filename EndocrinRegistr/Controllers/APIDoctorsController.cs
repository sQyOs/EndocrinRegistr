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
    public class APIDoctorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public APIDoctorsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/APIDoctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
        {
            return await _context.Doctors.Where(p => p.Deleted != true).ToListAsync();
        }

        // GET: api/APIDoctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctors>> GetDoctors(short id)
        {
            var doctors = await _context.Doctors.FindAsync(id);

            if (doctors == null)
            {
                return NotFound();
            }

            return doctors;
        }

        // PUT: api/APIDoctors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctors(short id, Doctors doctors)
        {
            if (id != doctors.DoctorId)
            {
                return BadRequest();
            }
            if (doctors.Doctor == "deleted")
            {
                doctors = _context.Doctors.Where(p => p.DoctorId == id).FirstOrDefault();
                doctors.Deleted = true;
            }
            _context.Entry(doctors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(doctors);
        }

        // POST: api/APIDoctors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Doctors>> PostDoctors(Doctors doctors)
        {
            _context.Doctors.Add(doctors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctors", new { id = doctors.DoctorId }, doctors);
        }

        // DELETE: api/APIDoctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctors>> DeleteDoctors(short id)
        {
            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctors);
            await _context.SaveChangesAsync();

            return doctors;
        }

        private bool DoctorsExists(short id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
