using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Util.Datas.Ef.Configs;
using Util.Datas.UnitOfWorks;
using Util.Domains.Auditing;
using Util.Exceptions;
using Util.Datas.Ef.Logs;
using Util.Datas.Matedatas;
using Util.Datas.Sql;
using Util.Logs;
using Util.Sessions;

namespace Util.Datas.Ef.Core {
    /// <summary>
    /// 工作单元
    /// </summary>
    public abstract class UnitOfWorkBase : DbContext, IUnitOfWork, IDatabase, IEntityMatedata {

        #region 构造方法

        /// <summary>
        /// 初始化Entity Framework工作单元
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="manager">工作单元服务</param>
        protected UnitOfWorkBase( DbContextOptions options, IUnitOfWorkManager manager )
            : base( options ) {
            manager?.Register( this );
            TraceId = Guid.NewGuid().ToString();
            Session = Util.Security.Sessions.Session.Instance;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }
        /// <summary>
        /// 用户会话
        /// </summary>
        public ISession Session { get; set; }

        #endregion

        #region OnConfiguring(配置)

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">配置生成器</param>
        protected override void OnConfiguring( DbContextOptionsBuilder builder ) {
            EnableLog( builder );
        }

        /// <summary>
        /// 启用日志
        /// </summary>
        protected void EnableLog( DbContextOptionsBuilder builder ) {
            var log = GetLog();
            if( IsEnabled( log ) == false )
                return;
            builder.EnableSensitiveDataLogging();
            builder.UseLoggerFactory( new LoggerFactory( new[] { GetLogProvider( log ) } ) );
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        protected virtual ILog GetLog() {
            try {
                return Log.GetLog( EfLog.TraceLogName );
            }
            catch {
                return Log.Null;
            }
        }

        /// <summary>
        /// 是否启用Ef日志
        /// </summary>
        private bool IsEnabled( ILog log ) {
            return EfConfig.LogLevel != EfLogLevel.Off && log.IsTraceEnabled;
        }

        /// <summary>
        /// 获取日志提供器
        /// </summary>
        protected virtual ILoggerProvider GetLogProvider( ILog log ) {
            return new EfLogProvider( log, this );
        }

        #endregion

        #region Commit(提交)

        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        public int Commit() {
            try {
                return SaveChanges();
            }
            catch( DbUpdateConcurrencyException ex ) {
                throw new ConcurrencyException( ex );
            }
        }

        #endregion

        #region CommitAsync(异步提交)
        /// <summary>
        /// 异步提交,返回影响的行数
        /// </summary>
        public async Task<int> CommitAsync() {
            try {
                return await SaveChangesAsync();
            }
            catch( DbUpdateConcurrencyException ex ) {
                throw new ConcurrencyException( ex );
            }
        }
        #endregion

        #region OnModelCreating(配置映射)

        /// <summary>
        /// 配置映射
        /// </summary>
        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            foreach( IMap mapper in GetMaps() )
                mapper.Map( modelBuilder );
        }

        /// <summary>
        /// 获取映射配置列表
        /// </summary>
        private IEnumerable<IMap> GetMaps() {
            var result = new List<IMap>();
            foreach( var assembly in GetAssemblies() )
                result.AddRange( GetMapTypes( assembly ) );
            return result;
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        protected virtual Assembly[] GetAssemblies() {
            return new[] { GetType().Assembly };
        }

        /// <summary>
        /// 获取映射类型列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        protected virtual IEnumerable<IMap> GetMapTypes( Assembly assembly ) {
            return Util.Helpers.Reflection.GetInstancesByInterface<IMap>( assembly );
        }

        #endregion

        #region SaveChanges(保存更改)

        /// <summary>
        /// 保存更改
        /// </summary>
        public override int SaveChanges() {
            SaveChangesBefore();
            return base.SaveChanges();
        }

        /// <summary>
        /// 保存更改前操作
        /// </summary>
        protected virtual void SaveChangesBefore() {
            foreach( var entry in ChangeTracker.Entries() ) {
                switch( entry.State ) {
                    case EntityState.Added:
                        InterceptAddedOperation( entry );
                        break;
                    case EntityState.Modified:
                        InterceptModifiedOperation( entry );
                        break;
                    case EntityState.Deleted:
                        InterceptDeletedOperation( entry );
                        break;
                }
            }
        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        protected virtual void InterceptAddedOperation( EntityEntry entry ) {
            InitCreationAudited( entry );
            InitModificationAudited( entry );
        }

        /// <summary>
        /// 初始化创建审计信息
        /// </summary>
        private void InitCreationAudited( EntityEntry entry ) {
            CreationAuditedInitializer.Init( entry.Entity, GetSession() );
        }

        /// <summary>
        /// 获取用户会话
        /// </summary>
        protected virtual ISession GetSession() {
            return Session;
        }

        /// <summary>
        /// 初始化修改审计信息
        /// </summary>
        private void InitModificationAudited( EntityEntry entry ) {
            ModificationAuditedInitializer.Init( entry.Entity, GetSession() );
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        protected virtual void InterceptModifiedOperation( EntityEntry entry ) {
            InitModificationAudited( entry );
        }

        /// <summary>
        /// 拦截删除操作
        /// </summary>
        protected virtual void InterceptDeletedOperation( EntityEntry entry ) {
        }

        #endregion

        #region SaveChangesAsync(异步保存更改)
        /// <summary>
        /// 异步保存更改
        /// </summary>
        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default( CancellationToken ) ) {
            SaveChangesBefore();
            return base.SaveChangesAsync( cancellationToken );
        }
        #endregion

        #region GetConnection(获取数据库连接)

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        public IDbConnection GetConnection() {
            return Database.GetDbConnection();
        }

        #endregion

        #region 获取元数据

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetTable( Type entity ) {
            if ( entity == null )
                return null;
            var entityType = Model.FindEntityType( entity );
            return entityType?.FindAnnotation( "Relational:TableName" )?.Value.SafeString();
        }

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetSchema( Type entity ) {
            if( entity == null )
                return null;
            var entityType = Model.FindEntityType( entity );
            return entityType?.FindAnnotation( "Relational:Schema" )?.Value.SafeString();
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <param name="property">属性名</param>
        public string GetColumn( Type entity, string property ) {
            if( entity == null || string.IsNullOrWhiteSpace( property ) )
                return null;
            var entityType = Model.FindEntityType( entity );
            var result = entityType?.GetProperty( property )?.FindAnnotation( "Relational:ColumnName" )?.Value.SafeString();
            return string.IsNullOrWhiteSpace( result ) ? property : result;
        }

        #endregion
    }
}
