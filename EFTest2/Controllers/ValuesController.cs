using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFTest2.Controllers
{
    public class ValuesController : Controller
    {
        [HttpPost("/test")]
        public string Get([FromServices]PersonDbContext context, [FromForm]string name)
        {
            context.Add(new Person {
                Name = name
            });
            context.SaveChanges();
            return "value";
        }
    }
}
