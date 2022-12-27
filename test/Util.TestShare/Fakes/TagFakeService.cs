using System.Collections.Generic;
using System.Linq;
using AutoBogus;
using Util.Tests.Models;

namespace Util.Tests.Fakes {
    /// <summary>
    /// 标签模拟数据服务
    /// </summary>
    public static class TagFakeService {
        /// <summary>
        /// 获取标签
        /// </summary>
        public static Tag GetTag() {
            return GetTags( 1 ).First();
        }

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="count">行数</param>
        public static List<Tag> GetTags( int count ) {
            return new AutoFaker<Tag>()
                .Ignore( t => t.Posts )
                .RuleFor( t => t.IsDeleted, false )
                .Generate( count );
        }
    }
}