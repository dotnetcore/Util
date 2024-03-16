using Util.Ui.NgZorro.Components.Modals.Configs;

namespace Util.Ui.NgZorro.Components.Modals.Helpers;

/// <summary>
/// 对话框服务
/// </summary>
public class ModalService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 对话框共享配置
    /// </summary>
    private ModalShareConfig _shareConfig;

    /// <summary>
    /// 初始化对话框服务
    /// </summary>
    /// <param name="config">配置</param>
    public ModalService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateModalShareConfig();
    }

    /// <summary>
    /// 创建对话框共享配置
    /// </summary>
    private void CreateModalShareConfig() {
        _shareConfig = new ModalShareConfig();
        _config.SetValueToItems( _shareConfig );
    }
}