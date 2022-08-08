using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayerLib.Interfaces;
using DataAccessLayerLib.Models;
using BusinessAccessLayerLib.Services;
using Newtonsoft.Json;


namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        //prepare for DI
        private readonly PersonService personService;
        private readonly IRepository<Person> personRepository;  

        public PersonDetailsController(IRepository<Person> repository,PersonService service)
        {
            this.personService = service;
            this.personRepository = repository;
        }

        //Add Person
        [HttpPost("AddPerson")]
        public async Task<Object> AddPerson([FromBody] Person person)
        {
            try
            {
                await personService.AddPerson(person);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        //Delete person
        [HttpDelete("DeletePerson")]
        public bool DeletePerson(string emailid)
        {
            try
            {
                personService.DeletePerson(emailid);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //update person
        [HttpPut("UpdatePerson")]
        public bool UpdatePerson(Person person)
        {
            try
            {
                personService.UpdatePerson(person);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //get person by name
        [HttpGet("GetByName")]
        public Object GetByName(string emailid)
        {
            var data = personService.GetByName(emailid);
            var json = JsonConvert.SerializeObject(data,Formatting.Indented,new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,   
            });   
            return json;    
        }

        //Get all persons
        [HttpGet("GetAllPersons")]
        public Object GetAllPerson()
        {
            var data = personService.GetAllPersons();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            return json;
        }
    }
}
