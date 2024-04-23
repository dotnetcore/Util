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
    /// 点击事件列表
    /// </summary>
    private readonly List<string> _onClick;

    /// <summary>
    /// 初始化表格行标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    public TableRowBuilder( Config config ) : base( config, "tr" ) {
        _config = config;
        _onClick = [];
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
        ConfigOnClick();
        return this;
    }

    /// <summary>
    /// 配置单击事件
    /// </summary>
    private void ConfigOnClick() {
        AddOnClick();
        this.OnClick( _onClick.Join( separator: ";" ) );
    }

    /// <summary>
    /// 添加单击事件
    /// </summary>
    private void AddOnClick() {
        AddOnClick( _config.GetValue( UiConst.OnClick ) );
        AddOnClick( TableShareConfig.OnClickRow );
        if ( IsSelectOnClick() )
            AddOnClick( $"{TableShareConfig.TableExtendId}.toggleSelect(row)" );
        if ( IsSelectOnlyOnClick() )
            AddOnClick( $"{TableShareConfig.TableExtendId}.selectRowOnly(row)" );
        if ( IsCheckRowOnClick() )
            AddOnClick( $"{TableShareConfig.TableExtendId}.toggle(row)" );
        if ( IsCheckRowOnlyOnClick() )
            AddOnClick( $"{TableShareConfig.TableExtendId}.checkRowOnly(row)" );
    }

    /// <summary>
    /// 添加单击事件
    /// </summary>
    private void AddOnClick( string onClick ) {
        if ( onClick.IsEmpty() )
            return;
        _onClick.Add( onClick );
    }

    /// <summary>
    /// 是否单击选中行
    /// </summary>
    private bool IsSelectOnClick() {
        var result = _config.GetValue<bool>( UiConst.SelectOnClick );
        return result || TableShareConfig.SelectOnClickRow;
    }

    /// <summary>
    /// 是否单击仅选中该行
    /// </summary>
    private bool IsSelectOnlyOnClick() {
        var result = _config.GetValue<bool>( UiConst.SelectOnlyOnClick );
        return result || TableShareConfig.SelectOnlyOnClickRow;
    }

    /// <summary>
    /// 是否单击选中复选框
    /// </summary>
    private bool IsCheckRowOnClick() {
        if ( TableShareConfig.IsShowCheckbox == false )
            return false;
        var result = _config.GetValue<bool>( UiConst.CheckOnClick );
        return result || TableShareConfig.CheckOnClickRow;
    }

    /// <summary>
    /// 是否单击选中单选框
    /// </summary>
    private bool IsCheckRowOnlyOnClick() {
        if ( TableShareConfig.IsShowRadio == false )
            return false;
        var result = _config.GetValue<bool>( UiConst.CheckOnClick );
        return result || TableShareConfig.CheckOnClickRow;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        Expand().Events();
        ConfigSelect();
    }

    /// <summary>
    /// 配置选中行
    /// </summary>
    private void ConfigSelect() {
        if ( IsSelectOnClick() || IsSelectOnlyOnClick() )
            Attribute( "[class.table-row-selected]", $"{TableShareConfig.TableExtendId}.isSelected(row)" );
    }
}