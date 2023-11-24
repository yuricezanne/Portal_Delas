using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        public class Gateway
        {
            private readonly PortalDbContext _context;

            public Gateway(PortalDbContext context)
            {
                _context = context;
            }

            public EventInfo GetEventoById(int eventId)
            {
                return _context.Events.FirstOrDefault(e => e.EventID == eventId);
            }

            public void CreateNewEvento(string title, int eventId, DateTime eventDate, string description, string address, int eventTypeId)
            {
                // Cria um novo evento
                EventInfo newEvent = new EventInfo
                {
                    EventTitle = title,
                    EventID = eventId,
                    EventDate = eventDate,
                    EventDescription = description,
                    EventAddress = address,
                    EventTypeId = eventTypeId,
                    IsInativo = true // Ou qualquer outra lógica que seu sistema exija
                };

                _context.Events.Add(newEvent);
                _context.SaveChanges();
            }

            public void UpdateEvento(int eventId, EventInfo updatedEvent)
            {
                var existingEvent = _context.Events.FirstOrDefault(e => e.EventID == eventId);

                if (existingEvent != null)
                {
                    // Atualiza os atributos do evento existente com base nos dados recebidos
                    existingEvent.EventTitle = updatedEvent.EventTitle;
                    existingEvent.EventDate = updatedEvent.EventDate;
                    existingEvent.EventDescription = updatedEvent.EventDescription;
                    existingEvent.EventAddress = updatedEvent.EventAddress;
                    existingEvent.EventTypeId = updatedEvent.EventTypeId;

                    _context.SaveChanges();
                }
            }

            public void DeleteEvento(int eventId)
            {
                var existingEvent = _context.Events.FirstOrDefault(e => e.EventID == eventId);

                if (existingEvent != null)
                {
                    _context.Events.Remove(existingEvent);
                    _context.SaveChanges();
                }

            }
        }
    }
}