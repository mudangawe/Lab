using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using WebAPI.Common.Entities;
using WebAPI.Common.Interface.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly Shared<JobModel> _iJobService;
        private readonly ILogger<JobsController> _logger;
        public JobsController(Shared<JobModel> iJobService, ILogger<JobsController> logger)
        {
            _iJobService = iJobService;
            _logger = logger;
        }

        // GET: api/<JobsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get all jobs end point request");
            var jobs = await _iJobService.GetAll();
            _logger.LogInformation($"Result obtained: {JsonConvert.SerializeObject(jobs)}");
            return Ok(jobs);
        }


        // POST api/<JobsController>
        [HttpPost("Add")]
        public async Task<IActionResult> Post([FromBody] JobModel jobModel)
        {
            _logger.LogInformation($"Job Add request with : {JsonConvert.SerializeObject(jobModel)}");
            var isAdded = await _iJobService.Add(jobModel);
            _logger.LogInformation($"Job Add successful");
            return Ok();
        }

    
    }
}
