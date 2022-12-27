using System;
using Util.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql数据库操作扩展
    /// </summary>
    public static class OptionsExtensions {

        #region UsePgSqlQuery(配置PostgreSql Sql查询对象)

        /// <summary>
        /// 配置PostgreSql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UsePgSqlQuery( this Options options ) {
            return options.UsePgSqlQuery( "" );
        }

        /// <summary>
        /// 配置PostgreSql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UsePgSqlQuery( this Options options, string connection ) {
            return options.UsePgSqlQuery<ISqlQuery, PostgreSqlQuery>( connection );
        }

        /// <summary>
        /// 配置PostgreSql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UsePgSqlQuery( this Options options, Action<SqlOptions> setupAction ) {
            return options.UsePgSqlQuery<ISqlQuery, PostgreSqlQuery>( setupAction );
        }

        /// <summary>
        /// 配置PostgreSql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UsePgSqlQuery<TService, TImplementation>( this Options options, string connection )
            where TService : ISqlQuery 
            where TImplementation : PostgreSqlQueryBase, TService {
            return options.UsePgSqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
        }

        /// <summary>
        /// 配置PostgreSql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UsePgSqlQuery<TService, TImplementation>( this Options options, Action<SqlOptions> setupAction )
            where TService : ISqlQuery 
            where TImplementation : PostgreSqlQueryBase, TService {
            var sqlOptions = new SqlOptions<TImplementation>();
            setupAction?.Invoke( sqlOptions );
            options.AddExtension( new PostgreSqlQueryOptionsExtension<TService, TImplementation>( sqlOptions ) );
            return options;
        }

        #endregion

        #region UsePgSqlExecutor(配置PostgreSql Sql执行器)

        /// <summary>
        /// 配置PostgreSql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UsePgSqlExecutor( this Options options ) {
            return options.UsePgSqlExecutor( "" );
        }

        /// <summary>
        /// 配置PostgreSql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UsePgSqlExecutor( this Options options, string connection ) {
            return options.UsePgSqlExecutor<ISqlExecutor, PostgreSqlExecutor>( connection );
        }

        /// <summary>
        /// 配置PostgreSql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UsePgSqlExecutor( this Options options, Action<SqlOptions> setupAction ) {
            return options.UsePgSqlExecutor<ISqlExecutor, PostgreSqlExecutor>( setupAction );
        }

        /// <summary>
        /// 配置PostgreSql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UsePgSqlExecutor<TService, TImplementation>( this Options options, string connection )
            where TService : ISqlExecutor 
            where TImplementation : PostgreSqlExecutorBase, TService {
            return options.UsePgSqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
        }

        /// <summary>
        /// 配置PostgreSql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UsePgSqlExecutor<TService, TImplementation>( this Options options, Action<SqlOptions> setupAction )
            where TService : ISqlExecutor
            where TImplementation : PostgreSqlExecutorBase, TService {
            var sqlOptions = new SqlOptions<TImplementation>();
            setupAction?.Invoke( sqlOptions );
            options.AddExtension( new PostgreSqlExecutorOptionsExtension<TService, TImplementation>( sqlOptions ) );
            return options;
        }

        #endregion
    }
}
