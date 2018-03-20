using Donau.Services.Dtos.Customers;
using Microsoft.AspNetCore.Mvc;
using Util.Ui.Attributes;

namespace Util.Samples.Webs.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

        [Html( "/Typings/app/app.component.html" )]
        public IActionResult Main() {
            return View();
        }

        [Html( "/Typings/app/demo/demo.component.html" )]
        public IActionResult Demo() {
            return View(new CustomersDto());
        }

        public IActionResult List() {
            return View();
        }

        [Html( "/Typings/app/demo/dialog.component.html" )]
        public IActionResult Dialog() {
            return View();
        }
    }
}
