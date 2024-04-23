using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表头单元格表达式加载器
/// </summary>
public class TableHeadColumnExpressionLoader : ExpressionLoader {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        base.Load( config, info );
        LoadSort( config, info );
    }

    /// <summary>
    /// 加载排序
    /// </summary>
    protected virtual void LoadSort( Config config, ModelExpressionInfo info ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableTableSort == false )
            return;
        var shareConfig = config.GetValueFromItems<TableShareConfig>();
        if ( shareConfig == null || shareConfig.IsTreeTable )
            return;
        config.SetAttribute( UiConst.Sort, info.PropertyName, false );
    }
}