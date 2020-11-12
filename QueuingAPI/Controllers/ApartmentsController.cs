using Microsoft.AspNetCore.Mvc;
using QueuingAPI.Models;
using QueuingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QueuingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly ApartmentsService _apartmentsService;

        public ApartmentsController(ApartmentsService apartmentsService)
        {
            _apartmentsService = apartmentsService;
        }

        // GET: api/<ApartmentsController>
        [HttpGet]
        public ActionResult<List<Apartments>> Get() =>
            _apartmentsService.Get();

        // GET api/<ApartmentsController>/5
        [HttpGet("{id:length(24)}", Name = "Details")]
        public ActionResult<Apartments> Get(string id)
        {
            var apartment = _apartmentsService.Get(id);

            if (apartment == null)
            {
                return NotFound();
            }

            return apartment;
        }

        // POST api/<ApartmentsController>
        [HttpPost]
        public ActionResult<Apartments> Create(Apartments apartment)
        {
            //apartment.id = new Random().Next();
            _apartmentsService.Create(apartment);

            return CreatedAtRoute("Details", new { id = apartment.objectId.ToString() }, apartment);
        }

        // PUT api/<ApartmentsController>/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Apartments apartmentIn)
        {
            var apartment = _apartmentsService.Get(id);

            if (apartment == null)
            {
                return NotFound();
            }

            apartmentIn.objectId = id;
            _apartmentsService.Update(id, apartmentIn);

            return NoContent();
        }


        // DELETE api/<ApartmentsController>/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var apartment = _apartmentsService.Get(id);

            if (apartment == null)
            {
                return NotFound();
            }

            _apartmentsService.Remove(apartment.objectId);

            return NoContent();
        }
    }
}
