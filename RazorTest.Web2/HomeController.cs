using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Web2
{
    public class Company
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }

    [Route("[controller]")]
    public class HomeController: Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
