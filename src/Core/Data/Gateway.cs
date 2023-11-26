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

        public void CreateNewVaga(string title, string description, string address, string categoryName)
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
                JobTitle = title,
                JobDescription = description,
                JobAddress = address,
                JobCategory = categoryName, // Atribui a categoria ao trabalho
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

		public JobInfo DetailsVaga(int JobID)
		{
			var findItem = _context.Jobs
				.Where(x => x.JobID == JobID)
				.FirstOrDefault();

			return findItem;
		}

		public void CreateNewEvento(string title, DateTime dateTime, string description, string address, string eventType)
        {

            EventInfo newItem = new EventInfo
            {
                EventCreationDate = DateTime.Now,
                EventTitle = title,
                EventDate = dateTime,
                EventDescription = description,
                EventAddress = address,
                EventType = eventType, 
                IsInativo = true,
                CreatedByUserId = 1
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


        public JobInfo AccessVaga(int id)
        {
            return _context.Jobs.FirstOrDefault(x => x.JobID == id);
        }

        public void EditVaga(int id, JobInfo updatedJob)
        {
            var existingJob = _context.Jobs.FirstOrDefault(x => x.JobID == id);

            if (existingJob != null)
            {
                // Atualize as propriedades do trabalho existente com os valores do trabalho atualizado
                existingJob.JobTitle = updatedJob.JobTitle;
                existingJob.JobDescription = updatedJob.JobDescription;
                existingJob.JobAddress = updatedJob.JobAddress;
                existingJob.JobCategory = updatedJob.JobCategory;
                // Atualize outras propriedades conforme necessário...

                // Salve as alterações no contexto do banco de dados
                _context.SaveChanges();
            }
        }

    }
}