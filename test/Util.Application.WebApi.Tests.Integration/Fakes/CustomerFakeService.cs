using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Applications.Dtos;
using Util.Applications.Models;

namespace Util.Applications.Fakes {
    /// <summary>
    /// 客户模拟数据服务
    /// </summary>
    public static class CustomerFakeService {
        /// <summary>
        /// 获取客户
        /// </summary>
        public static Customer GetCustomer() {
            return GetCustomers( 1 ).First();
        }

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<Customer> GetCustomers( int count ) {
            return new AutoFaker<Customer>()
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }

        /// <summary>
        /// 获取客户
        /// </summary>
        public static CustomerDto GetCustomerDto() {
            return GetCustomerDtos( 1 ).First();
        }

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<CustomerDto> GetCustomerDtos( int count ) {
            return new AutoFaker<CustomerDto>()
                .Configure( builder => builder
                    .WithSkip<CustomerDto>( t => t.Id )
                )
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }
    }
}