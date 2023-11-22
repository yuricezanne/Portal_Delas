using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    public class JobInfoController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;

        public JobInfoController(PortalDbContext context)
        {
            _context = context;
        }

   
        public IActionResult JobInfo()
        {
            List<JobInfo> JobInfo = _context.Jobs.ToList();
            return View(JobInfo);
        }

     
        public IActionResult FilterByCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
             
                var allJobs = _context.Jobs.ToList();
                return View("JobInfo", allJobs);
            }

            
            var jobsByCategory = _context.Jobs
                .Where(j => j.JobCategory == categoryName)
                .ToList();

            return View("Index", jobsByCategory);
        }
    }
}