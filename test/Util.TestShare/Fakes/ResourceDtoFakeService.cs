using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Dtos;

namespace Util.Tests.Fakes {
    /// <summary>
    /// 资源模拟数据服务
    /// </summary>
    public static class ResourceDtoFakeService {
        /// <summary>
        /// 获取资源
        /// </summary>
        public static ResourceDto GetResourceDto() {
            return GetResourceDtos(1).First();
        }

        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<ResourceDto> GetResourceDtos( int count ) {
            return new AutoFaker<ResourceDto>()
                .Ignore( t => t.Id )
                .Ignore( t => t.ParentId )
                .Ignore( t => t.Path )
                .Ignore( t => t.Level )
                .Ignore( t => t.SortId )
                .RuleFor( t => t.Uri,t => t.Random.String2( 1,300 ) )
                .RuleFor( t => t.Name,t => t.Random.String2( 1,200 ) )
                .RuleFor( t => t.Remark,t => t.Random.String2( 1,500 ) )
                .Generate( count );
        }
    }
}