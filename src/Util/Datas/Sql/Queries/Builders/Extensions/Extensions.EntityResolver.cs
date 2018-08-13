using System;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Extensions {
    /// <summary>
    /// 实体解析器扩展
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// 获取表，带架构
        /// </summary>
        /// <param name="resolver">实体解析器</param>
        /// <param name="entity">实体类型</param>
        public static string GetTableAndSchema( this IEntityResolver resolver, Type entity ) {
            if( resolver == null )
                throw new ArgumentNullException( nameof( resolver ) );
            var schema = resolver.GetSchema( entity );
            var table = resolver.GetTable( entity );
            if ( string.IsNullOrWhiteSpace( schema ) )
                return table;
            return $"{schema}.{table}";
        }

        /// <summary>
        /// 获取别名，如果别名为空，返回表名
        /// </summary>
        /// <param name="resolver">实体解析器</param>
        /// <param name="entity">实体类型</param>
        /// <param name="alias">别名</param>
        public static string GetAlias( this IEntityResolver resolver, Type entity,string alias ) {
            if( resolver == null )
                throw new ArgumentNullException( nameof( resolver ) );
            var table = resolver.GetTable( entity );
            if( string.IsNullOrWhiteSpace( alias ) )
                return table;
            return alias;
        }
    }
}
