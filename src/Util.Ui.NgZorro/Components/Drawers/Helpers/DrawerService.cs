using Util.Ui.NgZorro.Components.Drawers.Configs;

namespace Util.Ui.NgZorro.Components.Drawers.Helpers;

/// <summary>
/// 抽屉服务
/// </summary>
public class DrawerService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 抽屉共享配置
    /// </summary>
    private DrawerShareConfig _shareConfig;

    /// <summary>
    /// 初始化抽屉服务
    /// </summary>
    /// <param name="config">配置</param>
    public DrawerService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateDrawerShareConfig();
    }

    /// <summary>
    /// 创建抽屉共享配置
    /// </summary>
    private void CreateDrawerShareConfig() {
        _shareConfig = new DrawerShareConfig();
        _config.SetValueToItems( _shareConfig );
    }
}