using System;
using System.Collections.Generic;
using GOLTestFullStack.Api.Entity;
using GOLTestFullStack.Api.Iinterface;
using Microsoft.AspNetCore.Http;
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
            _airplane.EnsureCreated();
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Airplane>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Airplane>> Get()
        {
            return Ok(_airplane.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Airplane), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Airplane> Get(int id)
        {
            var airplane = _airplane.GetById(id);
            if (airplane == null)
                return NotFound();
            return Ok(airplane);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Post([FromBody] Airplane airplane)
        {
            try
            {
                _airplane.Add(airplane);
                return Accepted();
            }
            catch(Exception ex)
            {
                return Conflict(ex.Message);
            }
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            try
            {
                _airplane.DeleteById(id);
                return Accepted();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
