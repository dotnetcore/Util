using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Conditions;

namespace Util.Datas.Sql.Queries {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public abstract class SqlQueryBase : ISqlQuery {
        /// <summary>
        /// 数据库
        /// </summary>
        private readonly IDatabase _database;
        /// <summary>
        /// Sql生成器
        /// </summary>
        private ISqlBuilder _builder;

        /// <summary>
        /// 初始化Sql查询对象
        /// </summary>
        /// <param name="database">数据库</param>
        protected SqlQueryBase( IDatabase database = null ) {
            _database = database;
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public virtual ISqlBuilder NewBuilder() {
            return GetBuilder().New();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract TResult To<TResult>( IDbConnection connection = null );

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">实体类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract Task<TResult> ToAsync<TResult>( IDbConnection connection = null );

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected abstract ISqlBuilder CreateBuilder();

        /// <summary>
        /// 获取Sql生成器
        /// </summary>
        protected ISqlBuilder GetBuilder() {
            return _builder ?? ( _builder = CreateBuilder() );
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connection">数据库连接</param>
        protected IDbConnection GetConnection( IDbConnection connection ) {
            if( connection != null )
                return connection;
            connection = _database?.GetConnection();
            if( connection == null )
                throw new ArgumentNullException( nameof( connection ) );
            return connection;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery Select( string columns, string alias = null ) {
            GetBuilder().Select( columns, alias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery Select<TEntity>( Expression<Func<TEntity, object[]>> columns, string alias = null ) where TEntity : class {
            GetBuilder().Select( columns, alias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="column">列名，范例：t => t.A</param>
        /// <param name="columnAlias">列别名</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery Select<TEntity>( Expression<Func<TEntity, object>> column, string columnAlias = null, string tableAlias = null ) where TEntity : class {
            GetBuilder().Select( column, columnAlias, tableAlias );
            return this;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendSelect( string sql ) {
            GetBuilder().AppendSelect( sql );
            return this;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery From( string table, string alias = null ) {
            GetBuilder().From( table, alias );
            return this;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery From<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            GetBuilder().From<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendFrom( string sql ) {
            GetBuilder().AppendFrom( sql );
            return this;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery Join( string table, string alias = null ) {
            GetBuilder().Join( table, alias );
            return this;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery Join<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            GetBuilder().Join<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendJoin( string sql ) {
            GetBuilder().AppendJoin( sql );
            return this;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery LeftJoin( string table, string alias = null ) {
            GetBuilder().LeftJoin( table, alias );
            return this;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery LeftJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            GetBuilder().LeftJoin<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendLeftJoin( string sql ) {
            GetBuilder().AppendLeftJoin( sql );
            return this;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery RightJoin( string table, string alias = null ) {
            GetBuilder().RightJoin( table, alias );
            return this;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery RightJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            GetBuilder().RightJoin<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendRightJoin( string sql ) {
            GetBuilder().AppendRightJoin( sql );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public ISqlQuery On( string left, string right, Operator @operator = Operator.Equal ) {
            GetBuilder().On( left, right, @operator );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public ISqlQuery On<TLeft, TRight>( Expression<Func<TLeft, object>> left,Expression<Func<TRight, object>> right, Operator @operator = Operator.Equal )
            where TLeft : class where TRight : class {
            GetBuilder().On( left, right, @operator );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="expression">条件表达式</param>
        public ISqlQuery On<TLeft, TRight>( Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class {
            GetBuilder().On( expression );
            return this;
        }

        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlQuery And( ICondition condition ) {
            GetBuilder().And( condition );
            return this;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlQuery Or( ICondition condition ) {
            GetBuilder().Or( condition );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery Where<TEntity>( Expression<Func<TEntity, bool>> expression, string tableAlias = null ) where TEntity : class {
            GetBuilder().Where( expression, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery Where<TEntity>( Expression<Func<TEntity, object>> expression, object value,
            Operator @operator = Operator.Equal, string tableAlias = null ) where TEntity : class {
            GetBuilder().Where( expression, value, @operator, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery Where( string column, object value, Operator @operator = Operator.Equal, string tableAlias = null ) {
            GetBuilder().Where( column, value, @operator, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition, string tableAlias = null ) where TEntity : class {
            GetBuilder().WhereIf( expression, condition, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition,
            Operator @operator = Operator.Equal, string tableAlias = null ) where TEntity : class {
            GetBuilder().WhereIf( expression, value, condition, @operator, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal, string tableAlias = null ) {
            GetBuilder().WhereIf( column, value, condition, @operator, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression,string tableAlias = null ) where TEntity : class {
            GetBuilder().WhereIfNotEmpty( expression, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value,
            Operator @operator = Operator.Equal, string tableAlias = null ) where TEntity : class {
            GetBuilder().WhereIfNotEmpty( expression, value, @operator, tableAlias );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal,string tableAlias = null ) {
            GetBuilder().WhereIfNotEmpty( column, value, @operator, tableAlias );
            return this;
        }
    }
}
