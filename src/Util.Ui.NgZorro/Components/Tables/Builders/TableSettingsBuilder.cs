using Util.Ui.Angular.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

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
    public TableSettingsBuilder( Config config ) : base( config, NgZorroOptionsService.GetOptions().TableSettingsTag ) {
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
    /// 设置表格尺寸
    /// </summary>
    public TableSettingsBuilder IsTreeTable() {
        if ( _tableShareConfig.IsTreeTable == false )
            return this;
        Attribute( "[isTreeTable]", "true" );
        return this;
    }

    /// <summary>
    /// 设置表格尺寸
    /// </summary>
    public TableSettingsBuilder Size() {
        AttributeIfNotEmpty( "initSize", _config.GetValue<TableSize?>( UiConst.Size )?.Description() );
        return this;
    }

    /// <summary>
    /// 设置表格边框
    /// </summary>
    public TableSettingsBuilder Bordered() {
        AttributeIfNotEmpty( "[initBordered]", _config.GetValue( UiConst.Bordered ) );
        return this;
    }

    /// <summary>
    /// 设置滚动宽高
    /// </summary>
    public TableSettingsBuilder Scroll() {
        AttributeIfNotEmpty( "scrollHeight", _tableShareConfig.ScrollHeight );
        AttributeIfNotEmpty( "scrollWidth", _tableShareConfig.ScrollWidth );
        AttributeIfNotEmpty( "[initScroll]", _config.GetValue( UiConst.Scroll ) );
        return this;
    }

    /// <summary>
    /// 配置是否启用固定列
    /// </summary>
    public TableSettingsBuilder EnableFixedColumn() {
        if ( _tableShareConfig.IsEnableFixedColumn )
            Attribute( "[enableFixedColumn]", "true" );
        return this;
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
        var result = new List<CustomColumn>();
        AddRadioColumn( result );
        AddCheckboxColumn( result );
        AddLineNumberColumn( result );
        result.AddRange( _tableShareConfig.Columns.Where( column => column.IsInner == false ).Select( column => column.ToCustomColumn() ) );
        var json = Util.Helpers.Json.ToJson( result, new JsonOptions { ToSingleQuotes = true, IgnoreNullValues = true } );
        return json.Replace( $"'{GetCheckboxWidth()}'", GetCheckboxWidth() )
            .Replace( $"'{GetRadioWidth()}'", GetRadioWidth() )
            .Replace( $"'{GetLineNumberWidth()}'", GetLineNumberWidth() );
    }

    /// <summary>
    /// 获取表格复选框宽度
    /// </summary>
    private string GetCheckboxWidth() {
        return $"{_tableShareConfig.TableExtendId}.config.table.checkboxWidth";
    }

    /// <summary>
    /// 获取表格单选框宽度
    /// </summary>
    private string GetRadioWidth() {
        return $"{_tableShareConfig.TableExtendId}.config.table.radioWidth";
    }

    /// <summary>
    /// 获取表格序号宽度
    /// </summary>
    private string GetLineNumberWidth() {
        return $"{_tableShareConfig.TableExtendId}.config.table.lineNumberWidth";
    }

    /// <summary>
    /// 添加单选列信息
    /// </summary>
    private void AddRadioColumn( List<CustomColumn> result ) {
        if ( _tableShareConfig.IsTreeTable )
            return;
        if ( _tableShareConfig.IsShowRadio == false )
            return;
        var options = NgZorroOptionsService.GetOptions();
        result.Add( new CustomColumn( "util.radio", GetRadioWidth(), _tableShareConfig.GetRadioLeft(), align: options.TableRadioAlign.Description() ) );
    }

    /// <summary>
    /// 添加复选列信息
    /// </summary>
    private void AddCheckboxColumn( List<CustomColumn> result ) {
        if ( _tableShareConfig.IsTreeTable )
            return;
        if ( _tableShareConfig.IsShowCheckbox == false )
            return;
        var options = NgZorroOptionsService.GetOptions();
        result.Add( new CustomColumn( "util.checkbox", GetCheckboxWidth(), _tableShareConfig.GetCheckboxLeft(), align: options.TableCheckboxAlign.Description() ) );
    }

    /// <summary>
    /// 添加序号信息
    /// </summary>
    private void AddLineNumberColumn( List<CustomColumn> result ) {
        if ( _tableShareConfig.IsTreeTable )
            return;
        if ( _tableShareConfig.IsShowLineNumber == false )
            return;
        var options = NgZorroOptionsService.GetOptions();
        result.Add( new CustomColumn( "util.lineNumber", GetLineNumberWidth(), _tableShareConfig.GetLineNumberLeft(), align: options.TableLineNumberAlign.Description() ) );
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        if ( _tableShareConfig.Key.IsEmpty() )
            throw new ArgumentNullException( "表格存储标识属性 Key 必须设置!" );
        Attribute( $"#{_tableShareConfig.TableSettingsId}" );
        Attribute( "key", _tableShareConfig.Key );
        IsTreeTable().Size().Bordered().Scroll().EnableFixedColumn();
        InitColumns();
    }
}