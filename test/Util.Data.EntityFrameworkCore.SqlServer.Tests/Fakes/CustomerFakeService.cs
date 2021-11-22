using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Data.EntityFrameworkCore.Models;

namespace Util.Data.EntityFrameworkCore.Fakes {
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
                .RuleFor( t => t.Code, t => t.Random.String2( 1, 100 ) )
                .RuleFor( t => t.Name, t => t.Random.String2( 1, 200 ) )
                .RuleFor( t => t.Nickname, t => t.Random.String2( 1, 50 ) )
                .RuleFor( t => t.Phone, t => t.Random.String2( 1, 50 ) )
                .RuleFor( t => t.Email, t => t.Random.String2( 1, 500 ) )
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }
    }
}