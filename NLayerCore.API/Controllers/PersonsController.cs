using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.Core.Models;
using NLayerCore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IGenericService<Person> _personService;

        public PersonsController(IGenericService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons); 
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var person = await _personService.FindByWhereAsync(x => x.Name == name);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person entity)
        {
            var person = await _personService.AddAsync(entity);
            return Created(string.Empty,person);
        }

        [HttpPut]
        public IActionResult Update(Person entity)
        {
            var person = _personService.Update(entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Remove(person);
            return NoContent();
        }




    }
}
