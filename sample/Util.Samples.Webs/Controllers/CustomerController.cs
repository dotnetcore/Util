using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.UnitOfWorks;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Donau.Services.Queries.Customers;
using Donau.Services.Abstractions.Customers;
using Donau.Services.Dtos.Customers;
using Donau.Services.Extensions.Customers;
using Util.Samples.Webs.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Util.Samples.Webs.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController(ICustomerRepository customerRepository, ISqlServerUnitOfWork unitOfWork, ICustomersService customersService)
        {
            CustomerRepository = customerRepository;
            UnitOfWork = unitOfWork;
            CustomersService = customersService;
        }

        protected ICustomerRepository CustomerRepository { get; set; }
        protected ISqlServerUnitOfWork UnitOfWork { get; set; }
        protected ICustomersService CustomersService { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public string GetAll()
        {
            try
            {
                var datas = CustomerRepository.FindAll();
                return Util.Helpers.Json.ToJson(datas);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Create()
        {
            return Util.Helpers.Json.ToJson(new CustomersDto());
        }

        public string GetById(string id)
        {
            var data = CustomerRepository.FindByIds(id).FirstOrDefault();
            return Util.Helpers.Json.ToJson(data.ToDto());
        }

        [HttpDelete]
        public string Delete(string id)
        {
            CustomersService.Delete(id);
            return "{}";
        }

        [HttpPost]
        public string BatchDelete([FromBody] BatchId ids)
        {
            var batchids = ids.ids.ToGuidList();
            //CustomersService.Delete(ids);
            return "{}";
        }


        [HttpPost]
        public string Save([FromBody] CustomersDto data)
        {
            CustomersService.Save(data);
            return "{}";
        }

        public string PageQuery([FromBody] CustomersQuery query)
        {
            Thread.Sleep(1000);
            var list = CustomersService.PagerQuery(query);
            return Util.Helpers.Json.ToJson(list);
        }
    }
}
