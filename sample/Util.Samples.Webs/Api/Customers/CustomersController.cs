using System.Threading.Tasks;
using Donau.Services.Abstractions.Customers;
using Donau.Services.Dtos.Customers;
using Donau.Services.Queries.Customers;
using Microsoft.AspNetCore.Mvc;
using Util.Exceptions;
using Util.Webs.Controllers;

namespace Util.Samples.Webs.Api.Customers
{
    public class CustomersController : CrudControllerBase<CustomersDto, CustomersQuery>
    {
        public CustomersController(ICustomersService customersService) : base(customersService)
        {
        }

        public override Task<IActionResult> PagerQueryAsync( CustomersQuery query ) {
            System.Threading.Thread.Sleep( 2000 );
            return base.PagerQueryAsync( query );
        }
    }
}
