using Util.Ui.Angular.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders;

/// <summary>
/// 表格设置标签生成器
/// </summary>
public class TableSettingsBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格共享配置
    /// </summary>
    private TableShareConfig _tableShareConfig;

    /// <summary>
    /// 初始化表格设置标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public TableSettingsBuilder( Config config ) : base( config, "x-table-settings" ) {
        _config = config;
        _tableShareConfig = GetTableShareConfig();
    }

    /// <summary>
    /// 获取表格共享配置
    /// </summary>
    public TableShareConfig GetTableShareConfig() {
        return _tableShareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
    }

    /// <summary>
    /// 配置初始设置的列集合
    /// </summary>
    public TableSettingsBuilder InitColumns() {
        if ( _tableShareConfig.ColumnNumber == 0 )
            return this;
        Attribute( "[initColumns]", GetColumnsJson() );
        return this;
    }

    /// <summary>
    /// 获取自定义列Json
    /// </summary>
    private string GetColumnsJson() {
        var customColumns = _tableShareConfig.Columns.Select( column => column.ToCustomColumn() );
        return Util.Helpers.Json.ToJson( customColumns, new JsonOptions { ToSingleQuotes = true, IgnoreNullValues = true } );
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        Attribute( $"#{_tableShareConfig.TableSettingsId}" );
        Attribute( "customColumnKey", _tableShareConfig.CustomColumnKey );
        InitColumns();
    }
}