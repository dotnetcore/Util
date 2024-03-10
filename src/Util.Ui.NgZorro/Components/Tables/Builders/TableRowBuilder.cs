using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders; 

/// <summary>
/// 表格行标签生成器
/// </summary>
public class TableRowBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格共享配置
    /// </summary>
    private TableShareConfig _tableShareConfig;

    /// <summary>
    /// 初始化表格行标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public TableRowBuilder( Config config ) : base( config,"tr" ) {
        _config = config;
    }

    /// <summary>
    /// 获取配置
    /// </summary>
    public Config GetConfig() {
        return _config;
    }

    /// <summary>
    /// 获取表格共享配置
    /// </summary>
    public TableShareConfig TableShareConfig => _tableShareConfig ??= _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();

    /// <summary>
    /// 配置当前列是否展开
    /// </summary>
    public TableRowBuilder Expand() {
        AttributeIfNotEmpty( "[nzExpand]", _config.GetValue( UiConst.Expand ) );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public virtual TableRowBuilder Events() {
        var onClick = GetOnClick();
        ConfigOnClick( onClick );
        return this;
    }

    /// <summary>
    /// 获取单击事件,合并了从表格设置的行单击事件
    /// </summary>
    private string GetOnClick() {
        var onClick = _config.GetValue( UiConst.OnClick );
        var onClickRow = TableShareConfig.OnClickRow;
        if ( onClick.IsEmpty() )
            return onClickRow;
        if ( onClickRow.IsEmpty() )
            return onClick;
        return $"{onClick};{onClickRow}";
    }

    /// <summary>
    /// 配置单击事件
    /// </summary>
    private void ConfigOnClick( string value ) {
        var result = new StringBuilder();
        ConfigSelect( result );
        result.Append( value );
        this.OnClick( result.ToString() );
    }

    /// <summary>
    /// 配置选中行
    /// </summary>
    private void ConfigSelect( StringBuilder result ) {
        var isSelect = IsSelectOnClick();
        if ( isSelect ) {
            ConfigSelectOnClick( result );
            return;
        }
        isSelect = IsSelectOnlyOnClick();
        if( isSelect )
            ConfigSelectOnlyOnClick( result );
    }

    /// <summary>
    /// 是否单击选中行
    /// </summary>
    private bool IsSelectOnClick() {
        var result = _config.GetValue<bool>( UiConst.SelectOnClick );
        return result || TableShareConfig.SelectOnClickRow;
    }

    /// <summary>
    /// 配置单击选中行
    /// </summary>
    private void ConfigSelectOnClick( StringBuilder result ) {
        result.Append( $"{TableShareConfig.TableExtendId}.toggleSelect(row);" );
        AddSelectedClass();
    }

    /// <summary>
    /// 添加选中样式
    /// </summary>
    private void AddSelectedClass() {
        Attribute( "[class.table-row-selected]", $"{TableShareConfig.TableExtendId}.isSelected(row)" );
    }

    /// <summary>
    /// 是否单击仅选中该行
    /// </summary>
    private bool IsSelectOnlyOnClick() {
        var result = _config.GetValue<bool>( UiConst.SelectOnlyOnClick );
        return result || TableShareConfig.SelectOnlyOnClickRow;
    }

    /// <summary>
    /// 配置单击仅选中一行
    /// </summary>
    private void ConfigSelectOnlyOnClick( StringBuilder result ) {
        result.Append( $"{TableShareConfig.TableExtendId}.selectRowOnly(row);" );
        AddSelectedClass();
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase(_config);
        Expand().Events();
    }
}