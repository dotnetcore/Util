using Microsoft.AspNetCore.Mvc;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Helpers;

namespace Util.Samples.Webs.Controllers {
    public class HomeController : Controller {

        public HomeController( IOrderRepository orderRepository, ICustomerRepository customerRepository, ISqlServerUnitOfWork unitOfWork ) {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        private ISqlServerUnitOfWork _unitOfWork;
        private IOrderRepository _orderRepository;
        private ICustomerRepository _customerRepository;

        public IActionResult Index( string id ) {
            var customer = new Customer();
            customer.Init();
            customer.Balance = 18.52M;
            customer.Name = Id.ObjectId().Substring( 0,18 );
            _customerRepository.Add( customer );

            var order = new Order();
            order.Code = "code";
            order.Name = "a";
            order.Init();
            _orderRepository.Add( order );

            _unitOfWork.Commit();
            return View();
        }

        public IActionResult Error() {
            return View();
        }

        public IActionResult A() {
            return View();
        }
    }
}
