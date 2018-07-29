using System;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders;
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
        public ISqlQuery Select<TEntity>( Expression<Func<TEntity, object[]>> columns, string alias = null ) {
            GetBuilder().Select( columns, alias );
            return this;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public ISqlQuery From( string table, string alias = null, string schema = null ) {
            GetBuilder().From( table, alias, schema );
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
        /// 设置条件
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="value">值</param>
        /// <param name="operator">运算符</param>
        /// <param name="tableAlias">表别名</param>
        public ISqlQuery Where( string column, object value, Operator @operator = Operator.Equal,string tableAlias = null ) {
            GetBuilder().Where( column, value, @operator, tableAlias );
            return this;
        }
    }
}
