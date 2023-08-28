using Microsoft.AspNetCore.Hosting;

namespace Util.Microservices.Dapr.Events;

/// <summary>
/// 获取应用标识服务
/// </summary>
public class GetAppIdService : IGetAppId {
    /// <summary>
    /// Dapr配置
    /// </summary>
    private readonly DaprOptions _options;
    /// <summary>
    /// 主机环境
    /// </summary>
    private readonly IWebHostEnvironment _environment;

    /// <summary>
    /// 初始化获取应用标识服务
    /// </summary>
    /// <param name="options">Dapr配置</param>
    /// <param name="environment">主机环境</param>
    public GetAppIdService( IOptions<DaprOptions> options, IWebHostEnvironment environment = null ) {
        _options = options?.Value ?? new DaprOptions();
        _environment = environment;
    }

    /// <summary>
    /// 获取应用标识
    /// </summary>
    public string GetAppId() {
        var result = DaprHelper.GetAppId();
        if ( result.IsEmpty() == false )
            return result;
        return _options.AppId.IsEmpty() ? _environment?.ApplicationName : _options.AppId;
    }
}