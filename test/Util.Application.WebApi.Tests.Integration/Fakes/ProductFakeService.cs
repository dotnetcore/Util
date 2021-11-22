using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Applications.Dtos;
using Util.Applications.Models;

namespace Util.Applications.Fakes {
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
                .RuleFor( t => t.IsDeleted, false )
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
                .RuleFor( t => t.IsDeleted,false )
                .Generate( count );
        }
    }
}