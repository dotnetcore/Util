using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using Donau.Services.Dtos.Customers;
using Donau.Services.Queries.Customers;
using Donau.Services.Abstractions.Customers;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.Tests.Samples.Domains.Repositories;

namespace Donau.Services.Core.Customers {
    /// <summary>
    /// 客户服务
    /// </summary>
    public class CustomersService : CrudServiceBase<Customer, CustomersDto, CustomersQuery,string>, ICustomersService {
        /// <summary>
        /// 初始化客户服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="customersRepository">客户仓储</param>
        public CustomersService( ISqlServerUnitOfWork unitOfWork, ICustomerRepository customersRepository )
            : base( unitOfWork, customersRepository ) {
            CustomersRepository = customersRepository;
        }
        
        /// <summary>
        /// 客户仓储
        /// </summary>
        public ICustomerRepository CustomersRepository { get; set; }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override CustomersDto ToDto( Customer entity ) {
            return entity.MapTo<CustomersDto>();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Customer ToEntity( CustomersDto dto ) {
            return dto.MapTo( new Customer( dto.Id ) );
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">客户查询实体</param>
        protected override IQueryBase<Customer> CreateQuery( CustomersQuery param ) {
            return new Query<Customer,string>( param )
                .And(t => t.Name.Contains(param.Name))
                .And(t => t.Nickname.Contains(param.Nickname))
                .And(t => t.Mobile.Contains(param.Mobile));
        }
    }
}