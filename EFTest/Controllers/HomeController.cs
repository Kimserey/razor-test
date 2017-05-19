using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{

    public class HomeController : Controller
    {
        private CompanyDbContext _dbContext;

        public HomeController(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Test/{id}")]
        public IActionResult Test([FromRoute]int id, [FromBody]string name)
        {
            var company = new Company { Id = id, Name = name };
            _dbContext.Add(company);
            _dbContext.SaveChanges();
            return Json(company);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
