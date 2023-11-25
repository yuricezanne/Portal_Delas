using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{

    public class EventInfoController : ControllerBase
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;


        public EventInfoController(PortalDbContext context, Gateway gateway)
        {
            _gateway = gateway;
            _context = context;
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

            _gateway.CreateNewEvento(eventinfo.EventTitle, eventinfo.EventDate, eventinfo.EventAddress, eventinfo.EventDescription, eventinfo.EventType);
            return RedirectToAction("Index", "Home");
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
    }
}