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
        public static TOptions Get<TOptions>( string section ) {
            return GetSection( section ).Get<TOptions>();
        }

        /// <summary>
        /// 获取配置节
        /// </summary>
        /// <param name="section">配置节</param>
        public static IConfigurationSection GetSection( string section ) {
            return GetConfiguration().GetSection( section );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        private static IConfiguration GetConfiguration() {
            return _configuration ??= CreateConfiguration();
        }

        /// <summary>
        /// 创建配置
        /// </summary>
        private static IConfiguration CreateConfiguration() {
            var builder = new ConfigurationBuilder()
                .SetBasePath( Platform.ApplicationBaseDirectory )
                .AddJsonFile( "appsettings.json", true, true );
            var environment = Environment.GetEnvironmentName();
            if ( environment.IsEmpty() == false )
                builder.AddJsonFile( $"appsettings.{environment}.json", true, true );
            return builder.Build();
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="name">数据库连接字符串键名</param>
        public static string GetConnectionString( string name ) {
            return GetConfiguration().GetConnectionString( name );
        }
    }
}
