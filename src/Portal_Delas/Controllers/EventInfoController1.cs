using System.Collections.Generic;
using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    public class EventInfoController : Controller
    {
        private readonly PortalDbContext _context;
        //private readonly Gateway _gateway;

        public EventInfoController(PortalDbContext context, Gateway gateway)
        {
            _context = context;
            //_gateway = gateway;
        }

       
        public IActionResult EventInfo()
        {
            List<EventInfo> events = _context.Events.ToList();
            return View(events);
        }
    }
}
