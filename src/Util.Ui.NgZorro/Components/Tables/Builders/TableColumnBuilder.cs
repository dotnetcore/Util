using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Tables.Builders.Contents;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Directives.Tooltips;

namespace Util.Ui.NgZorro.Components.Tables.Builders;

/// <summary>
/// 表格单元格标签生成器
/// </summary>
public class TableColumnBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表格列共享配置
    /// </summary>
    private readonly TableColumnShareConfig _shareConfig;

    /// <summary>
    /// 初始化表格单元格标签生成器
    /// </summary>
    public TableColumnBuilder( Config config, TableColumnShareConfig shareConfig ) : base( config, "td" ) {
        _config = config;
        _shareConfig = shareConfig;
    }

    /// <summary>
    /// 获取配置
    /// </summary>
    public Config GetConfig() {
        return _config;
    }

    /// <summary>
    /// 获取表格列共享配置
    /// </summary>
    public TableColumnShareConfig GetTableColumnShareConfig() {
        return _shareConfig;
    }

    /// <summary>
    /// 配置是否显示复选框
    /// </summary>
    public TableColumnBuilder ShowCheckbox() {
        AttributeIfNotEmpty( "[nzShowCheckbox]", _config.GetValue( UiConst.ShowCheckbox ) );
        return this;
    }

    /// <summary>
    /// 配置是否禁用复选框
    /// </summary>
    public TableColumnBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置复选框是否中间状态
    /// </summary>
    public TableColumnBuilder Indeterminate() {
        AttributeIfNotEmpty( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
        return this;
    }

    /// <summary>
    /// 配置是否选中复选框
    /// </summary>
    public TableColumnBuilder Checked() {
        AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( UiConst.Checked ) );
        AttributeIfNotEmpty( "[(nzChecked)]", _config.GetValue( AngularConst.BindonChecked ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示展开按钮
    /// </summary>
    public TableColumnBuilder ShowExpand() {
        AttributeIfNotEmpty( "[nzShowExpand]", _config.GetValue( UiConst.ShowExpand ) );
        return this;
    }

    /// <summary>
    /// 配置是否已展开
    /// </summary>
    public TableColumnBuilder Expand() {
        AttributeIfNotEmpty( "[nzExpand]", _config.GetValue( UiConst.Expand ) );
        AttributeIfNotEmpty( "[(nzExpand)]", _config.GetValue( AngularConst.BindonExpand ) );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableColumnBuilder Left() {
        if ( _shareConfig.IsEnableFixedColumn ) {
            BindLeft( $"{_shareConfig.TableSettingsId}.isLeft('{_shareConfig.Title}')" );
            return this;
        }
        Left( _shareConfig.IsLeft );
        BindLeft( _config.GetValue( AngularConst.BindLeft ) );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableColumnBuilder Left( string value, string title ) {
        if ( _shareConfig.IsEnableFixedColumn ) {
            BindLeft( $"{_shareConfig.TableSettingsId}.isLeft('{title}')" );
            return this;
        }
        Left( value );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableColumnBuilder Left( string value ) {
        if ( value.IsEmpty() )
            return this;
        if ( value.SafeString().ToLower() == "true" )
            return BindLeft( "true" );
        Attribute( "nzLeft", value );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableColumnBuilder BindLeft( string value ) {
        AttributeIfNotEmpty( "[nzLeft]", value );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableColumnBuilder Right() {
        if ( _shareConfig.IsEnableFixedColumn ) {
            BindRight( $"{_shareConfig.TableSettingsId}.isRight('{_shareConfig.Title}')" );
            return this;
        }
        Right( _shareConfig.IsRight );
        BindRight( _config.GetValue( AngularConst.BindRight ) );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableColumnBuilder Right( string value, string title ) {
        if ( _shareConfig.IsEnableFixedColumn ) {
            BindRight( $"{_shareConfig.TableSettingsId}.isRight('{title}')" );
            return this;
        }
        Right( value );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableColumnBuilder Right( string value ) {
        if ( value.IsEmpty() )
            return this;
        if ( value.SafeString().ToLower() == "true" )
            return BindRight( "true" );
        Attribute( "nzRight", value );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableColumnBuilder BindRight( string value ) {
        AttributeIfNotEmpty( "[nzRight]", value );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public virtual TableColumnBuilder Align() {
        if ( _shareConfig.IsEnableTableSettings ) {
            BindAlign( $"{_shareConfig.TableSettingsId}.getAlign('{_shareConfig.Title}')" );
            return this;
        }
        AttributeIfNotEmpty( "nzAlign", _shareConfig.Align );
        BindAlign( _config.GetValue( AngularConst.BindAlign ) );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public virtual TableColumnBuilder Align( string title ) {
        if ( _shareConfig.IsEnableTableSettings )
            BindAlign( $"{_shareConfig.TableSettingsId}.getAlign('{title}')" );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public TableColumnBuilder BindAlign( string value ) {
        AttributeIfNotEmpty( "[nzAlign]", value );
        return this;
    }

    /// <summary>
    /// 配置是否折行显示
    /// </summary>
    public TableColumnBuilder BreakWord() {
        AttributeIfNotEmpty( "[nzBreakWord]", _config.GetValue( UiConst.BreakWord ) );
        return this;
    }

    /// <summary>
    /// 配置自动省略
    /// </summary>
    public TableColumnBuilder Ellipsis() {
        if ( _shareConfig.IsEnableTableSettings ) {
            BindEllipsis( $"{_shareConfig.TableSettingsId}.getEllipsis('{_shareConfig.Title}')" );
            return this;
        }
        BindEllipsis( _config.GetValue( UiConst.Ellipsis ) );
        return this;
    }

    /// <summary>
    /// 配置自动省略
    /// </summary>
    public TableColumnBuilder BindEllipsis( string value ) {
        AttributeIfNotEmpty( "[nzEllipsis]", value );
        return this;
    }

    /// <summary>
    /// 配置缩进宽度
    /// </summary>
    public TableColumnBuilder IndentSize() {
        AttributeIfNotEmpty( "[nzIndentSize]", _config.GetValue( UiConst.IndentSize ) );
        return this;
    }

    /// <summary>
    /// 配置单元格控件
    /// </summary>
    public virtual TableColumnBuilder CellControl() {
        CellControl( _config.GetValue( UiConst.CellControl ) );
        AttributeIfNotEmpty( "[nzCellControl]", _config.GetValue( AngularConst.BindCellControl ) );
        return this;
    }

    /// <summary>
    /// 配置单元格控件
    /// </summary>
    /// <param name="value">值</param>
    public virtual TableColumnBuilder CellControl( string value ) {
        AttributeIfNotEmpty( "nzCellControl", value );
        return this;
    }

    /// <summary>
    /// 配置启用自定义列
    /// </summary>
    public TableColumnBuilder EnableCustomColumn() {
        if ( _shareConfig.IsEnableCustomColumn == false )
            return this;
        CellControl( _shareConfig.CellControl );
        return this;
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public TableColumnBuilder Events() {
        AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
        AttributeIfNotEmpty( "(nzExpandChange)", _config.GetValue( UiConst.OnExpandChange ) );
        this.OnClick( _config );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.ConfigBase( _config );
        ShowCheckbox().Disabled().Indeterminate().Checked()
            .ShowExpand().Expand()
            .Left().Right().Align().BreakWord().Ellipsis()
            .IndentSize().CellControl().EnableCustomColumn()
            .Tooltip( _config ).Events();
        ConfigContent();
    }

    /// <summary>
    /// 配置内容
    /// </summary>
    protected virtual void ConfigContent() {
        var service = new TableColumnContentService( this, new TableSelectCreateService() );
        service.Config();
    }

    /// <summary>
    /// 添加复选框
    /// </summary>
    public virtual void AddCheckbox() {
        var title = "util.checkbox";
        Attribute( "[nzShowCheckbox]", "true" );
        Attribute( "(click)", "$event.stopPropagation()" );
        Attribute( "(nzCheckedChange)", $"{_shareConfig.TableExtendId}.toggle(row)" );
        Attribute( "[nzChecked]", $"{_shareConfig.TableExtendId}.isChecked(row)" );
        if ( _shareConfig.IsEnableCustomColumn )
            Attribute( "nzCellControl", title );
        Left( _shareConfig.IsCheckboxLeft, title );
        if ( _shareConfig.IsEnableFixedColumn )
            Right( _shareConfig.IsCheckboxLeft, title );
        Align( title );
    }

    /// <summary>
    /// 添加复选框
    /// </summary>
    /// <param name="checkBoxBuilder">复选框生成器</param>
    public virtual void AddCheckbox( TagBuilder checkBoxBuilder ) {
        AppendContent( checkBoxBuilder );
        Left( _shareConfig.IsCheckboxLeft );
    }

    /// <summary>
    /// 添加单选框
    /// </summary>
    public virtual void AddRadio() {
        var radioBuilder = new TableColumnRadioBuilder( _config, _shareConfig.TableExtendId );
        AddRadio( radioBuilder );
    }

    /// <summary>
    /// 添加单选框
    /// </summary>
    public virtual void AddRadio( TagBuilder radioBuilder ) {
        var title = "util.radio";
        AppendContent( radioBuilder );
        if ( _shareConfig.IsEnableCustomColumn )
            Attribute( "nzCellControl", title );
        Left( _shareConfig.IsRadioLeft, title );
        if ( _shareConfig.IsEnableFixedColumn )
            Right( _shareConfig.IsRadioLeft, title );
        Align( title );
    }

    /// <summary>
    /// 添加序号
    /// </summary>
    public void AddLineNumber() {
        var title = "util.lineNumber";
        AppendContent( "{{row.lineNumber}}" );
        if ( _shareConfig.IsEnableCustomColumn )
            Attribute( "nzCellControl", title );
        Left( _shareConfig.IsLineNumberLeft, title );
        if ( _shareConfig.IsEnableFixedColumn )
            Right( _shareConfig.IsLineNumberLeft, title );
        Align( title );
    }
}