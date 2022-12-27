using System;
using Util.Data.Queries;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Where子句
    /// </summary>
    public interface IWhereClause : ISqlClause {
        /// <summary>
        /// 与连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        void And( ISqlCondition condition );
        /// <summary>
        /// 或连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        void Or( ISqlCondition condition );
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        void Where( string column, object value, Operator @operator );
        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="builder">子查询Sql生成器</param>
        /// <param name="operator">运算符</param>
        void Where( string column, ISqlBuilder builder, Operator @operator );
        /// <summary>
        /// 设置子查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="action">子查询操作</param>
        /// <param name="operator">运算符</param>
        void Where( string column, Action<ISqlBuilder> action, Operator @operator );
        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsNull( string column );
        /// <summary>
        /// 设置Is Not Null条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsNotNull( string column );
        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsEmpty( string column );
        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="column">列名</param>
        void IsNotEmpty( string column );
        /// <summary>
        /// 设置范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        void Between( string column, int? min, int? max, Boundary boundary );
        /// <summary>
        /// 设置范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        void Between( string column, double? min, double? max, Boundary boundary );
        /// <summary>
        /// 设置范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        void Between( string column, decimal? min, decimal? max, Boundary boundary );
        /// <summary>
        /// 设置范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        void Between( string column, DateTime? min, DateTime? max, bool includeTime, Boundary? boundary );
        /// <summary>
        /// 设置Exists查询条件
        /// </summary>
        /// <param name="builder">子查询Sql生成器</param>
        void Exists( ISqlBuilder builder );
        /// <summary>
        /// 设置Exists查询条件
        /// </summary>
        /// <param name="action">子查询操作</param>
        void Exists( Action<ISqlBuilder> action );
        /// <summary>
        /// 设置Not Exists查询条件
        /// </summary>
        /// <param name="builder">子查询Sql生成器</param>
        void NotExists( ISqlBuilder builder );
        /// <summary>
        /// 设置Not Exists查询条件
        /// </summary>
        /// <param name="action">子查询操作</param>
        void NotExists( Action<ISqlBuilder> action );
        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendSql( string sql, bool raw );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Where子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IWhereClause Clone( SqlBuilderBase builder );
    }
}
