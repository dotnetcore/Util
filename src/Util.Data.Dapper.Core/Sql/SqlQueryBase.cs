using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Util.Data.Properties;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Clauses;
using Util.Data.Sql.Builders.Core;
using Util.Data.Sql.Builders.Params;
using Util.Data.Sql.Builders.Sets;
using Util.Data.Sql.Configs;
using Util.Data.Sql.Database;
using Util.Helpers;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public abstract class SqlQueryBase : ISqlQuery, ISqlPartAccessor, ISqlOptionsAccessor, IGetParameter, IClearParameters, IConnectionManager, ITransactionManager {

        #region 字段

        /// <summary>
        /// 数据库信息
        /// </summary>
        private IDatabase _database;
        /// <summary>
        /// Sql配置
        /// </summary>
        protected readonly SqlOptions Options;
        /// <summary>
        /// Sql生成器
        /// </summary>
        private ISqlBuilder _sqlBuilder;
        /// <summary>
        /// 数据库连接
        /// </summary>
        private IDbConnection _connection;
        /// <summary>
        /// 事务
        /// </summary>
        private IDbTransaction _transaction;
        /// <summary>
        /// Sql结果字符串
        /// </summary>
        private string _sql;
        /// <summary>
        /// 动态参数列表
        /// </summary>
        private DynamicParameters _parameters;
        /// <summary>
        /// 参数字面值解析器
        /// </summary>
        private IParamLiteralsResolver _paramLiteralsResolver;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Sql查询对象
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected SqlQueryBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException( nameof( serviceProvider ) );
            Options = options ?? throw new ArgumentNullException( nameof( options ) );
            Logger = CreateLogger();
            _connection = options.Connection;
            _database = database;
            ContextId = Id.Create();
        }

        /// <summary>
        /// 创建日志
        /// </summary>
        private ILogger CreateLogger() {
            var loggerFactory = ServiceProvider.GetService<ILoggerFactory>();
            if ( loggerFactory == null )
                return NullLogger.Instance;
            return loggerFactory.CreateLogger( Options.LogCategory );
        }

        #endregion

        #region 属性

        /// <summary>
        /// 上下文标识
        /// </summary>
        public string ContextId { get; private set; }
        /// <summary>
        /// 服务提供器
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }
        /// <summary>
        /// 日志操作
        /// </summary>
        protected ILogger Logger { get; }
        /// <summary>
        /// 数据库信息
        /// </summary>
        protected IDatabase Database => _database ??= CreateDatabase();
        /// <summary>
        /// Sql生成器
        /// </summary>
        public ISqlBuilder SqlBuilder => _sqlBuilder ??= CreateSqlBuilder();
        /// <summary>
        /// Sql方言
        /// </summary>
        public IDialect Dialect => ( (ISqlPartAccessor)SqlBuilder ).Dialect;
        /// <summary>
        /// 参数管理器
        /// </summary>
        public IParameterManager ParameterManager => ( (ISqlPartAccessor)SqlBuilder ).ParameterManager;
        /// <summary>
        /// 参数字面值解析器
        /// </summary>
        protected IParamLiteralsResolver ParamLiteralsResolver => _paramLiteralsResolver ??= CreateParamLiteralsResolver();
        /// <summary>
        /// 起始子句
        /// </summary>
        public IStartClause StartClause => ( (ISqlPartAccessor)SqlBuilder ).StartClause;
        /// <summary>
        /// Insert子句
        /// </summary>
        public IFromClause FromClause => ( (ISqlPartAccessor)SqlBuilder ).FromClause;
        /// <summary>
        /// Join子句
        /// </summary>
        public IJoinClause JoinClause => ( (ISqlPartAccessor)SqlBuilder ).JoinClause;
        /// <summary>
        /// Where子句
        /// </summary>
        public IWhereClause WhereClause => ( (ISqlPartAccessor)SqlBuilder ).WhereClause;
        /// <summary>
        /// GroupBy子句
        /// </summary>
        public IInsertClause InsertClause => ( (ISqlPartAccessor)SqlBuilder ).InsertClause;
        /// <summary>
        /// Select子句
        /// </summary>
        public ISelectClause SelectClause => ( (ISqlPartAccessor)SqlBuilder ).SelectClause;
        /// <summary>
        /// From子句
        /// </summary>
        public IGroupByClause GroupByClause => ( (ISqlPartAccessor)SqlBuilder ).GroupByClause;
        /// <summary>
        /// OrderBy子句
        /// </summary>
        public IOrderByClause OrderByClause => ( (ISqlPartAccessor)SqlBuilder ).OrderByClause;
        /// <summary>
        /// 结束子句
        /// </summary>
        public IEndClause EndClause => ( (ISqlPartAccessor)SqlBuilder ).EndClause;
        /// <summary>
        /// Sql生成器集合
        /// </summary>
        public ISqlBuilderSet SqlBuilderSet => ( (ISqlPartAccessor)SqlBuilder ).SqlBuilderSet;
        /// <summary>
        /// 获取动态参数列表
        /// </summary>
        protected DynamicParameters Params {
            get {
                _parameters = new DynamicParameters();
                ParameterManager.GetParams().ToList().ForEach( t => _parameters.Add( t.Name, t.Value, t.DbType, t.Direction, t.Size, t.Precision, t.Scale ) );
                ParameterManager.GetDynamicParams().ToList().ForEach( p => _parameters.AddDynamicParams( p ) );
                return _parameters;
            }
        }

        /// <inheritdoc />
        public SqlBuilderResult PreviousSql { get; private set; }

        #endregion

        #region 工厂方法

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected abstract ISqlBuilder CreateSqlBuilder();

        /// <summary>
        /// 创建数据库信息
        /// </summary>
        protected virtual IDatabase CreateDatabase() {
            if ( Options.ConnectionString.IsEmpty() )
                throw new InvalidOperationException( UtilDataDapperResource.ConnectionIsEmpty );
            var factory = CreateDatabaseFactory();
            if ( factory == null )
                throw new InvalidOperationException( UtilDataDapperResource.DatabaseFactoryIsNull );
            return factory.Create( Options.ConnectionString );
        }

        /// <summary>
        /// 创建数据库工厂
        /// </summary>
        protected abstract IDatabaseFactory CreateDatabaseFactory();

        /// <summary>
        /// 创建判断是否存在Sql生成器
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        protected abstract IExistsSqlBuilder CreatExistsSqlBuilder( ISqlBuilder sqlBuilder );

        /// <summary>
        /// 创建参数字面值解析器
        /// </summary>
        protected virtual IParamLiteralsResolver CreateParamLiteralsResolver() {
            return new ParamLiteralsResolver();
        }

        #endregion

        #region GetOptions(获取Sql配置)

        /// <summary>
        /// 获取Sql配置
        /// </summary>
        public SqlOptions GetOptions() {
            return Options;
        }

        #endregion

        #region GetParam(获取Sql参数值)

        /// <summary>
        /// 获取Sql参数值
        /// </summary>
        /// <typeparam name="T">参数值类型</typeparam>
        /// <param name="name">参数名</param>
        public virtual T GetParam<T>( string name ) {
            if ( _parameters == null && PreviousSql != null )
                return PreviousSql.GetParam<T>( name );
            return Params.Get<T>( name );
        }

        #endregion

        #region ClearParams(清空Sql参数)

        /// <summary>
        /// 清空Sql参数
        /// </summary>
        public void ClearParams() {
            ParameterManager.Clear();
            _parameters = null;
        }

        #endregion

        #region GetConnection(获取数据库连接)

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        public IDbConnection GetConnection() {
            if ( _connection != null )
                return _connection;
            _connection = Database.GetConnection();
            if ( _connection == null )
                throw new InvalidOperationException( UtilDataDapperResource.ConnectionIsEmpty );
            return _connection;
        }

        #endregion

        #region SetConnection(设置数据库连接)

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="connection">数据库连接</param>
        public void SetConnection( IDbConnection connection ) {
            if ( connection == null )
                return;
            _connection = connection;
        }

        #endregion

        #region GetTransaction(获取数据库事务)

        /// <summary>
        /// 获取数据库事务
        /// </summary>
        public IDbTransaction GetTransaction() {
            return _transaction;
        }

        #endregion

        #region SetTransaction(设置数据库事务)

        /// <summary>
        /// 设置数据库事务
        /// </summary>
        /// <param name="transaction">数据库事务</param>
        public void SetTransaction( IDbTransaction transaction ) {
            if ( transaction == null )
                return;
            _transaction = transaction;
            _connection = transaction.Connection;
        }

        #endregion

        #region BeginTransaction(开始事务)

        /// <summary>
        /// 开始事务
        /// </summary>
        public IDbTransaction BeginTransaction() {
            return BeginTransactionImpl( null );
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="isolationLevel">隔离级别</param>
        public IDbTransaction BeginTransaction( IsolationLevel isolationLevel ) {
            return BeginTransactionImpl( isolationLevel );
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        private IDbTransaction BeginTransactionImpl( IsolationLevel? isolationLevel ) {
            try {
                if ( _transaction != null )
                    return _transaction;
                var connection = GetConnection();
                if ( connection.State == ConnectionState.Closed )
                    connection.Open();
                _transaction = isolationLevel == null ? connection.BeginTransaction() : connection.BeginTransaction( isolationLevel.SafeValue() );
                return _transaction;
            }
            catch {
                if ( _connection?.State == ConnectionState.Open )
                    _connection?.Close();
                _transaction?.Dispose();
                throw;
            }
        }

        #endregion

        #region CommitTransaction(提交事务)

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction() {
            try {
                _transaction?.Commit();
            }
            catch {
                _transaction?.Rollback();
                throw;
            }
            finally {
                if ( _connection?.State == ConnectionState.Open )
                    _connection?.Close();
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        #endregion

        #region RollbackTransaction(回滚事务)

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction() {
            try {
                if( _connection.State != ConnectionState.Closed )
                    _transaction?.Rollback();
            }
            finally {
                if ( _connection?.State == ConnectionState.Open )
                    _connection?.Close();
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        #endregion

        #region ExecuteExists(判断是否存在)

        /// <summary>
        /// 判断是否存在
        /// </summary>
        public bool ExecuteExists() {
            object result = null;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = CreatExistsSqlBuilder( SqlBuilder ).GetSql();
                var connection = GetConnection();
                result = connection.ExecuteScalar( GetSql(), Params, GetTransaction() );
                return Util.Helpers.Convert.ToBool( result );
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteExistsAsync(判断是否存在)

        /// <summary>
        /// 判断是否存在
        /// </summary>
        public async Task<bool> ExecuteExistsAsync() {
            object result = null;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = CreatExistsSqlBuilder( SqlBuilder ).GetSql();
                var connection = GetConnection();
                result = await connection.ExecuteScalarAsync( GetSql(), Params, GetTransaction() );
                return Util.Helpers.Convert.ToBool( result );
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteScalar(获取单值)

        /// <summary>
        /// 获取单值
        /// </summary>
        public virtual object ExecuteScalar( int? timeout = null ) {
            object result = null;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.ExecuteScalar( GetSql(), Params, GetTransaction(), timeout );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取单值
        /// </summary>
        public virtual T ExecuteScalar<T>( int? timeout = null ) {
            return Util.Helpers.Convert.To<T>( ExecuteScalar( timeout ) );
        }

        #endregion

        #region ExecuteScalarAsync(获取单值)

        /// <summary>
        /// 获取单值
        /// </summary>
        public virtual async Task<object> ExecuteScalarAsync( int? timeout = null ) {
            object result = null;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = await connection.ExecuteScalarAsync( GetSql(), Params, GetTransaction(), timeout );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取单值
        /// </summary>
        public virtual async Task<T> ExecuteScalarAsync<T>( int? timeout = null ) {
            var result = await ExecuteScalarAsync( timeout );
            return Util.Helpers.Convert.To<T>( result );
        }

        #endregion

        #region ExecuteProcedureScalar(执行存储过程获取单值)

        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public virtual object ExecuteProcedureScalar( string procedure, int? timeout = null ) {
            object result = null;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.ExecuteScalar( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }



        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public virtual T ExecuteProcedureScalar<T>( string procedure, int? timeout = null ) {
            return Util.Helpers.Convert.To<T>( ExecuteProcedureScalar( procedure, timeout ) );
        }

        #endregion

        #region ExecuteProcedureScalarAsync(执行存储过程获取单值)

        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public virtual async Task<object> ExecuteProcedureScalarAsync( string procedure, int? timeout = null ) {
            object result = null;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = await connection.ExecuteScalarAsync( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public virtual async Task<T> ExecuteProcedureScalarAsync<T>( string procedure, int? timeout = null ) {
            var result = await ExecuteProcedureScalarAsync( procedure, timeout );
            return Util.Helpers.Convert.To<T>( result );
        }

        #endregion

        #region ExecuteSingle(获取单个实体)

        /// <summary>
        /// 获取单个实体
        /// </summary>
        public virtual TEntity ExecuteSingle<TEntity>( int? timeout = null ) {
            TEntity result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.QueryFirstOrDefault<TEntity>( GetSql(), Params, GetTransaction(), timeout );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteSingleAsync(获取单个实体)

        /// <summary>
        /// 获取单个实体
        /// </summary>
        public virtual async Task<TEntity> ExecuteSingleAsync<TEntity>( int? timeout = null ) {
            TEntity result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = await connection.QueryFirstOrDefaultAsync<TEntity>( GetSql(), Params, GetTransaction(), timeout );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteProcedureSingle(执行存储过程获取单个实体)

        /// <summary>
        /// 执行存储过程获取单个实体
        /// </summary>
        public virtual TEntity ExecuteProcedureSingle<TEntity>( string procedure, int? timeout = null ) {
            TEntity result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.QueryFirstOrDefault<TEntity>( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteProcedureSingleAsync(执行存储过程获取单个实体)

        /// <summary>
        /// 执行存储过程获取单个实体
        /// </summary>
        public virtual async Task<TEntity> ExecuteProcedureSingleAsync<TEntity>( string procedure, int? timeout = null ) {
            TEntity result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = await connection.QueryFirstOrDefaultAsync<TEntity>( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() );
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteQuery(获取实体集合)

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<dynamic> ExecuteQuery( int? timeout = null, bool buffered = true ) {
            List<dynamic> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), Params, GetTransaction(), buffered, timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<TEntity>( int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query<TEntity>( GetSql(), Params, GetTransaction(), buffered, timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<T1, T2, TEntity>( Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<T1, T2, T3, TEntity>( Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<T1, T2, T3, T4, TEntity>( Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<T1, T2, T3, T4, T5, TEntity>( Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<T1, T2, T3, T4, T5, T6, TEntity>( Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteQuery<T1, T2, T3, T4, T5, T6, T7, TEntity>( Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteQueryAsync(获取实体集合)

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<dynamic>> ExecuteQueryAsync( int? timeout = null ) {
            List<dynamic> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), Params, GetTransaction(), timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<TEntity>( int? timeout = null ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync<TEntity>( GetSql(), Params, GetTransaction(), timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<T1, T2, TEntity>( Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, TEntity>( Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, TEntity>( Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, T5, TEntity>( Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, T5, T6, TEntity>( Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, T5, T6, T7, TEntity>( Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteProcedureQuery(执行存储过程获取实体集合)

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<dynamic> ExecuteProcedureQuery( string procedure, int? timeout = null, bool buffered = true ) {
            List<dynamic> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), Params, GetTransaction(), buffered, timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<TEntity>( string procedure, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query<TEntity>( GetSql(), Params, GetTransaction(), buffered, timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<T1, T2, TEntity>( string procedure, Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<T1, T2, T3, TEntity>( string procedure, Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, TEntity>( string procedure, Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, T5, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, T5, T6, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, T5, T6, T7, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = connection.Query( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region ExecuteProcedureQueryAsync(执行存储过程获取实体集合)

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<dynamic>> ExecuteProcedureQueryAsync( string procedure, int? timeout = null ) {
            List<dynamic> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<TEntity>( string procedure, int? timeout = null ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync<TEntity>( GetSql(), Params, GetTransaction(), timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, TEntity>( string procedure, Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, TEntity>( string procedure, Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, TEntity>( string procedure, Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, T5, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, T5, T6, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        public virtual async Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, T5, T6, T7, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true ) {
            List<TEntity> result = default;
            try {
                if ( ExecuteBefore() == false )
                    return default;
                _sql = GetProcedure( procedure );
                var connection = GetConnection();
                result = ( await connection.QueryAsync( GetSql(), map, Params, GetTransaction(), buffered, "Id", timeout, GetProcedureCommandType() ) ).ToList();
                return result;
            }
            finally {
                ExecuteAfter( result );
            }
        }

        #endregion

        #region 钩子方法

        /// <summary>
        /// 执行前操作,返回false停止执行
        /// </summary>
        protected virtual bool ExecuteBefore() {
            return true;
        }

        /// <summary>
        /// 执行后操作
        /// </summary>
        /// <param name="result">结果</param>
        protected virtual void ExecuteAfter( object result ) {
            SetPreviousSql();
            Clear();
            WriteLog();
        }

        #endregion

        #region GetSql(获取Sql语句)

        /// <summary>
        /// 获取Sql语句
        /// </summary>
        public string GetSql() {
            return _sql ??= SqlBuilder.GetSql();
        }

        #endregion

        #region SetSql(设置Sql语句)

        /// <summary>
        /// 设置Sql语句
        /// </summary>
        /// <param name="sql">sql语句或存储过程名</param>
        protected void SetSql( string sql ) {
            _sql = sql;
        }

        #endregion

        #region GetProcedure(获取存储过程名称)

        /// <summary>
        /// 获取存储过程名称
        /// </summary>
        /// <param name="procedure">存储过程</param>
        protected virtual string GetProcedure( string procedure ) {
            return new TableItem( Dialect, procedure ).ToResult();
        }

        #endregion

        #region GetProcedureCommandType(获取存储过程命令类型)

        /// <summary>
        /// 获取存储过程命令类型
        /// </summary>
        protected virtual CommandType GetProcedureCommandType() {
            return CommandType.StoredProcedure;
        }

        #endregion

        #region SetPreviousSql(设置前一次执行的Sql及参数)

        /// <summary>
        /// 设置前一次执行的Sql及参数
        /// </summary>
        protected virtual void SetPreviousSql() {
            var sqlParams = GetSqlParams();
            PreviousSql = new SqlBuilderResult( _sql, sqlParams, ParamLiteralsResolver,ParameterManager );
        }

        #endregion

        #region GetSqlParams(获取Sql参数列表)

        /// <summary>
        /// 获取Sql参数列表
        /// </summary>
        protected List<SqlParam> GetSqlParams() {
            var result = new List<SqlParam>();
            if ( _parameters == null )
                return result;
            foreach ( var parameterName in _parameters.ParameterNames ) {
                if ( ParameterManager.Contains( parameterName ) ) {
                    var param = ParameterManager.GetParam( parameterName );
                    if ( param.Direction != ParameterDirection.Input )
                        param = new SqlParam( param.Name, _parameters.Get<object>( parameterName ), param.DbType, param.Direction, param.Size, param.Precision, param.Scale );
                    result.Add( param );
                    continue;
                }
                var sqlParam = new SqlParam( ParameterManager.NormalizeName( parameterName ), _parameters.Get<object>( parameterName ) );
                result.Add( sqlParam );
            }
            return result;
        }

        #endregion

        #region Clear(清理)

        /// <summary>
        /// 清理
        /// </summary>
        protected void Clear() {
            _sql = null;
            SqlBuilder.Clear();
            ClearParams();
        }

        #endregion

        #region WriteLog(写日志)

        /// <summary>
        /// 写日志
        /// </summary>
        protected virtual void WriteLog() {
            if ( Logger.IsEnabled( LogLevel.Trace ) == false )
                return;
            var message = new StringBuilder();
            message.AppendLine( "标题: {Caption}" );
            message.AppendLine( "原始Sql:" );
            message.AppendLine( "{Sql}" );
            message.AppendLine( "调试Sql:" );
            message.AppendLine( "{DebugSql}" );
            message.AppendLine( "Sql参数:" );
            foreach ( var param in PreviousSql.GetParams() ) {
                message.Append( "参数名: " );
                message.Append( param.Name );
                if ( param.Value != null ) {
                    message.Append( ",参数值: " );
                    message.Append( param.Value );
                }
                if ( param.DbType != null ) {
                    message.Append( ",参数类型: " );
                    message.Append( param.DbType );
                }
                if ( param.Direction != null ) {
                    message.Append( ",参数方向: " );
                    message.Append( param.Direction );
                }
                if ( param.Size != null ) {
                    message.Append( ",Size: " );
                    message.Append( param.Size );
                }
                if ( param.Precision != null ) {
                    message.Append( ",Precision: " );
                    message.Append( param.Precision );
                }
                if ( param.Scale != null ) {
                    message.Append( ",Scale: " );
                    message.Append( param.Scale );
                }
                message.AppendLine();
            }
            Logger.LogTrace( message.ToString(), "Sql日志", PreviousSql.GetSql(), PreviousSql.GetDebugSql() );
        }

        #endregion

        #region Dispose(释放资源)

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose() {
            if ( _connection != null )
                _connection.Dispose();
            _transaction = null;
        }

        #endregion
    }
}
