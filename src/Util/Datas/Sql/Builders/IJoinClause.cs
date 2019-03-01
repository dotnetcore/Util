using System;
using System.Linq.Expressions;
using Util.Datas.Queries;

namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Join子句
    /// </summary>
    public interface IJoinClause {
        /// <summary>
        /// 复制Join子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="register">实体别名注册器</param>
        /// <param name="parameterManager">参数管理器</param>
        IJoinClause Clone( ISqlBuilder sqlBuilder, IEntityAliasRegister register, IParameterManager parameterManager );
        /// <summary>
        /// 查找连接项
        /// </summary>
        /// <param name="type">表实体类型</param>
        IJoinOn Find( Type type );
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
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendRightJoin( string sql );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="condition">连接条件</param>
        void On( ICondition condition );
        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        void On( string column, object value, Operator @operator = Operator.Equal );
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
        /// 添加到On子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        void AppendOn( string sql );
        /// <summary>
        /// 输出Sql
        /// </summary>
        string ToSql();
    }
}
