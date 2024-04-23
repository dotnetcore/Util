using Util.Ui.Angular.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgZorro.Components.DatePickers.Helpers;

/// <summary>
/// 日期范围选择表达式加载器
/// </summary>
public class RangePickerExpressionLoader : NgZorroExpressionLoaderBase {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        LoadLabel( config, info );
        LoadId( config, info );
        LoadName( config, info );
        LoadDate( config, info );
        LoadRequired( config, info );
    }

    /// <summary>
    /// 加载标签
    /// </summary>
    protected virtual void LoadLabel( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.LabelText, info.DisplayName, false );
    }

    /// <summary>
    /// 加载标识
    /// </summary>
    protected virtual void LoadId( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Id, GeKebaberizePropertyName( config, info ), false );
    }

    /// <summary>
    /// 加载名称
    /// </summary>
    protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Name, GeKebaberizePropertyName( config, info ), false );
    }

    /// <summary>
    /// 加载日期
    /// </summary>
    protected virtual void LoadDate( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( AngularConst.NgModel, info.SafePropertyName );
        if (info.ExpressionPropertyName == UiConst.ForBegin) {
            config.SetAttribute( UiConst.BeginDate, info.SafePropertyName );
            return;
        }
        if ( info.ExpressionPropertyName == UiConst.ForEnd ) {
            config.SetAttribute( UiConst.EndDate, info.SafePropertyName );
            return;
        }
    }

    /// <summary>
    /// 加载必填项验证
    /// </summary>
    protected virtual void LoadRequired( Config config, ModelExpressionInfo info ) {
        if ( info.IsRequired == false )
            return;
        config.SetAttribute( UiConst.Required, "true", false );
        config.SetAttribute( UiConst.RequiredMessage, info.RequiredMessage, false );
    }
}