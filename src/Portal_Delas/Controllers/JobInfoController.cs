using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal_Delas.Controllers;

namespace UI.Controllers
{

    public class JobInfoController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly Gateway _gateway;
        private readonly ILogger<JobInfoController> _logger;


        public JobInfoController(ILogger<JobInfoController> logger, PortalDbContext context, Gateway gateway)
        {
            _logger = logger;
            _context = context;
            _gateway = gateway;
        }
        // Simulação de uma lista de trabalhos para exemplo
        private static List<JobInfo> jobs = new List<JobInfo>
        {
            new JobInfo
            {
                JobID = 1,
                JobCreationDate = DateTime.Now,
                JobDescription = "Descrição do Trabalho 1",
                JobAddress = "Endereço do Trabalho 1",
                JobCategory = "Categoria do Trabalho 1"
            },
            new JobInfo
            {
                JobID = 2,
                JobCreationDate = DateTime.Now,
                JobDescription = "Descrição do Trabalho 2",
                JobAddress = "Endereço do Trabalho 2",
                JobCategory = "Categoria do Trabalho 2"
            }
        };

        [HttpPost]
		public IActionResult CreateJob(JobInfo jobinfo)
		{

			_gateway.CreateNewVaga(jobinfo.JobTitle, jobinfo.JobDescription, jobinfo.JobAddress, jobinfo.JobCategory);
			var model = new LoginResultModel { LoginType = "I am a Company" };
			return View("../Home/Index", model);
			//try
			//{

			//}
			//catch (DbUpdateException)
			//{
			//    return RedirectToAction("Login", "UserInfo");
			//}

			//return RedirectToAction("Login", "UserInfo");
		}




        [HttpGet]
        public IActionResult GetJobs()
        {
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            var job = jobs.Find(j => j.JobID == id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        //[HttpPost]
        //public IActionResult CreateJob([FromBody] JobInfo job)
        //{
        //    job.JobID = jobs.Count + 1;
        //    jobs.Add(job);
        //    return CreatedAtAction(nameof(GetJob), new { id = job.JobID }, job);
        //}

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, [FromBody] JobInfo job)
        {
            var existingJob = jobs.Find(j => j.JobID == id);
            if (existingJob == null)
            {
                return NotFound();
            }

            existingJob.JobCreationDate = job.JobCreationDate;
            existingJob.JobDescription = job.JobDescription;
            existingJob.JobAddress = job.JobAddress;
            existingJob.JobCategory = job.JobCategory;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = jobs.Find(j => j.JobID == id);
            if (job == null)
            {
                return NotFound();
            }

            jobs.Remove(job);
            return NoContent();
        }

        [HttpGet]
        public IActionResult CheckJob(int id)
        {
            _gateway.DesativarVaga(id);
            _logger.LogInformation("Status da tarefa id " + id + " alterado!");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditJob(int id)
        {
           
                var findItem = _gateway.AccessVaga(id);

            if (findItem != null)
            {
                return View(findItem);
            }
            return NotFound();


        }

        [HttpPost]
        public IActionResult EditJob(int id, JobInfo updatedJob)
        {
            _gateway.EditVaga(id, updatedJob);
            _logger.LogInformation("Tarefa id " + id + " editada!");
            return RedirectToAction("PostHistory");
        }
    }
}