using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Core.Models;


namespace Core.Data
{
	public class Gateway
	{
		private readonly PortalDbContext _context;
		private DateTime dateTime;



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

		public void CreateNewVaga(string Title, int UserId, int JobID, string Description, string Address, string Category)
		{
			JobInfo newItem = new JobInfo();
			newItem.JobCreationDate = DateTime.Now;
			newItem.JobTitle = Title;
			newItem.JobID = JobID;
			newItem.JobDescription = Description;
			newItem.JobAddress = Address;
			newItem.JobCategory = Category;
			newItem.IsInativo = true;

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

		public void CreateNewEvento(string Title, int EventID, DateTime dateTime, string Description, string Address, string type)
		{
			Models.EventInfo newItem = new Models.EventInfo();
			newItem.EventCreationDate = DateTime.Now;
			newItem.EventDate = dateTime;
			newItem.EventTitle = Title;
			newItem.EventID = EventID;
			newItem.EventDescription = Description;
			newItem.EventAddress = Address;
			newItem.EventType = type;
			newItem.IsInativo = true;

			_context.Events.Add(newItem);
			_context.SaveChanges();
		}
		public void DeleteEvento(int EventID)
		{
			var findItem = _context.Events
				 .Where(x => x.EventID == EventID)
				 .FirstOrDefault();

			if (findItem != null)
			{
				_context.Events.Remove(findItem);
				_context.SaveChanges();
			}
		}
		public void DesativarEvento(int EventID)
		{
			var findItem = _context.Events
				 .Where(x => x.EventID == EventID)
				 .FirstOrDefault();

			if (findItem != null)
			{
				findItem.IsInativo = !findItem.IsInativo;
				findItem.EventCreationDate = DateTime.Now;
			}

			_context.SaveChanges();
		}
	}
}