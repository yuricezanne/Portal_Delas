﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class Gateway
    {
        private readonly PortalDbContext _context;

        public Gateway(PortalDbContext context)
        {
            _context = context;
        }

        public void RegisterUser(UserInfo registration)
        {
            UserInfo registeruser = new UserInfo();

            registeruser.Email = registration.Email.ToLower();

            registeruser.Password = registration.Password;

            registeruser.Name = registration.Name;

            registeruser.UserType = registration.UserType;

            registeruser.CompanyName = registration.CompanyName;

            registeruser.UserPhone = registration.UserPhone;

            _context.Users.Add(registeruser);
        }

        public UserInfo VerifyUser(UserInfo registration)
        {
            var existingAccount = _context.Users
                .FirstOrDefault(u => u.Email == registration.Email.ToLower());

            return existingAccount;
        }

        public UserInfo AuthenticateUser(string email, string password)
        {
            UserInfo userLogin = _context.Users.FirstOrDefault(u => u.Email == email);
            return userLogin;
        }

        public void CreateNewVaga(string Title, string Description, string Address, string CategoryName)
        {

            //var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            //// Verifica se a categoria já existe no banco de dados
            //JobCategory category = _context.Categories.FirstOrDefault(c => c.CategoryName == CategoryName);

            //// Se a categoria não existir, cria uma nova
            //if (category == null)
            //{
            //    category = new JobCategory { CategoryName = CategoryName };
            //    _context.Categories.Add(category);
            //    _context.SaveChanges();
            //}

            //// Cria o novo trabalho associado à categoria
            JobInfo newItem = new JobInfo
            {
                JobCreationDate = DateTime.Now,
                JobTitle = Title,
                JobDescription = Description,
                JobAddress = Address,
                JobCategory = CategoryName, // Atribui a categoria ao trabalho
                IsInativo = true,
                CreatedByUserId = 1        
            };

            _context.Jobs.Add(newItem);
            _context.SaveChanges();
        }

        public void DeleteVaga(int JobID)
        {
            var findItem = _context.Jobs
                 .Where(x => x.JobID == JobID)
                 .FirstOrDefault();

            if (findItem != null)
            {
                _context.Jobs.Remove(findItem);
                _context.SaveChanges();
            }
        }
        public void DesativarVaga(int JobID)
        {
            var findItem = _context.Jobs
                 .Where(x => x.JobID == JobID)
                 .FirstOrDefault();

            if (findItem != null)
            {
                findItem.IsInativo = !findItem.IsInativo;
                findItem.JobCreationDate = DateTime.Now;
            }

            _context.SaveChanges();
        }

        public void CreateNewEvento(string Title, DateTime dateTime, string Description, string Address, string EventType)
        {
            var eventType = new EventType { TypeName = EventType };


            // Cria o novo evento associado ao tipo de evento
            EventInfo newItem = new EventInfo
            {
                EventCreationDate = DateTime.Now,
                EventTitle = Title,
                EventDate = dateTime,
                EventDescription = Description,
                EventAddress = Address,
                EventType = eventType, // Atribui o tipo de evento ao evento
                IsInativo = true
            };

            _context.Events.Add(newItem);
            _context.SaveChanges();
        }
        public void DeleteEvento(int EventId)
        {
            var findItem = _context.Events
                 .Where(x => x.EventID == EventId)
                 .FirstOrDefault();

            if (findItem != null)
            {
                _context.Events.Remove(findItem);
                _context.SaveChanges();
            }
        }
        public void DesativarEvento(int EventId)
        {
            var findItem = _context.Events
                 .Where(x => x.EventID == EventId)
                 .FirstOrDefault();

            if (findItem != null)
            {
                findItem.IsInativo = !findItem.IsInativo;
                findItem.EventCreationDate = DateTime.Now;
            }

            _context.SaveChanges();
        }

        public EventType GetOrCreateEventType(int eventTypeId)
        {
            // Tente encontrar um EventType com o ID fornecido
            EventType eventType = _context.EventTypes.FirstOrDefault(t => t.TypeId == eventTypeId);

            // Se não existir, crie um novo EventType
            if (eventType == null)
            {
                eventType = new EventType { TypeId = eventTypeId, TypeName = "Tipo Padrão" }; // Ajuste conforme necessário
                _context.EventTypes.Add(eventType);
                _context.SaveChanges();
            }

            return eventType;
        }
    }
}