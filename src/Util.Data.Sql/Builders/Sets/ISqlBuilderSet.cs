using System.Collections.Generic;

namespace Util.Data.Sql.Builders.Sets {
    /// <summary>
    /// Sql生成器集合
    /// </summary>
    public interface ISqlBuilderSet {
        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void Union( params ISqlBuilder[] builders );
        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void Union( IEnumerable<ISqlBuilder> builders );
        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void UnionAll( params ISqlBuilder[] builders );
        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void UnionAll( IEnumerable<ISqlBuilder> builders );
        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void Intersect( params ISqlBuilder[] builders );
        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void Intersect( IEnumerable<ISqlBuilder> builders );
        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void Except( params ISqlBuilder[] builders );
        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        void Except( IEnumerable<ISqlBuilder> builders );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 获取结果
        /// </summary>
        string ToResult();
        /// <summary>
        /// 复制Sql生成器集合
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        ISqlBuilderSet Clone( SqlBuilderBase builder );
    }
}
