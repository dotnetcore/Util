using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表格编辑列显示服务
/// </summary>
public class TableColumnDisplayService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格编辑列显示区域共享配置
    /// </summary>
    private TableColumnDisplayShareConfig _shareConfig;

    /// <summary>
    /// 初始化表格编辑列显示服务
    /// </summary>
    /// <param name="config">配置</param>
    public TableColumnDisplayService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        CreateShareConfig();
    }

    /// <summary>
    /// 创建共享配置
    /// </summary>
    private void CreateShareConfig() {
        _shareConfig = new TableColumnDisplayShareConfig();
        _config.SetValueToItems( _shareConfig );
    }
}