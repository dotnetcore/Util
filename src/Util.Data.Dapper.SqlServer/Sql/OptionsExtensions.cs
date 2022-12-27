using System;
using Util.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql Server数据库操作扩展
    /// </summary>
    public static class OptionsExtensions {

        #region UseSqlServerSqlQuery(配置Sql Server Sql查询对象)

        /// <summary>
        /// 配置Sql Server Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseSqlServerSqlQuery( this Options options ) {
            return options.UseSqlServerSqlQuery( "" );
        }

        /// <summary>
        /// 配置Sql Server Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseSqlServerSqlQuery( this Options options, string connection ) {
            return options.UseSqlServerSqlQuery<ISqlQuery, SqlServerSqlQuery>( connection );
        }

        /// <summary>
        /// 配置Sql Server Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseSqlServerSqlQuery( this Options options, Action<SqlOptions> setupAction ) {
            return options.UseSqlServerSqlQuery<ISqlQuery, SqlServerSqlQuery>( setupAction );
        }

        /// <summary>
        /// 配置Sql Server Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseSqlServerSqlQuery<TService, TImplementation>( this Options options, string connection )
            where TService : ISqlQuery 
            where TImplementation : SqlServerSqlQueryBase, TService {
            return options.UseSqlServerSqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
        }

        /// <summary>
        /// 配置Sql Server Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseSqlServerSqlQuery<TService, TImplementation>( this Options options, Action<SqlOptions> setupAction )
            where TService : ISqlQuery 
            where TImplementation : SqlServerSqlQueryBase, TService {
            var sqlOptions = new SqlOptions<TImplementation>();
            setupAction?.Invoke( sqlOptions );
            options.AddExtension( new SqlServerSqlQueryOptionsExtension<TService, TImplementation>( sqlOptions ) );
            return options;
        }

        #endregion

        #region UseSqlServerSqlExecutor(配置Sql Server Sql执行器)

        /// <summary>
        /// 配置Sql Server Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseSqlServerSqlExecutor( this Options options ) {
            return options.UseSqlServerSqlExecutor( "" );
        }

        /// <summary>
        /// 配置Sql Server Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseSqlServerSqlExecutor( this Options options, string connection ) {
            return options.UseSqlServerSqlExecutor<ISqlExecutor, SqlServerSqlExecutor>( connection );
        }

        /// <summary>
        /// 配置Sql Server Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseSqlServerSqlExecutor( this Options options, Action<SqlOptions> setupAction ) {
            return options.UseSqlServerSqlExecutor<ISqlExecutor, SqlServerSqlExecutor>( setupAction );
        }

        /// <summary>
        /// 配置Sql Server Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseSqlServerSqlExecutor<TService, TImplementation>( this Options options, string connection )
            where TService : ISqlExecutor 
            where TImplementation : SqlServerSqlExecutorBase, TService {
            return options.UseSqlServerSqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
        }

        /// <summary>
        /// 配置Sql Server Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseSqlServerSqlExecutor<TService, TImplementation>( this Options options, Action<SqlOptions> setupAction )
            where TService : ISqlExecutor
            where TImplementation : SqlServerSqlExecutorBase, TService {
            var sqlOptions = new SqlOptions<TImplementation>();
            setupAction?.Invoke( sqlOptions );
            options.AddExtension( new SqlServerSqlExecutorOptionsExtension<TService, TImplementation>( sqlOptions ) );
            return options;
        }

        #endregion
    }
}
