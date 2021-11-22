using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Data.EntityFrameworkCore.Models;

namespace Util.Data.EntityFrameworkCore.Fakes {
    /// <summary>
    /// 产品模拟数据服务
    /// </summary>
    public static class ProductFakeService {
        /// <summary>
        /// 获取产品
        /// </summary>
        public static Product GetProduct() {
            return GetProducts( 1 ).First();
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<Product> GetProducts( int count ) {
            return new AutoFaker<Product>()
                .RuleFor( t => t.Code, t => t.Random.String2( 1, 50 ) )
                .RuleFor( t => t.Name, t => t.Random.String2( 1, 500 ) )
                .RuleFor( t => t.IsDeleted, false )
                .Ignore( t => t.TestProperty1 )
                .Generate( count );
        }
    }
}