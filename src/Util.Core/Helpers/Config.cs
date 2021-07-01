using Microsoft.Extensions.Configuration;

namespace Util.Helpers {
    /// <summary>
    /// 配置操作
    /// </summary>
    public static class Config {
        /// <summary>
        /// 配置
        /// </summary>
        private static IConfiguration _configuration;

        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="configuration">配置</param>
        public static void SetConfiguration( IConfiguration configuration ) {
            _configuration = configuration;
        }

        /// <summary>
        /// 获取配置选项
        /// </summary>
        /// <typeparam name="TOptions">配置选项类型</typeparam>
        /// <param name="section">配置节</param>
        /// <param name="configFileName">配置文件名,默认值: appsettings.json</param>
        public static TOptions Get<TOptions>( string section,string configFileName = "appsettings.json" ) {
            var configuration = GetConfiguration( configFileName );
            return Get<TOptions>( configuration, section );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private static IConfiguration GetConfiguration( string configFileName ) {
            if ( _configuration != null )
                return _configuration;
            return CreateConfiguration( configFileName );
        }

        /// <summary>
        /// 创建配置
        /// </summary>
        private static IConfiguration CreateConfiguration( string configFileName ) {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath( Platform.ApplicationBaseDirectory ).AddJsonFile( configFileName );
            return builder.Build();
        }

        /// <summary>
        /// 获取配置选项
        /// </summary>
        private static TOptions Get<TOptions>( IConfiguration configuration, string section ) {
            return configuration.GetSection( section ).Get<TOptions>();
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="name">数据库连接字符串键名</param>
        public static string GetConnectionString( string name ) {
            var configuration = GetConfiguration( "appsettings.json" );
            return configuration.GetConnectionString( name );
        }
    }
}
