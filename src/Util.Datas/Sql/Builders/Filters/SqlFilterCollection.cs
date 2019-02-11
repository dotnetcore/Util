using System.Collections.Generic;

namespace Util.Datas.Sql.Builders.Filters {
    /// <summary>
    /// Sql过滤器集合
    /// </summary>
    public static class SqlFilterCollection {
        /// <summary>
        /// 初始化Sql过滤器集合
        /// </summary>
        static SqlFilterCollection() {
            Filters = new List<ISqlFilter> { new IsDeletedFilter() };
        }

        /// <summary>
        /// Sql查询过滤器集合
        /// </summary>
        public static List<ISqlFilter> Filters { get; }

        /// <summary>
        /// 添加Sql过滤器
        /// </summary>
        /// <param name="filter">Sql查询过滤器</param>
        public static void Add( ISqlFilter filter ) {
            if( filter == null )
                return;
            Filters.Add( filter );
        }
    }
}
