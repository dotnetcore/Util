using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Expressions; 

/// <summary>
/// NgZorro表达式加载器
/// </summary>
public abstract class NgZorroExpressionLoaderBase : ExpressionLoaderBase {
    /// <summary>
    /// 创建模型表达式解析器
    /// </summary>
    /// <param name="config">配置</param>
    protected override IExpressionResolver CreateExpressionResolver( Config config ) {
        return new NgZorroExpressionResolver( config );
    }

    /// <summary>
    /// 获取下划线分隔的小写属性名
    /// </summary>
    protected virtual string GeKebaberizePropertyName( Config config, ModelExpressionInfo info ) {
        var columnConfig = GetTableColumnShareConfig( config );
        var name = info.LastPropertyName.Kebaberize().Replace("-", "_");
        if ( columnConfig == null || columnConfig.IsEnableEdit == false )
            return name;
        return $"control_{name}";
    }

    /// <summary>
    /// 获取表格列共享配置
    /// </summary>
    public TableColumnShareConfig GetTableColumnShareConfig( Config config ) {
        return config.GetValueFromItems<TableColumnShareConfig>();
    }
}