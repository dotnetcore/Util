namespace Util.Caching.EasyCaching;

/// <summary>
/// EasyCaching配置
/// </summary>
internal class CachingOptions {
    /// <summary>
    /// Redis服务端点列表
    /// </summary>
    private static List<ServerEndPoint> _redisEndPoints = new();

    /// <summary>
    /// 添加Redis服务端点
    /// </summary>
    /// <param name="configuration">配置</param>
    /// <param name="section">配置节名称</param>
    public static void AddRedisEndPoints( IConfiguration configuration, string section ) {
        var config = configuration.GetSection( $"{section}:DbConfig:Endpoints" );
        var endpoints = config.GetChildren();
        foreach( var endpoint in endpoints ) {
            var host = endpoint["Host"];
            var port = endpoint["Port"].ToIntOrNull() ?? 6379;
            _redisEndPoints.Add( new ServerEndPoint( host, port ) );
        }
    }

    /// <summary>
    /// 添加Redis服务端点
    /// </summary>
    /// <param name="setupAction">配置操作</param>
    public static void AddRedisEndPoints( Action<RedisOptions> setupAction ) {
        setupAction.CheckNull( nameof( setupAction ) );
        var options = new RedisOptions();
        setupAction( options );
        _redisEndPoints.AddRange( options.DBConfig.Endpoints );
    }

    /// <summary>
    /// 获取Redis服务端点列表
    /// </summary>
    public static List<ServerEndPoint> GetRedisEndPoints() {
        return _redisEndPoints;
    }

    /// <summary>
    /// 清理
    /// </summary>
    public static void Clear() {
        _redisEndPoints = null;
    }
}