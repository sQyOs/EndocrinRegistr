using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndocrinRegistr.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace EndocrinRegistr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            foreach (Diag diag in _context.Diags)
            {
                nodes.Add(new TreeViewNode
                {
                    id = diag.DiagId.ToString(),
                    parent = "#",
                    text = diag.NameDiag
                });
            }
            //foreach (CaseRecord diag in _context.CaseRecords.Where(p => p.Diag != null).Include(p => p.Diag).ToList())
            //{
            //    nodes.Add(new TreeViewNode
            //    {
            //        id = diag.Diag.DiagId.ToString(),
            //        parent = "#",
            //        text = diag.Diag.NameDiag
            //    });
            //}
            foreach (CaseRecord caseRecord in _context.CaseRecords.Where(l => l.Fio != ""))
            {
                nodes.Add(new TreeViewNode
                {
                    id = caseRecord.DiagId.ToString() + "-" + caseRecord.CaseRecordId.ToString(),
                    parent = caseRecord.DiagId.ToString(),
                    text = caseRecord.Fio + " | " + caseRecord.DateBirth?.ToString("dd.MM.yyyy"),
                    icon = "jstree-themeicon-custom"
                });
            }
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View();
        }

        public IActionResult Diags()
        {
            return View();
        }

        public IActionResult Doctors()
        {
            return View();
        }

        public IActionResult Labs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
