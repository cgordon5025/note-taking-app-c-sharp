using Microsoft.AspNetCore.Mvc;
using noteTakingApp.Models;

namespace noteTakingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<NotesController> _logger;

        public NotesController(ILogger<NotesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllNotes")]
        public IEnumerable<Notes> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Notes
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}