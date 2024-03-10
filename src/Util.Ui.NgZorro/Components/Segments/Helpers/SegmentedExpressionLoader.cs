using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Selects.Helpers;

namespace Util.Ui.NgZorro.Components.Segments.Helpers;

/// <summary>
/// 分段控制器表达式加载器
/// </summary>
public class SegmentedExpressionLoader : SelectExpressionLoader {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        base.Load( config, info );
        config.SetAttribute( UiConst.Value, info.SafePropertyName, false );
    }
}