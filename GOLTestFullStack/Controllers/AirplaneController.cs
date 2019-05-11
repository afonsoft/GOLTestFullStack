using System.Collections.Generic;
using System.Linq;
using GOLTestFullStack.Api.Entity;
using GOLTestFullStack.Api.Iinterface;
using Microsoft.AspNetCore.Mvc;

namespace GOLTestFullStack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {

        private readonly IAirplaneRepository _airplane;
        public AirplaneController(IAirplaneRepository airplane)
        {
            _airplane = airplane;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Airplane>> Get()
        {
            return Ok(_airplane.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Airplane> Get(int id)
        {
            var airplane = _airplane.GetById(id);
            if (airplane == null)
                return NotFound();
            return Ok(airplane);
        }
        [HttpGet("{modelo}")]
        public ActionResult<IEnumerable<Airplane>> Get(string modelo)
        {
            return _airplane.Find(x => x.Modelo == modelo).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Airplane airplane)
        {
            _airplane.Add(airplane);
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _airplane.DeleteById(id);
        }
    }
}
