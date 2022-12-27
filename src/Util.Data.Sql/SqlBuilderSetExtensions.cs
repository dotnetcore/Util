using System.Collections.Generic;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql生成器集合操作扩展
    /// </summary>
    public static class SqlBuilderSetExtensions {

        #region Union(合并结果集)

        /// <summary>
        /// 合并结果集,排除重复结果行,并按默认规则排序
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T Union<T>( this T source, params ISqlBuilder[] builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Union( builders );
            return source;
        }

        /// <summary>
        /// 合并结果集,排除重复结果行,并按默认规则排序
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T Union<T>( this T source, IEnumerable<ISqlBuilder> builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Union( builders );
            return source;
        }

        #endregion

        #region UnionAll(合并结果集)

        /// <summary>
        /// 合并结果集,不会排除重复结果行
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T UnionAll<T>( this T source, params ISqlBuilder[] builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.UnionAll( builders );
            return source;
        }

        /// <summary>
        /// 合并结果集,不会排除重复结果行
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T UnionAll<T>( this T source, IEnumerable<ISqlBuilder> builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.UnionAll( builders );
            return source;
        }

        #endregion

        #region Intersect(交集)

        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T Intersect<T>( this T source, params ISqlBuilder[] builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Intersect( builders );
            return source;
        }

        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T Intersect<T>( this T source, IEnumerable<ISqlBuilder> builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Intersect( builders );
            return source;
        }

        #endregion

        #region Except(差集)

        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T Except<T>( this T source, params ISqlBuilder[] builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Except( builders );
            return source;
        }

        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器集合</param>
        public static T Except<T>( this T source, IEnumerable<ISqlBuilder> builders ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Except( builders );
            return source;
        }

        #endregion

        #region ClearSets(清理集合)

        /// <summary>
        /// 清理Union等集合操作
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearSets<T>( this T source ) where T : ISet {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.SqlBuilderSet.Clear();
            return source;
        }

        #endregion
    }
}
