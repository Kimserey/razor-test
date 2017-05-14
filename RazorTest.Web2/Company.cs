using System.ComponentModel.DataAnnotations;

namespace RazorTest.Web2
{
    public class Company
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Domain Domain { get; set; }
    }
}
