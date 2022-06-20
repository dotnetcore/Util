using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Models;

namespace Util.Tests.Fakes {
    /// <summary>
    /// 贴子模拟数据服务
    /// </summary>
    public static class PostFakeService {
        /// <summary>
        /// 获取贴子
        /// </summary>
        public static Post GetPost() {
            return GetPosts( 1 ).First();
        }

        /// <summary>
        /// 获取贴子列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<Post> GetPosts( int count ) {
            return new AutoFaker<Post>()
                .Ignore( t => t.Tags )
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }
    }
}