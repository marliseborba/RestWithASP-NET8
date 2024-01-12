using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Model;
using RestWithASP_NET.Services;

namespace RestWithASP_NET.Controllers
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/person/v{version:apiVersion}")]
    public class PersonController2 : ControllerBase
    {
        private readonly ILogger<PersonController2> _logger;

        // Declaration of the service used
        private IPersonService _personService;

        // Injection of an instance of IPersonService
        // when creating an instance of PersonController
        public PersonController2(ILogger<PersonController2> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        // Maps GET requests to https://localhost:{port}/api/person
        // Get no parameters for FindAll -> Search All
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindByID(3));
        }

        // Maps GET requests to https://localhost:{port}/api/person/{id}
        // receiving an ID as in the Request Path
        // Get with parameters for FindById -> Search by ID
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        // Maps POST requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Create(person));
        }

        // Maps PUT requests to https://localhost:{port}/api/person/
        // [FromBody] consumes the JSON object sent in the request body
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
                return BadRequest();
            return Ok(_personService.Update(person));
        }

        // Maps DELETE requests to https://localhost:{port}/api/person/{id}
        // receiving an ID as in the Request Path
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
