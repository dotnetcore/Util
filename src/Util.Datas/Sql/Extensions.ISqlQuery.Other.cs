using Util.Datas.Sql.Builders;
using Util.Datas.Sql.Builders.Filters;

namespace Util.Datas.Sql {
    /// <summary>
    /// Sql查询对象扩展 - 杂项
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 在执行之后清空Sql和参数，默认为 true
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="value">是否在执行之后清空Sql和参数，默认为 true</param>
        public static ISqlQuery ClearAfterExecution( this ISqlQuery sqlQuery, bool value = true ) {
            sqlQuery.Config( t => t.IsClearAfterExecution = value );
            return sqlQuery;
        }

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlBuilder CloneBuilder( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            return builder.Clone();
        }

        /// <summary>
        /// 创建一个新的Sql生成器
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlBuilder NewBuilder( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            return builder.New();
        }

        /// <summary>
        /// 获取调试Sql语句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static string GetDebugSql( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            return builder.ToDebugSql();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery Clear( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.Clear();
            return sqlQuery;
        }

        /// <summary>
        /// 清空Select子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearSelect( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearSelect();
            return sqlQuery;
        }

        /// <summary>
        /// 清空From子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearFrom( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearFrom();
            return sqlQuery;
        }

        /// <summary>
        /// 清空Join子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearJoin( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearJoin();
            return sqlQuery;
        }

        /// <summary>
        /// 清空Where子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearWhere( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearWhere();
            return sqlQuery;
        }

        /// <summary>
        /// 清空GroupBy子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearGroupBy( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearGroupBy();
            return sqlQuery;
        }

        /// <summary>
        /// 清空OrderBy子句
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearOrderBy( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearOrderBy();
            return sqlQuery;
        }

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public static ISqlQuery AddParam( this ISqlQuery sqlQuery, string name, object value ) {
            var builder = sqlQuery.GetBuilder();
            builder.AddParam( name, value );
            return sqlQuery;
        }

        /// <summary>
        /// 清空Sql参数
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearSqlParams( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearSqlParams();
            return sqlQuery;
        }

        /// <summary>
        /// 清空分页参数
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery ClearPageParams( this ISqlQuery sqlQuery ) {
            var builder = sqlQuery.GetBuilder();
            builder.ClearPageParams();
            return sqlQuery;
        }

        /// <summary>
        /// 忽略过滤器
        /// </summary>
        /// <typeparam name="TSqlFilter">Sql过滤器类型</typeparam>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery IgnoreFilter<TSqlFilter>(this ISqlQuery sqlQuery) where TSqlFilter : ISqlFilter {
            var builder = sqlQuery.GetBuilder();
            builder.IgnoreFilter<TSqlFilter>();
            return sqlQuery;
        }

        /// <summary>
        /// 忽略逻辑删除过滤器
        /// </summary>
        /// <param name="sqlQuery">Sql查询对象</param>
        public static ISqlQuery IgnoreDeletedFilter(this ISqlQuery sqlQuery) => sqlQuery.IgnoreFilter<IsDeletedFilter>();
    }
}
