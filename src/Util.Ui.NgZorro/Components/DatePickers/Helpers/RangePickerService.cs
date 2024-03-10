namespace Util.Ui.NgZorro.Components.DatePickers.Helpers;

/// <summary>
/// 日期范围选择服务
/// </summary>
public class RangePickerService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化日期范围选择服务
    /// </summary>
    /// <param name="config">配置</param>
    public RangePickerService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        LoadExpression();
    }

    /// <summary>
    /// 加载表达式
    /// </summary>
    private void LoadExpression() {
        var loader = new RangePickerExpressionLoader();
        loader.Load( _config, UiConst.ForBegin );
        loader.Load( _config, UiConst.ForEnd );
    }
}