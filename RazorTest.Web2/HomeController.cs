using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Web2
{
    public class Test
    {
        [Required]
        public string Hello { get; set; }
    }

    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return View(new Test());
        }
    }
}
