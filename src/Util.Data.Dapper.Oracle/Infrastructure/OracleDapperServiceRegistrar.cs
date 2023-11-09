using Util.Data.Dapper.TypeHandlers;
using Util.Infrastructure;

namespace Util.Data.Dapper.Infrastructure;

/// <summary>
/// Oracle Dapper服务注册器
/// </summary>
public class OracleDapperServiceRegistrar : IServiceRegistrar {
    /// <summary>
    /// 获取服务名
    /// </summary>
    public static string ServiceName => "Util.Data.Dapper.Infrastructure.OracleDapperServiceRegistrar";

    /// <summary>
    /// 排序号
    /// </summary>
    public int OrderId => 812;

    /// <summary>
    /// 是否启用
    /// </summary>
    public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

    /// <summary>
    /// 注册服务
    /// </summary>
    /// <param name="serviceContext">服务上下文</param>
    public Action Register( ServiceContext serviceContext ) {
        SqlMapper.RemoveTypeMap( typeof( Guid ) );
        SqlMapper.RemoveTypeMap( typeof( Guid? ) );
        SqlMapper.AddTypeHandler( typeof( Guid ), new GuidTypeHandler() );
        return null;
    }
}