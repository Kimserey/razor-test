using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AttributeRouteTest.Controllers
{
    public class T1Controller : Controller
    {
        // This will not be found
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("t2")]
    public class T2Controller : Controller
    {
        // GET /t2
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    public class T3Controller : Controller
    {
        // GET /t3
        [HttpGet("t3")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("t4")]
    public class T4Controller : Controller
    {
        // GET /t4/a
        [HttpGet("a")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("t5")]
    public class T5Controller : Controller
    {
        // GET /a
        [HttpGet("/a")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("/t6")] // Prepending with / in the controller route has no effect.
    public class T6Controller : Controller
    {
        // GET /t6/a
        [HttpGet("a")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("[controller]")]
    public class T7Controller : Controller
    {
        // GET /t7
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("[controller]/[action]")]
    public class T8Controller : Controller
    {
        // GET /t8/Hello
        [HttpGet]
        public IEnumerable<string> Hello()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("[controller]")]
    public class T9Controller : Controller
    {
        // GET /t9/Hello
        [HttpGet("[action]")]
        public IEnumerable<string> Hello()
        {
            return new string[] { "value1", "value2" };
        }
    }

    [Route("[controller]")]
    public class T10Controller : Controller
    {
        // GET /t10/{id}
        [HttpGet("{id}")]
        public IEnumerable<string> Get(Guid id)
        {
            return new string[] { "value1", "value2", id.ToString("n") };
        }
    }

    public class T11Controller : Controller
    {
        public class Body
        {
            [Required]
            public Guid Value { get; set; }
        }

        // POST /t11
        [HttpPost("/t11")]
        public IActionResult Post([FromBody] Body value)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(value.Value);
        }
    }

    public class T12Controller : Controller
    {
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [HttpGet("/t12/Get1")]
        public IActionResult Get1()
        {
            return Ok(new List<string> { "value1", "value2" });
        }

        public class Value
        {
            public string Test { get; set; }
        }

        [ProducesResponseType(200, Type = typeof(Value[]))]
        [HttpGet("/t12/Get2")]
        public IActionResult Get2()
        {
            return Ok(new List<Value> { new Value { Test = "value1" }, new Value { Test = "value1" } });
        }
    }

    public class T13Controller : Controller
    {
        [HttpPut]
        [Route("/[controller]/[action]")]
        public IActionResult GetValue()
        {
            return Ok();
        }
    }



    public class ChangeMemberNameDto
    {
        public class ChangeMemberName
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
        }

        [FromRoute]
        public string MemberId { get; set; }

        [FromBody]
        public ChangeMemberName Dto { get; set; }
    }

    public class T14Controller : Controller
    {
        [HttpPost("/{memberId}")]
        public IActionResult ChangeMemberName(ChangeMemberNameDto dto)
        {
            return Json(dto);
        }
    }
}
