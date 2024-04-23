using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Helpers;

/// <summary>
/// 表格列表达式加载器
/// </summary>
public class TableColumnExpressionLoader : ExpressionLoaderBase {
    /// <summary>
    /// 加载模型信息
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="info">模型表达式信息</param>
    protected override void Load( Config config, ModelExpressionInfo info ) {
        LoadName( config, info );
        LoadDisplayName( config, info );
        LoadSort( config, info );
        LoadType( config, info );
    }

    /// <summary>
    /// 加载属性名
    /// </summary>
    protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Column, info.PropertyName, false );
    }

    /// <summary>
    /// 加载显示名称
    /// </summary>
    protected virtual void LoadDisplayName( Config config, ModelExpressionInfo info ) {
        config.SetAttribute( UiConst.Title, info.DisplayName, false );
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
        config.SetAttribute( UiConst.Sort, true, false );
    }

    /// <summary>
    /// 加载类型
    /// </summary>
    protected virtual void LoadType( Config config, ModelExpressionInfo info ) {
        if ( info.IsBool ) {
            config.SetAttribute( UiConst.Type, TableColumnType.Bool );
            return;
        }
        if ( info.IsDate ) {
            config.SetAttribute( UiConst.Type, TableColumnType.Date );
            return;
        }
        if ( info.IsEnum ) {
            config.SetAttribute( UiConst.Type, TableColumnType.Enum );
            config.SetAttribute( UiConst.EnumContent, GetEnumContent( config, info ) );
            return;
        }
    }

    /// <summary>
    /// 获取枚举内容
    /// </summary>
    private string GetEnumContent( Config config, ModelExpressionInfo info ) {
        var options = NgZorroOptionsService.GetOptions();
        var result = new StringBuilder();
        var column = config.GetValue( UiConst.Column );
        var items = Util.Helpers.Enum.GetItems( info.ModelType );
        items.ForEach( item => {
            result.Append( $"<ng-container *ngIf=\"row.{column}==={item.Value}\">" );
            if ( options.EnableI18n ) {
                result.Append( "{{" );
                result.Append( $"'{item.Text}'|i18n" );
                result.Append( "}}" );
            } else {
                result.Append( item.Text );
            }
            result.Append( "</ng-container>" );
        } );
        return result.ToString();
    }
}