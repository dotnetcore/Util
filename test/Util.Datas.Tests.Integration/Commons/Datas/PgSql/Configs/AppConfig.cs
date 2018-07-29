using Util.Dependency;

namespace Util.Datas.Tests.Commons.Datas.PgSql.Configs {
    /// <summary>
    /// 测试应用程序配置
    /// </summary>
    public static class AppConfig {
        /// <summary>
        /// PgSql测试容器
        /// </summary>
        public static IContainer Container { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public const string Connection = "server=192.168.244.138;User Id=postgres;password=sa;database=UtilTest";
        /// <summary>
        /// 当前用户编号
        /// </summary>
        public const string UserId = "71B18059-7572-4EC3-8B11-2BAA0D0F6169";
    }
}
