using Donau.Services.Dtos.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Util.Samples.Webs.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Main() {
            return View();
        }

        public IActionResult Demo() {
            return View(new CustomersDto());
        }

        public IActionResult List() {
            return View();
        }

        public IActionResult Dialog() {
            return View();
        }
    }
}
