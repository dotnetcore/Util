using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgAlain.Components.Sv.Helpers; 

/// <summary>
/// 查看列表达式加载器
/// </summary>
public class SvExpressionLoader : NgZorroExpressionLoaderBase {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        LoadLabel( config, info );
        LoadValue( config, info );
    }

    /// <summary>
    /// 加载标签
    /// </summary>
    protected void LoadLabel( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Label, info.DisplayName, false );
    }

    /// <summary>
    /// 加载值
    /// </summary>
    protected virtual void LoadValue( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Value, info.SafePropertyName, false );
        if ( info.IsBool ) {
            config.SetAttribute( UiConst.Type, DataType.Bool );
            return;
        }
        if ( info.IsDate ) {
            config.SetAttribute( UiConst.Type, DataType.Date );
            return;
        }
        if ( info.IsNumber ) {
            config.SetAttribute( UiConst.Type, DataType.Number );
            return;
        }
    }
}