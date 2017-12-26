using Donau.Services.Abstractions.Customers;
using Donau.Services.Dtos.Customers;
using Donau.Services.Queries.Customers;
using Util.Samples.Webs.Base;

namespace Util.Samples.Webs.Api.Customers
{
    public class CustomersController : CrudControllerBase<CustomersDto, CustomersQuery>
    {
        public CustomersController(ICustomersService customersService) : base(customersService)
        {
        }
    }
}
