using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Domains.Repositories;

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
        /// 初始化Sql查询对象
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="database">数据库</param>
        protected SqlQueryBase( ISqlBuilder sqlBuilder, IDatabase database = null ) {
            Builder = sqlBuilder ?? throw new ArgumentNullException( nameof( sqlBuilder ) );
            _database = database;
        }

        /// <summary>
        /// Sql生成器
        /// </summary>
        protected ISqlBuilder Builder { get; }
        /// <summary>
        /// 参数列表
        /// </summary>
        protected IDictionary<string, object> Params => Builder.GetParams();

        /// <summary>
        /// 清空并初始化
        /// </summary>
        public void Clear() {
            Builder.Clear();
        }

        /// <summary>
        /// 获取调试Sql语句
        /// </summary>
        public string GetDebugSql() {
            return Builder.ToDebugSql();
        }

        /// <summary>
        /// Sql语句
        /// </summary>
        protected string GetSql() {
            return Builder.ToSql();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public virtual ISqlBuilder NewBuilder() {
            return Builder.New();
        }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public string ToString( IDbConnection connection = null ) {
            return ToScalar( connection, GetSql(), Params ).SafeString();
        }

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public async Task<string> ToStringAsync( IDbConnection connection = null ) {
            var result = await ToScalarAsync( connection, GetSql(), Params );
            return result.SafeString();
        }

        /// <summary>
        /// 获取整型
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public int ToInt( IDbConnection connection = null ) {
            return Util.Helpers.Convert.ToInt( ToScalar( connection, GetSql(), Params ) );
        }

        /// <summary>
        /// 获取整型
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public async Task<int> ToIntAsync( IDbConnection connection = null ) {
            return Util.Helpers.Convert.ToInt( await ToScalarAsync( connection, GetSql(), Params ) );
        }

        /// <summary>
        /// 获取可空整型
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public int? ToIntOrNull( IDbConnection connection = null ) {
            return Util.Helpers.Convert.ToIntOrNull( ToScalar( connection, GetSql(), Params ) );
        }

        /// <summary>
        /// 获取可空整型
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public async Task<int?> ToIntOrNullAsync( IDbConnection connection = null ) {
            return Util.Helpers.Convert.ToIntOrNull( await ToScalarAsync( connection, GetSql(), Params ) );
        }

        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        protected abstract object ToScalar( IDbConnection connection, string sql, IDictionary<string, object> parameters );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        protected abstract Task<object> ToScalarAsync( IDbConnection connection, string sql, IDictionary<string, object> parameters );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract TResult To<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract Task<TResult> ToAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract List<TResult> ToList<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="connection">数据库连接</param>
        public abstract Task<List<TResult>> ToListAsync<TResult>( IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public abstract PagerList<TResult> ToPagerList<TResult>( IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        public abstract PagerList<TResult> ToPagerList<TResult>( int page, int pageSize, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="parameter">分页参数</param>
        /// <param name="connection">数据库连接</param>
        public abstract Task<PagerList<TResult>> ToPagerListAsync<TResult>( IPager parameter, IDbConnection connection = null );
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <typeparam name="TResult">返回结果类型</typeparam>
        /// <param name="page">页数</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="connection">数据库连接</param>
        public abstract Task<PagerList<TResult>> ToPagerListAsync<TResult>( int page, int pageSize, IDbConnection connection = null );

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
            Builder.Select( columns, alias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        public ISqlQuery Select<TEntity>( Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias = false ) where TEntity : class {
            Builder.Select( columns, propertyAsAlias );
            return this;
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="column">列名，范例：t => t.A</param>
        /// <param name="columnAlias">列别名</param>
        public ISqlQuery Select<TEntity>( Expression<Func<TEntity, object>> column, string columnAlias = null ) where TEntity : class {
            Builder.Select( column, columnAlias );
            return this;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendSelect( string sql ) {
            Builder.AppendSelect( sql );
            return this;
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        public ISqlQuery AppendSelect( ISqlBuilder builder, string columnAlias = null ) {
            Builder.AppendSelect( builder, columnAlias );
            return this;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery From( string table, string alias = null ) {
            Builder.From( table, alias );
            return this;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery From<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Builder.From<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendFrom( string sql ) {
            Builder.AppendFrom( sql );
            return this;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery Join( string table, string alias = null ) {
            Builder.Join( table, alias );
            return this;
        }

        /// <summary>
        /// 内连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery Join<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Builder.Join<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到内连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendJoin( string sql ) {
            Builder.AppendJoin( sql );
            return this;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery LeftJoin( string table, string alias = null ) {
            Builder.LeftJoin( table, alias );
            return this;
        }

        /// <summary>
        /// 左外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery LeftJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Builder.LeftJoin<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到左外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendLeftJoin( string sql ) {
            Builder.AppendLeftJoin( sql );
            return this;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public ISqlQuery RightJoin( string table, string alias = null ) {
            Builder.RightJoin( table, alias );
            return this;
        }

        /// <summary>
        /// 右外连接
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery RightJoin<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            Builder.RightJoin<TEntity>( alias, schema );
            return this;
        }

        /// <summary>
        /// 添加到右外连接子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendRightJoin( string sql ) {
            Builder.AppendRightJoin( sql );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public ISqlQuery On( string left, string right, Operator @operator = Operator.Equal ) {
            Builder.On( left, right, @operator );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="left">左表列名</param>
        /// <param name="right">右表列名</param>
        /// <param name="operator">条件运算符</param>
        public ISqlQuery On<TLeft, TRight>( Expression<Func<TLeft, object>> left, Expression<Func<TRight, object>> right, Operator @operator = Operator.Equal )
            where TLeft : class where TRight : class {
            Builder.On( left, right, @operator );
            return this;
        }

        /// <summary>
        /// 设置连接条件
        /// </summary>
        /// <param name="expression">条件表达式</param>
        public ISqlQuery On<TLeft, TRight>( Expression<Func<TLeft, TRight, bool>> expression ) where TLeft : class where TRight : class {
            Builder.On( expression );
            return this;
        }

        /// <summary>
        /// And连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlQuery And( ICondition condition ) {
            Builder.And( condition );
            return this;
        }

        /// <summary>
        /// Or连接条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlQuery Or( ICondition condition ) {
            Builder.Or( condition );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public ISqlQuery Where( ICondition condition ) {
            Builder.Where( condition );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public ISqlQuery Where( string column, object value, Operator @operator = Operator.Equal ) {
            Builder.Where( column, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        public ISqlQuery Where<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            Builder.Where( expression, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        public ISqlQuery Where<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            Builder.Where( expression );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public ISqlQuery WhereIf( string column, object value, bool condition, Operator @operator = Operator.Equal ) {
            Builder.WhereIf( column, value, condition, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        /// <param name="operator">运算符</param>
        public ISqlQuery WhereIf<TEntity>( Expression<Func<TEntity, object>> expression, object value, bool condition, Operator @operator = Operator.Equal ) where TEntity : class {
            Builder.WhereIf( expression, value, condition, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public ISqlQuery WhereIf<TEntity>( Expression<Func<TEntity, bool>> expression, bool condition ) where TEntity : class {
            Builder.WhereIf( expression, condition );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public ISqlQuery WhereIfNotEmpty( string column, object value, Operator @operator = Operator.Equal ) {
            Builder.WhereIfNotEmpty( column, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值,如果值为空，则忽略该查询条件</param>
        /// <param name="operator">运算符</param>
        public ISqlQuery WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression, object value, Operator @operator = Operator.Equal ) where TEntity : class {
            Builder.WhereIfNotEmpty( expression, value, @operator );
            return this;
        }

        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="expression">查询条件表达式,如果参数值为空，则忽略该查询条件</param>
        public ISqlQuery WhereIfNotEmpty<TEntity>( Expression<Func<TEntity, bool>> expression ) where TEntity : class {
            Builder.WhereIfNotEmpty( expression );
            return this;
        }

        /// <summary>
        /// 添加到Where子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendWhere( string sql ) {
            Builder.AppendWhere( sql );
            return this;
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery Equal( string column, object value ) {
            Builder.Equal( column, value );
            return this;
        }

        /// <summary>
        /// 设置相等查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery Equal<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.Equal( expression, value );
            return this;
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery NotEqual( string column, object value ) {
            Builder.NotEqual( column, value );
            return this;
        }

        /// <summary>
        /// 设置不相等查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery NotEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.NotEqual( expression, value );
            return this;
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery Greater( string column, object value ) {
            Builder.Greater( column, value );
            return this;
        }

        /// <summary>
        /// 设置大于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery Greater<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.Greater( expression, value );
            return this;
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery Less( string column, object value ) {
            Builder.Less( column, value );
            return this;
        }

        /// <summary>
        /// 设置小于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery Less<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.Less( expression, value );
            return this;
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery GreaterEqual( string column, object value ) {
            Builder.GreaterEqual( column, value );
            return this;
        }

        /// <summary>
        /// 设置大于等于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery GreaterEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.GreaterEqual( expression, value );
            return this;
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery LessEqual( string column, object value ) {
            Builder.LessEqual( column, value );
            return this;
        }

        /// <summary>
        /// 设置小于等于查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery LessEqual<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.LessEqual( expression, value );
            return this;
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery Contains( string column, object value ) {
            Builder.Contains( column, value );
            return this;
        }

        /// <summary>
        /// 设置模糊匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery Contains<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.Contains( expression, value );
            return this;
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery Starts( string column, object value ) {
            Builder.Starts( column, value );
            return this;
        }

        /// <summary>
        /// 设置头匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery Starts<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.Starts( expression, value );
            return this;
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        public ISqlQuery Ends( string column, object value ) {
            Builder.Ends( column, value );
            return this;
        }

        /// <summary>
        /// 设置尾匹配查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="value">值</param>
        public ISqlQuery Ends<TEntity>( Expression<Func<TEntity, object>> expression, object value ) where TEntity : class {
            Builder.Ends( expression, value );
            return this;
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlQuery IsNull( string column ) {
            Builder.IsNull( column );
            return this;
        }

        /// <summary>
        /// 设置Is Null查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlQuery IsNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            Builder.IsNull( expression );
            return this;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlQuery IsNotNull( string column ) {
            Builder.IsNotNull( column );
            return this;
        }

        /// <summary>
        /// 设置Is Not Null查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlQuery IsNotNull<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            Builder.IsNotNull( expression );
            return this;
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlQuery IsEmpty( string column ) {
            Builder.IsEmpty( column );
            return this;
        }

        /// <summary>
        /// 设置空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlQuery IsEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            Builder.IsEmpty( expression );
            return this;
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="column">列名</param>
        public ISqlQuery IsNotEmpty( string column ) {
            Builder.IsNotEmpty( column );
            return this;
        }

        /// <summary>
        /// 设置非空条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        public ISqlQuery IsNotEmpty<TEntity>( Expression<Func<TEntity, object>> expression ) where TEntity : class {
            Builder.IsNotEmpty( expression );
            return this;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public ISqlQuery In( string column, IEnumerable<object> values ) {
            Builder.In( column, values );
            return this;
        }

        /// <summary>
        /// 设置In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        public ISqlQuery In<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            Builder.In( expression, values );
            return this;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="values">值集合</param>
        public ISqlQuery NotIn( string column, IEnumerable<object> values ) {
            Builder.NotIn( column, values );
            return this;
        }

        /// <summary>
        /// 设置Not In条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="values">值集合</param>
        public ISqlQuery NotIn<TEntity>( Expression<Func<TEntity, object>> expression, IEnumerable<object> values ) where TEntity : class {
            Builder.NotIn( expression, values );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between<TEntity>( Expression<Func<TEntity, object>> expression, int? min, int? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            Builder.Between( expression, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between<TEntity>( Expression<Func<TEntity, object>> expression, double? min, double? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            Builder.Between( expression, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between<TEntity>( Expression<Func<TEntity, object>> expression, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            Builder.Between( expression, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between<TEntity>( Expression<Func<TEntity, object>> expression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) where TEntity : class {
            Builder.Between( expression, min, max, includeTime, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between( string column, int? min, int? max, Boundary boundary = Boundary.Both ) {
            Builder.Between( column, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between( string column, double? min, double? max, Boundary boundary = Boundary.Both ) {
            Builder.Between( column, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between( string column, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) {
            Builder.Between( column, min, max, boundary );
            return this;
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public ISqlQuery Between( string column, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) {
            Builder.Between( column, min, max, includeTime, boundary );
            return this;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="group">分组字段</param>
        /// <param name="having">分组条件</param>
        public ISqlQuery GroupBy( string group, string having = null ) {
            Builder.GroupBy( group, having );
            return this;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段</param>
        /// <param name="having">分组条件</param>
        public ISqlQuery GroupBy<TEntity>( Expression<Func<TEntity, object>> column, string having = null ) {
            Builder.GroupBy( column, having );
            return this;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public ISqlQuery AppendGroupBy( string sql ) {
            Builder.AppendGroupBy( sql );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="order">排序列表</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery OrderBy( string order, string tableAlias = null ) {
            Builder.OrderBy( order, tableAlias );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">排序列</param>
        /// <param name="desc">是否倒排</param>
        public ISqlQuery OrderBy<TEntity>( Expression<Func<TEntity, object>> column, bool desc = false ) {
            Builder.OrderBy( column, desc );
            return this;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="order">排序列表</param>
        public ISqlQuery AppendOrderBy( string order ) {
            Builder.AppendOrderBy( order );
            return this;
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        protected virtual int GetCount( IDbConnection connection ) {
            return Util.Helpers.Convert.ToInt( ToScalar( connection, Builder.ToCountSql(), Params ) );
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        protected virtual async Task<int> GetCountAsync( IDbConnection connection ) {
            return Util.Helpers.Convert.ToInt( await ToScalarAsync( connection, Builder.ToCountSql(), Params ) );
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parameters">参数</param>
        protected abstract void WriteTraceLog( string sql, IDictionary<string, object> parameters );
    }
}
