using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace SuaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobInfoController : ControllerBase
    {
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

        [HttpPost]
        public IActionResult CreateJob([FromBody] JobInfo job)
        {
            job.JobID = jobs.Count + 1;
            jobs.Add(job);
            return CreatedAtAction(nameof(GetJob), new { id = job.JobID }, job);
        }

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
    }
}