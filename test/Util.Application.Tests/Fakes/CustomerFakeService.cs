using System.Collections.Generic;
using AutoBogus;
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
            return new AutoFaker<Customer>().Generate();
        }

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<Customer> GetCustomers( int count ) {
            return new AutoFaker<Customer>().Generate( count );
        }
    }
}