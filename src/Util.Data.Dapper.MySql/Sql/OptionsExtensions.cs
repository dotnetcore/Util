using System;
using Util.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// MySql数据库操作扩展
    /// </summary>
    public static class OptionsExtensions {

        #region UseMySqlQuery(配置MySql Sql查询对象)

        /// <summary>
        /// 配置MySql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseMySqlQuery( this Options options ) {
            return options.UseMySqlQuery( "" );
        }

        /// <summary>
        /// 配置MySql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseMySqlQuery( this Options options, string connection ) {
            return options.UseMySqlQuery<ISqlQuery, MySqlQuery>( connection );
        }

        /// <summary>
        /// 配置MySql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseMySqlQuery( this Options options, Action<SqlOptions> setupAction ) {
            return options.UseMySqlQuery<ISqlQuery, MySqlQuery>( setupAction );
        }

        /// <summary>
        /// 配置MySql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseMySqlQuery<TService, TImplementation>( this Options options, string connection )
            where TService : ISqlQuery 
            where TImplementation : MySqlQueryBase, TService {
            return options.UseMySqlQuery<TService, TImplementation>( t => t.ConnectionString( connection ) );
        }

        /// <summary>
        /// 配置MySql Sql查询对象
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseMySqlQuery<TService, TImplementation>( this Options options, Action<SqlOptions> setupAction )
            where TService : ISqlQuery 
            where TImplementation : MySqlQueryBase, TService {
            var sqlOptions = new SqlOptions<TImplementation>();
            setupAction?.Invoke( sqlOptions );
            options.AddExtension( new MySqlQueryOptionsExtension<TService, TImplementation>( sqlOptions ) );
            return options;
        }

        #endregion

        #region UseMySqlExecutor(配置MySql Sql执行器)

        /// <summary>
        /// 配置MySql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseMySqlExecutor( this Options options ) {
            return options.UseMySqlExecutor( "" );
        }

        /// <summary>
        /// 配置MySql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseMySqlExecutor( this Options options, string connection ) {
            return options.UseMySqlExecutor<ISqlExecutor, MySqlExecutor>( connection );
        }

        /// <summary>
        /// 配置MySql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseMySqlExecutor( this Options options, Action<SqlOptions> setupAction ) {
            return options.UseMySqlExecutor<ISqlExecutor, MySqlExecutor>( setupAction );
        }

        /// <summary>
        /// 配置MySql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="connection">数据库连接字符串</param>
        public static Options UseMySqlExecutor<TService, TImplementation>( this Options options, string connection )
            where TService : ISqlExecutor 
            where TImplementation : MySqlExecutorBase, TService {
            return options.UseMySqlExecutor<TService, TImplementation>( t => t.ConnectionString( connection ) );
        }

        /// <summary>
        /// 配置MySql Sql执行器
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseMySqlExecutor<TService, TImplementation>( this Options options, Action<SqlOptions> setupAction )
            where TService : ISqlExecutor
            where TImplementation : MySqlExecutorBase, TService {
            var sqlOptions = new SqlOptions<TImplementation>();
            setupAction?.Invoke( sqlOptions );
            options.AddExtension( new MySqlExecutorOptionsExtension<TService, TImplementation>( sqlOptions ) );
            return options;
        }

        #endregion
    }
}
