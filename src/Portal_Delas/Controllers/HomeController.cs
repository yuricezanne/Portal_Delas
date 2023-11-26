using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal_Delas.Models;
using System.Diagnostics;

namespace Portal_Delas.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PortalDbContext context, Gateway gateway)
        {
            _logger = logger;
            _context = context;
            _gateway = gateway;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EventInfo()
        {
            return View();
        }
        public IActionResult JobInfo()
        {
            return View();
        }

        public IActionResult CreateJob()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        public IActionResult PostHistory()
        {
            var minhasVagas = _context.Jobs.ToList();
            return View(minhasVagas);
        }

		public IActionResult EventHistory()
		{
			var meuEventos = _context.Events.ToList();
			return View(meuEventos);
		}

		public IActionResult ApplyJob(string categoryFilter)
		{
			var minhasVagas = _context.Jobs.ToList();

			// Se um filtro de categoria for fornecido, filtre as vagas com base na categoria
			if (!string.IsNullOrEmpty(categoryFilter))
			{
				minhasVagas = minhasVagas.Where(j => j.JobCategory == categoryFilter).ToList();
			}

			var vagasFinais = new List<JobEventUserInfoModel>();

			foreach (var vaga in minhasVagas)
			{
				var user = _context.Users.FirstOrDefault(u => u.UserInfoId.Equals(vaga.CreatedByUserId));
				vagasFinais.Add(new JobEventUserInfoModel
				{
					JobTitle = vaga.JobTitle,
					CompanyName = user.CompanyName,
					JobCreationDate = vaga.JobCreationDate,
					JobDescription = vaga.JobDescription,
					JobCategory = vaga.JobCategory,
				});
			}

			return View(vagasFinais);
		}


		public IActionResult ApplyEvent(string eventFilter)
		{
			var myEvents = _context.Events.ToList();

			// Se um filtro de evento for fornecido, filtre os eventos com base no tipo de evento
			if (!string.IsNullOrEmpty(eventFilter))
			{
				myEvents = myEvents.Where(e => e.EventType == eventFilter).ToList();
			}

			return View(myEvents);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}