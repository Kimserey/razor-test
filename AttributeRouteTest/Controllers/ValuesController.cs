using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        // GET /t1
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
}
