using System;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Join子句
    /// </summary>
    public interface IJoinClause : ISqlClause {
        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        void Join( string table );
        /// <summary>
        /// 内连接子查询
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        void Join( ISqlBuilder builder, string alias );
        /// <summary>
        /// 内连接子查询
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        void Join( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        void LeftJoin( string table );
        /// <summary>
        /// 左外连接子查询
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        void LeftJoin( ISqlBuilder builder, string alias );
        /// <summary>
        /// 左外连接子查询
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        void LeftJoin( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        void RightJoin( string table );
        /// <summary>
        /// 右外连接子查询
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="alias">表别名</param>
        void RightJoin( ISqlBuilder builder, string alias );
        /// <summary>
        /// 右外连接子查询
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="alias">表别名</param>
        void RightJoin( Action<ISqlBuilder> action, string alias );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="isParameterization">是否参数化</param>
        void On( string column, object value, Operator @operator = Operator.Equal, bool isParameterization = false );
        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendJoin( string sql, bool raw );
        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendLeftJoin( string sql, bool raw );
        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendRightJoin( string sql, bool raw );
        /// <summary>
        /// 添加到On子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        void AppendOn( string sql, bool raw );
        /// <summary>
        /// 清理
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Join子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        IJoinClause Clone( SqlBuilderBase builder );
    }
}
