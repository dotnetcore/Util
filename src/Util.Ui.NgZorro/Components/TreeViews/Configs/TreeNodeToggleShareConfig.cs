namespace Util.Ui.NgZorro.Components.TreeViews.Configs;

/// <summary>
/// 树视图节点切换共享配置
/// </summary>
public class TreeNodeToggleShareConfig {
    /// <summary>
    /// 是否为图标添加 nzTreeNodeToggleRotateIcon 指令
    /// </summary>
    public bool RotateIcon { get; set; } = true;
    /// <summary>
    /// 是否为图标添加 nzTreeNodeToggleActiveIcon 指令
    /// </summary>
    public bool ActiveIcon { get; set; }
}