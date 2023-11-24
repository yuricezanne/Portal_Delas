using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateNewVaga(string Title, int UserId, int JobID, string Description, string Address, string CategoryName)
        {
            // Verifica se a categoria já existe no banco de dados
            JobCategory category = _context.Categories.FirstOrDefault(c => c.CategoryName == CategoryName);

            // Se a categoria não existir, cria uma nova
            if (category == null)
            {
                category = new JobCategory { CategoryName = CategoryName };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }

            // Cria o novo trabalho associado à categoria
            JobInfo newItem = new JobInfo
            {
                JobCreationDate = DateTime.Now,
                JobTitle = Title,
                JobID = JobID,
                JobDescription = Description,
                JobAddress = Address,
                JobCategory = category, // Atribui a categoria ao trabalho
                IsInativo = true
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

        public void CreateNewEvento(string Title, int EventId, DateTime dateTime, string Description, string Address, int EventTypeId)
        {
            // Verifica se o tipo de evento já existe no banco de dados
            EventType eventType = _context.EventTypes.FirstOrDefault(t => t.TypeId == EventTypeId);

            // Se o tipo de evento não existir, você pode tratar isso conforme necessário (criar o tipo de evento, lançar uma exceção, etc.)
            if (eventType == null)
            {
                // Trate isso de acordo com sua lógica de negócios
                // Por exemplo, lançando uma exceção ou criando um novo tipo de evento
                throw new InvalidOperationException("O tipo de evento especificado não existe.");
            }

            // Cria o novo evento associado ao tipo de evento
            EventInfo newItem = new EventInfo
            {
                EventCreationDate = DateTime.Now,
                EventTitle = Title,
                EventID = EventId,
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
    }
}