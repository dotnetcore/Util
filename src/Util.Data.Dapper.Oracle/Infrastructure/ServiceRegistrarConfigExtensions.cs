using Util.Infrastructure;

namespace Util.Data.Dapper.Infrastructure;

/// <summary>
/// Oracle Dapper服务注册器配置扩展
/// </summary>
public static class ServiceRegistrarConfigExtensions {
    /// <summary>
    /// 启用Oracle Dapper服务注册器
    /// </summary>
    /// <param name="config">服务注册器配置</param>
    public static ServiceRegistrarConfig EnableOracleDapperServiceRegistrar( this ServiceRegistrarConfig config ) {
        ServiceRegistrarConfig.Enable( OracleDapperServiceRegistrar.ServiceName );
        return config;
    }

    /// <summary>
    ///禁用Oracle Dapper服务注册器
    /// </summary>
    /// <param name="config">服务注册器配置</param>
    public static ServiceRegistrarConfig DisableOracleDapperServiceRegistrar( this ServiceRegistrarConfig config ) {
        ServiceRegistrarConfig.Disable( OracleDapperServiceRegistrar.ServiceName );
        return config;
    }
}