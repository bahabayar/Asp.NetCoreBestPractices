using Asp.NetCoreBestPractices.Core.Models;
using Asp.NetCoreBestPractices.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreBestPractices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly IService<Person> _personService;
        public PersonsController(IService<Person> personService)
        {
            _personService = personService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)

        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson = await _personService.AddAsync(person);
            return Ok(newPerson);
        }

        [HttpPost]
        [Route("addrange")]
        public async Task<IActionResult> AddByRange(IEnumerable<Person> persons)
        {
            await _personService.AddRangeAsync(persons);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedPerson = _personService.GetByIdAsync(id).Result;
            _personService.Remove(deletedPerson);
            return NoContent();


        }
        [HttpDelete]
        [Route("removerange")]
        public IActionResult RemoveByRange(IEnumerable<Person> person)
        {
           _personService.RemoveRange(person);
            return NoContent();

        }

        [HttpPut]
        public IActionResult Update(Person person)

        {
            _personService.Update(person);
            return NoContent();
        
        }
    }
}
