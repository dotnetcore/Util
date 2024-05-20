using Util.Ui.NgZorro.Components.Dropdowns.Configs;

namespace Util.Ui.NgZorro.Components.Dropdowns.Helpers;

/// <summary>
/// 下拉菜单共享服务
/// </summary>
public class DropdownMenuService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 下拉菜单共享配置
    /// </summary>
    private DropdownMenuShareConfig _shareConfig;

    /// <summary>
    /// 初始化表单项共享服务
    /// </summary>
    /// <param name="config">配置</param>
    public DropdownMenuService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 设置自动创建 ul
    /// </summary>
    /// <param name="value">是否自动创建</param>
    public void AutoCreateUl( bool value ) {
        if ( _shareConfig.AutoCreateUl == false )
            return;
        _shareConfig.AutoCreateUl = value;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        InitShareConfig();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void InitShareConfig() {
        _shareConfig = GetShareConfig();
        _config.SetValueToItems( _shareConfig );
    }

    /// <summary>
    /// 获取下拉菜单共享配置
    /// </summary>
    private DropdownMenuShareConfig GetShareConfig() {
        return _config.GetValueFromItems<DropdownMenuShareConfig>() ?? new DropdownMenuShareConfig();
    }
}