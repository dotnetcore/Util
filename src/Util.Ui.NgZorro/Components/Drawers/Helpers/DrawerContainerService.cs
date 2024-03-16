using Util.Ui.NgZorro.Components.Drawers.Configs;

namespace Util.Ui.NgZorro.Components.Drawers.Helpers;

/// <summary>
/// 抽屉容器服务
/// </summary>
public class DrawerContainerService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 抽屉共享配置
    /// </summary>
    private readonly DrawerShareConfig _shareConfig;

    /// <summary>
    /// 初始化抽屉容器服务
    /// </summary>
    /// <param name="config">配置</param>
    public DrawerContainerService( Config config ) {
        _config = config;
        _shareConfig = GetShareConfig();
    }

    /// <summary>
    /// 获取抽屉共享配置
    /// </summary>
    private DrawerShareConfig GetShareConfig() {
        return _config.GetValueFromItems<DrawerShareConfig>() ?? new DrawerShareConfig();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
    }
}