using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class PortalDelasController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;

        public PortalDelasController(PortalDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<JobInfo>? jobInfo = _context.Jobs.ToList() ?? null;
            return View(jobInfo);
        }
        public IActionResult CreateJob()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }
    }
}