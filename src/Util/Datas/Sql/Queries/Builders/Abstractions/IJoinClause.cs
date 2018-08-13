using System;
using System.Linq.Expressions;
using Util.Datas.Queries;

namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// 表连接子句
    /// </summary>
    public interface IJoinClause {
        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        void Join( string table, string alias = null );
        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        void Join<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendJoin( string sql );
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        void LeftJoin( string table, string alias = null );
        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        void LeftJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendLeftJoin( string sql );
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        void RightJoin( string table, string alias = null );
        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        void RightJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class;
        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendRightJoin( string sql );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        void On( string left, string right, Operator @operator = Operator.Equal );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        void On<TLeft, TRight>( Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right, Operator @operator = Operator.Equal ) where TLeft : class where TRight : class;
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="expression">条件表达式</param>
        void On<TLeft, TRight>( Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class;
        /// <summary>
        /// 输出Sql
        /// </summary>
        string ToSql();
    }
}
