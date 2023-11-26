using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{

	public class EventInfoController : Controller
	{
		private readonly PortalDbContext _context;
		private readonly Gateway _gateway;
		private readonly ILogger<EventInfoController> _logger;


		public EventInfoController(ILogger<EventInfoController> logger, PortalDbContext context, Gateway gateway)
		{
			_logger = logger;
			_context = context;
			_gateway = gateway;
		}
		// Simulação de uma lista de eventos para exemplo
		private static List<EventInfo> eventos = new List<EventInfo>
        {
            new EventInfo
            {
                EventID = 1,
                EventCreationDate = DateTime.Now,
                EventDate = DateTime.Now.AddDays(7),
                EventDescription = "Descrição do Evento 1",
                EventAddress = "Endereço do Evento 1",
                EventType = "Tipo do Evento 1", 
                EventTitle = "Titulo do Evento 1",
            },
            new EventInfo
            {
                EventID = 2,
                EventCreationDate = DateTime.Now,
                EventDate = DateTime.Now.AddDays(14),
                EventDescription = "Descrição do Evento 2",
                EventAddress = "Endereço do Evento 2",
                EventType = "Tipo do Evento 2",
                EventTitle = "Titulo do Evento 2",
            }
        };

        [HttpGet]
        public IActionResult GetEventos()
        {
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvento(int id)
        {
            var evento = eventos.Find(e => e.EventID == id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventInfo eventinfo)
        {

            _gateway.CreateNewEvento(eventinfo.EventTitle, eventinfo.EventDate, eventinfo.EventDescription, eventinfo.EventAddress, eventinfo.EventType);
            return RedirectToAction("EventHistory", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvento(int id, [FromBody] EventInfo evento)
        {
            var existingEvento = eventos.Find(e => e.EventID == id);
            if (existingEvento == null)
            {
                return NotFound();
            }

            existingEvento.EventCreationDate = evento.EventCreationDate;
            existingEvento.EventDate = evento.EventDate;
            existingEvento.EventDescription = evento.EventDescription;
            existingEvento.EventAddress = evento.EventAddress;
            existingEvento.EventType = evento.EventType;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvento(int id)
        {
            var evento = eventos.Find(e => e.EventID == id);
            if (evento == null)
            {
                return NotFound();
            }

            eventos.Remove(evento);
            return NoContent();
        }

		[HttpGet]
		public IActionResult EditEvent(int id)
		{

			var findItem = _gateway.AccessEvento(id);

			if (findItem != null)
			{
				return View(findItem);
			}
			return NotFound();


		}

		[HttpPost]
		public IActionResult EditEvent(int id, EventInfo updatedEvent)
		{
			_gateway.EditEvento(id, updatedEvent);
			_logger.LogInformation("Evento id " + id + " editado!");
			return RedirectToAction("EventHistory", "Home");
		}

		[HttpGet]
		public IActionResult DetailsEvent(int id)
		{
			var findItem = _gateway.DetailsEvento(id);

			if (findItem != null)
			{
				return View(findItem);
			}
			return NotFound();

		}

		[HttpGet]
		public IActionResult DeleteEvent(int id)
		{
			_gateway.DeleteEvento(id);
			_logger.LogInformation("Evento excluído!");
			return RedirectToAction("EventHistory", "Home");

		}

	}
}