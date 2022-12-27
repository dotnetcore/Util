namespace Util.Infrastructure {
    /// <summary>
    /// 启动器配置
    /// </summary>
    public class BootstrapperConfig {
        /// <summary>
        /// 启动时扫描程序集的过滤模式
        /// </summary>
        public static string AssemblySkipPattern { get; set; } = "^System|^Mscorlib|^msvcr120|^Netstandard|^Microsoft|^Autofac|^AutoMapper|^EntityFramework|^Newtonsoft|^Castle|^NLog|^Pomelo|^AspectCore|^Xunit|^Nito|^Npgsql|^Exceptionless|^MySqlConnector|^Anonymously Hosted|^libuv|^api-ms|^clrcompression|^clretwrc|^clrjit|^coreclr|^dbgshim|^e_sqlite3|^hostfxr|^hostpolicy|^MessagePack|^mscordaccore|^mscordbi|^mscorrc|sni|sos|SOS.NETCore|^sos_amd64|^SQLitePCLRaw|^StackExchange|^Swashbuckle|WindowsBase|ucrtbase|^DotNetCore.CAP|^MongoDB|^Confluent.Kafka|^librdkafka|^EasyCaching|^RabbitMQ|^Consul|^Dapper|^EnyimMemcachedCore|^Pipelines|^DnsClient|^IdentityModel|^zlib|^NSwag|^Humanizer|^NJsonSchema|^Namotion|^ReSharper|^JetBrains|^NuGet|^ProxyGenerator|^testhost";
    }
}
