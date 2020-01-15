using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EndocrinRegistr.Models;

namespace EndocrinRegistr.Controllers
{
    public class CaseRecordsController : Controller
    {
        private readonly ApplicationContext _context;

        public CaseRecordsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: CaseRecords
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.CaseRecords.Include(c => c.Diag).Include(c => c.Doctors);
            return View(await applicationContext.ToListAsync());
        }

        // GET: CaseRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseRecord = await _context.CaseRecords
                .Include(c => c.Diag)
                .Include(c => c.Doctors)
                .Include(p => p.LabCases)
                .ThenInclude(p => p.Lab)
                .FirstOrDefaultAsync(m => m.CaseRecordId == id);
            if (caseRecord == null)
            {
                return NotFound();
            }

            //return View(caseRecord);
            return PartialView("_CaseRecordDetails", caseRecord);
        }

        // GET: CaseRecords/Create
        public IActionResult Create()
        {
            ViewData["DiagId"] = new SelectList(_context.Diags, "DiagId", "NameDiag");
            ViewData["DoctorsId"] = new SelectList(_context.Doctors.Where(p => p.Deleted != true), "DoctorId", "Doctor");
            return View();
        }

        // POST: CaseRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseRecordId,DiagId,DoctorsId,Fio,DateBirth,Sex,Contacts,Adds,Job,CompDiag,NumCase,DetectCaseY,DetectFormationY,DetectDetails,Complaints,Obesity,DisorderCarbo,ArterHypert,DisorderPcm,Visual,Igh,Operation,Postoper,SvzkNpvaA,SvzkPnvA,SvzkLnvA,SvzkNpvbA,SvzkNpvaK,SvzkPnvK,SvzkLnvK,SvzkNpvbK")] CaseRecord caseRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caseRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagId"] = new SelectList(_context.Diags, "DiagId", "NameDiag", caseRecord.DiagId);
            ViewData["DoctorsId"] = new SelectList(_context.Doctors, "DoctorId", "Doctor", caseRecord.DoctorsId);
            return View(caseRecord);
        }

        // GET: CaseRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            CaseRecord caseRecord;
            if (id == null)
            {
                //return NotFound();
                caseRecord = new CaseRecord();
                _context.Add(caseRecord);
                await _context.SaveChangesAsync();
                caseRecord = await _context.CaseRecords.FindAsync(caseRecord.CaseRecordId);
            }
            else
            {
                caseRecord = await _context.CaseRecords.FindAsync(id);
                //caseRecord = await _context.CaseRecords.Include(p => p.LabCases).FirstOrDefaultAsync(p => p.CaseRecordId == id);
            }

            if (caseRecord == null)
            {
                return NotFound();
            }
            ViewData["DiagId"] = new SelectList(_context.Diags.Where(p => p.Deleted != true || p.DiagId == caseRecord.DiagId), "DiagId", "NameDiag", caseRecord.DiagId);
            ViewData["DoctorsId"] = new SelectList(_context.Doctors.Where(p => p.Deleted != true || p.DoctorId == caseRecord.DoctorsId), "DoctorId", "Doctor", caseRecord.DoctorsId);
            ViewData["LabId"] = new SelectList(_context.Labs.Where(p => p.Deleted != true), "LabId", "LabName");
            return View(caseRecord);
        }

        // POST: CaseRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseRecordId,DiagId,DoctorsId,Fio,DateBirth,Sex,Contacts,Adds,Job,CompDiag,NumCase,DetectCaseY,DetectFormationY,DetectDetails,Complaints,Obesity,DisorderCarbo,ArterHypert,DisorderPcm,Visual,Igh,Operation,Postoper,SvzkNpvaA,SvzkPnvA,SvzkLnvA,SvzkNpvbA,SvzkNpvaK,SvzkPnvK,SvzkLnvK,SvzkNpvbK")] CaseRecord caseRecord)
        {
            if (id == 0)
            {
                id = caseRecord.CaseRecordId;
            }
            else
            {
                if (id != caseRecord.CaseRecordId)
                {
                    return NotFound();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caseRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseRecordExists(caseRecord.CaseRecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            ViewData["DiagId"] = new SelectList(_context.Diags, "DiagId", "NameDiag", caseRecord.DiagId);
            ViewData["DoctorsId"] = new SelectList(_context.Doctors, "DoctorId", "Doctor", caseRecord.DoctorsId);
            return View(caseRecord);
        }

        // GET: CaseRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caseRecord = await _context.CaseRecords
                .Include(c => c.Diag)
                .Include(c => c.Doctors)
                .FirstOrDefaultAsync(m => m.CaseRecordId == id);
            if (caseRecord == null)
            {
                return NotFound();
            }

            return View(caseRecord);
        }

        // POST: CaseRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caseRecord = await _context.CaseRecords.FindAsync(id);
            _context.CaseRecords.Remove(caseRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool CaseRecordExists(int id)
        {
            return _context.CaseRecords.Any(e => e.CaseRecordId == id);
        }
    }
}
