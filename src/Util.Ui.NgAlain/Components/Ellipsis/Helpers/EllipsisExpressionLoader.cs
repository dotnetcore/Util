using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgAlain.Components.Ellipsis.Helpers;

/// <summary>
/// 文本省略表达式加载器
/// </summary>
public class EllipsisExpressionLoader : NgZorroExpressionLoaderBase {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Value, info.SafePropertyName, false );
    }
}