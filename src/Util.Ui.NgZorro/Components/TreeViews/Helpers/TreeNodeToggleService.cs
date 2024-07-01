using Util.Ui.NgZorro.Components.TreeViews.Configs;

namespace Util.Ui.NgZorro.Components.TreeViews.Helpers;

/// <summary>
/// 树视图节点切换服务
/// </summary>
public class TreeNodeToggleService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 树视图节点切换共享配置
    /// </summary>
    private TreeNodeToggleShareConfig _shareConfig;

    /// <summary>
    /// 初始化树视图节点切换服务
    /// </summary>
    /// <param name="config">配置</param>
    public TreeNodeToggleService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateShareConfig();
        InitRotateIcon();
        InitActiveIcon();
    }

    /// <summary>
    /// 创建对话框共享配置
    /// </summary>
    private void CreateShareConfig() {
        _shareConfig = new TreeNodeToggleShareConfig();
        _config.SetValueToItems( _shareConfig );
    }

    /// <summary>
    /// 初始化 nzTreeNodeToggleRotateIcon
    /// </summary>
    private void InitRotateIcon() {
        var value = _config.GetValue<bool?>( UiConst.RotateIcon );
        if ( value == false )
            _shareConfig.RotateIcon = false;
    }

    /// <summary>
    /// 初始化 nzTreeNodeToggleActiveIcon
    /// </summary>
    private void InitActiveIcon() {
        var value = _config.GetValue<bool?>( UiConst.ActiveIcon );
        if ( value == true )
            _shareConfig.ActiveIcon = true;
    }
}