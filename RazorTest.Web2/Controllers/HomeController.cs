using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Web2
{
    [Route("[controller]")]
    public class HomeController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Home2")]
        public IActionResult Index2()
        {
            return ViewComponent("CompanyList", new { count = 1 });
        }

        [HttpGet("companies")]
        public IActionResult GetCompanies()
        {
            return View("Companies", new List<Company> {
                new Company {
                    Name = "Helloworld",
                    Address = "29 street"
                },
                new Company {
                    Name = "Byebyeworld",
                    Address = "22 street"
                }
            });
        }

        [HttpPost]
        public IActionResult PostCompany(Company comp)
        {
            return Ok();
        }
    }
}
