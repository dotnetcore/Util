using Util.Ui.NgZorro.Components.Forms.Configs;
namespace Util.Ui.NgZorro.Components.Grids.Helpers;

/// <summary>
/// 栅格列服务
/// </summary>
public class ColumnService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化输入框组合共享服务
    /// </summary>
    /// <param name="config">配置</param>
    public ColumnService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="id">标识</param>
    public void Init( string id ) {
        var formShareConfig = _config.GetValueFromItems<FormShareConfig>();
        if ( formShareConfig == null )
            return;
        if ( formShareConfig.IsSearch.SafeValue() == false )
            return;
        formShareConfig.AddColumnId( id );
    }
}