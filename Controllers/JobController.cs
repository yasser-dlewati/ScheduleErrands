using Microsoft.AspNetCore.Mvc;
using ScheduledErrands.Models;
using ScheduledErrands.Services;

namespace ScheduledErrands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly LiteDbService _liteDbService;

        public JobsController(LiteDbService liteDbService)
        {
            _liteDbService = liteDbService;
        }

        [HttpGet]
        public IActionResult GetAllJobs()
        {
            var jobs = _liteDbService.ScheduledJobs.FindAll();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            var job = _liteDbService.ScheduledJobs.FindOne(j => j.Id == id);
            if (job == null) return NotFound();
            return Ok(job);
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody] Job job)
        {
            _liteDbService.ScheduledJobs.Insert(job);
            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, [FromBody] Job updatedJob)
        {
            var job = _liteDbService.ScheduledJobs.FindOne(j => j.Id == id);
            if (job == null) return NotFound();

            job.Type = updatedJob.Type;
            job.ScheduledTime = updatedJob.ScheduledTime;

            _liteDbService.ScheduledJobs.Update(job);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            var deleted = _liteDbService.ScheduledJobs.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
