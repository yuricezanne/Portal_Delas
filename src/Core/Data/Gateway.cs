using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Data
{
    public class Gateway
    {
        private readonly PortalDbContext _context;

        public Gateway(PortalDbContext context)
        {
            _context = context;
        }

        public void CreateVaga(string Title, string JobDescription, string JobAddress, int JobCategoryID, int JobId)
        {
            JobInfo newItem = new JobInfo();
            newItem.JobCreationDate = DateTime.Now;
            newItem.JobTitle = Title;
            newItem.JobDescription = JobDescription;
            newItem.JobAddress = JobAddress;
            newItem.JobCategoryID = JobCategoryID;
            newItem.JobID = JobId;

            _context.Jobs.Add(newItem);
            _context.SaveChanges();
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

        public JobInfo DetailsJob(int JobID)
        {
            var findItem = _context.Jobs
                .Where(x => x.JobID == JobID)
                .FirstOrDefault();

            return findItem;
        }



    }
}