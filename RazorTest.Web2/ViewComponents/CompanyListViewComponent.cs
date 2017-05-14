using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RazorTest.Web2
{
    public class CompanyListViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(int count)
        {
            var items = new List<Company> {
                 new Company {
                      Name = "ABC"
                 },
                 new Company {
                      Name = "HELLO"
                 },
                 new Company {
                      Name = "WORLD"
                 },
                 new Company {
                      Name = "BYE"
                 }
            }
            .Take(count)
            .ToList();

            return Task.FromResult((IViewComponentResult)View(items));
        }
    }
}
