using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql生成器扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendSelect( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendSelect( sql );
            return builder;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendFrom( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendFrom( sql );
            return builder;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendJoin( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendJoin( sql );
            return builder;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendLeftJoin( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendLeftJoin( sql );
            return builder;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendRightJoin( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendRightJoin( sql );
            return builder;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendWhere( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendWhere( sql );
            return builder;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendGroupBy( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendGroupBy( sql );
            return builder;
        }

        /// <summary>
        /// 添加到OrderBy子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="condition">该值为true时添加Sql，否则忽略</param>
        public static ISqlBuilder AppendOrderBy( this ISqlBuilder builder, string sql, bool condition ) {
            if( condition )
                builder.AppendOrderBy( sql );
            return builder;
        }
    }
}
