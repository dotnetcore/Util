using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Dtos;
using Util.Tests.Models;

namespace Util.Tests.Fakes {
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
                .Ignore( t => t.CreationTime )
                .Ignore( t => t.CreatorId )
                .Ignore( t => t.TestProperty1 )
                .Generate( count );
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        public static ProductDto GetProductDto() {
            return GetProductDtos( 1 ).First();
        }

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<ProductDto> GetProductDtos( int count ) {
            return new AutoFaker<ProductDto>()
                .Configure( builder => builder
                    .WithSkip<ProductDto>( t => t.Id )
                )
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }
    }
}