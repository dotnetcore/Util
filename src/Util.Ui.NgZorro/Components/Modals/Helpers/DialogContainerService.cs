using Util.Ui.NgZorro.Components.Modals.Configs;

namespace Util.Ui.NgZorro.Components.Modals.Helpers;

/// <summary>
/// 对话框容器服务
/// </summary>
public class DialogContainerService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 对话框共享配置
    /// </summary>
    private readonly ModalShareConfig _shareConfig;

    /// <summary>
    /// 初始化对话框容器服务
    /// </summary>
    /// <param name="config">配置</param>
    public DialogContainerService( Config config ) {
        _config = config;
        _shareConfig = GetShareConfig();
    }

    /// <summary>
    /// 获取对话框共享配置
    /// </summary>
    private ModalShareConfig GetShareConfig() {
        return _config.GetValueFromItems<ModalShareConfig>() ?? new ModalShareConfig();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
    }
}