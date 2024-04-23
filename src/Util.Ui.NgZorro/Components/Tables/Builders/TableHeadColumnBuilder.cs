using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Extensions;
using Util.Ui.NgZorro.Components.Resizable.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders;

/// <summary>
/// 表头单元格标签生成器
/// </summary>
public class TableHeadColumnBuilder : AngularTagBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表头列共享配置
    /// </summary>
    private readonly TableHeadColumnShareConfig _shareConfig;

    /// <summary>
    /// 初始化表头单元格标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="shareConfig">表头列共享配置</param>
    public TableHeadColumnBuilder( Config config, TableHeadColumnShareConfig shareConfig ) : base( config, "th" ) {
        _config = config;
        _shareConfig = shareConfig;
    }

    /// <summary>
    /// 配置是否显示复选框
    /// </summary>
    public TableHeadColumnBuilder ShowCheckbox() {
        AttributeIfNotEmpty( "[nzShowCheckbox]", _config.GetValue( UiConst.ShowCheckbox ) );
        return this;
    }

    /// <summary>
    /// 配置是否禁用复选框
    /// </summary>
    public TableHeadColumnBuilder Disabled() {
        AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( UiConst.Disabled ) );
        return this;
    }

    /// <summary>
    /// 配置复选框是否中间状态
    /// </summary>
    public TableHeadColumnBuilder Indeterminate() {
        AttributeIfNotEmpty( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
        return this;
    }

    /// <summary>
    /// 配置是否选中复选框
    /// </summary>
    public TableHeadColumnBuilder Checked() {
        AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( UiConst.Checked ) );
        AttributeIfNotEmpty( "[(nzChecked)]", _config.GetValue( AngularConst.BindonChecked ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示下拉选择
    /// </summary>
    public TableHeadColumnBuilder ShowRowSelection() {
        AttributeIfNotEmpty( "[nzShowRowSelection]", _config.GetValue( UiConst.ShowRowSelection ) );
        return this;
    }

    /// <summary>
    /// 配置下拉选择的内容
    /// </summary>
    public TableHeadColumnBuilder Selections() {
        AttributeIfNotEmpty( "[nzSelections]", _config.GetValue( UiConst.Selections ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示排序
    /// </summary>
    public TableHeadColumnBuilder ShowSort() {
        ShowSort( _config.GetValue( UiConst.ShowSort ) );
        return this;
    }

    /// <summary>
    /// 配置是否显示排序
    /// </summary>
    public TableHeadColumnBuilder ShowSort( string value ) {
        AttributeIfNotEmpty( "[nzShowSort]", value );
        return this;
    }

    /// <summary>
    /// 配置排序函数
    /// </summary>
    public TableHeadColumnBuilder SortFn() {
        SortFn( _config.GetValue( UiConst.SortFn ) );
        return this;
    }

    /// <summary>
    /// 配置排序函数
    /// </summary>
    public TableHeadColumnBuilder SortFn( string value ) {
        AttributeIfNotEmpty( "[nzSortFn]", value );
        return this;
    }

    /// <summary>
    /// 配置支持的排序方式
    /// </summary>
    public TableHeadColumnBuilder SortDirections() {
        AttributeIfNotEmpty( "[nzSortDirections]", _config.GetValue( UiConst.SortDirections ) );
        return this;
    }

    /// <summary>
    /// 配置排序方向
    /// </summary>
    public TableHeadColumnBuilder SortOrder() {
        AttributeIfNotEmpty( "nzSortOrder", _config.GetValue( UiConst.SortOrder ) );
        AttributeIfNotEmpty( "[nzSortOrder]", _config.GetValue( AngularConst.BindSortOrder ) );
        AttributeIfNotEmpty( "[(nzSortOrder)]", _config.GetValue( AngularConst.BindonSortOrder ) );
        return this;
    }

    /// <summary>
    /// 配置排序
    /// </summary>
    public TableHeadColumnBuilder Sort() {
        Sort( _config.GetValue( UiConst.Sort ) );
        return this;
    }

    /// <summary>
    /// 排序
    /// </summary>
    protected void Sort( string order ) {
        if ( order.IsEmpty() )
            return;
        ShowSort( "true" );
        SortFn( "true" );
        OnSortOrderChange( $"{_shareConfig.TableExtendId}.sortChange('{order}',$event)" );
    }

    /// <summary>
    /// 配置是否显示过滤
    /// </summary>
    public TableHeadColumnBuilder ShowFilter() {
        AttributeIfNotEmpty( "[nzShowFilter]", _config.GetValue( UiConst.ShowFilter ) );
        return this;
    }

    /// <summary>
    /// 配置过滤函数
    /// </summary>
    public TableHeadColumnBuilder FilterFn() {
        AttributeIfNotEmpty( "[nzFilterFn]", _config.GetValue( UiConst.FilterFn ) );
        return this;
    }

    /// <summary>
    /// 配置过滤器
    /// </summary>
    public TableHeadColumnBuilder Filters() {
        AttributeIfNotEmpty( "[nzFilters]", _config.GetValue( UiConst.Filters ) );
        return this;
    }

    /// <summary>
    /// 配置是否多选过滤器
    /// </summary>
    public TableHeadColumnBuilder FilterMultiple() {
        AttributeIfNotEmpty( "[nzFilterMultiple]", _config.GetValue( UiConst.FilterMultiple ) );
        return this;
    }

    /// <summary>
    /// 配置列宽
    /// </summary>
    public TableHeadColumnBuilder Width() {
        if ( _shareConfig.IsEnableCustomColumn )
            return this;
        var width = _config.GetValue( UiConst.Width );
        if ( _shareConfig.IsEnableResizable ) {
            var title = _shareConfig.Title;
            Attribute( "[nzWidth]", GetWidthByTableSettings( title, width ) );
            return this;
        }
        this.Width( width );
        BindWidth( _config.GetValue( AngularConst.BindWidth ) );
        return this;
    }

    /// <summary>
    /// 配置列宽
    /// </summary>
    public TableHeadColumnBuilder BindWidth( string value ) {
        AttributeIfNotEmpty( "[nzWidth]", value );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableHeadColumnBuilder Left() {
        if ( _shareConfig.IsEnableFixedColumn ) {
            var title = _shareConfig.Title;
            BindLeft( $"{_shareConfig.TableSettingsId}.isLeft('{title}')" );
            return this;
        }
        Left( _config.GetValue( UiConst.Left ) );
        BindLeft( _config.GetValue( AngularConst.BindLeft ) );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableHeadColumnBuilder Left( string value ) {
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
    public TableHeadColumnBuilder BindLeft( string value ) {
        AttributeIfNotEmpty( "[nzLeft]", value );
        return this;
    }

    /// <summary>
    /// 配置左侧距离
    /// </summary>
    public TableHeadColumnBuilder Left( string value, string title ) {
        if ( _shareConfig.IsEnableFixedColumn ) {
            BindLeft( $"{_shareConfig.TableSettingsId}.isLeft('{title}')" );
            return this;
        }
        Left( value );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableHeadColumnBuilder Right() {
        if ( _shareConfig.IsEnableFixedColumn ) {
            var title = _shareConfig.Title;
            BindRight( $"{_shareConfig.TableSettingsId}.isRight('{title}')" );
            return this;
        }
        Right( _config.GetValue( UiConst.Right ) );
        BindRight( _config.GetValue( AngularConst.BindRight ) );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableHeadColumnBuilder Right( string value ) {
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
    public TableHeadColumnBuilder BindRight( string value ) {
        AttributeIfNotEmpty( "[nzRight]", value );
        return this;
    }

    /// <summary>
    /// 配置右侧距离
    /// </summary>
    public TableHeadColumnBuilder Right( string value, string title ) {
        if ( _shareConfig.IsEnableFixedColumn ) {
            BindRight( $"{_shareConfig.TableSettingsId}.isRight('{title}')" );
            return this;
        }
        Right( value );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public virtual TableHeadColumnBuilder Align() {
        if ( _shareConfig.IsEnableTableSettings )
            return this;
        AttributeIfNotEmpty( "nzAlign", _config.GetValue<TableHeadColumnAlign?>( UiConst.Align )?.Description() );
        BindAlign( _config.GetValue( AngularConst.BindAlign ) );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public TableHeadColumnBuilder BindAlign( string value ) {
        AttributeIfNotEmpty( "[nzAlign]", value );
        return this;
    }

    /// <summary>
    /// 配置标题对齐方式
    /// </summary>
    public virtual TableHeadColumnBuilder TitleAlign() {
        if ( _shareConfig.IsEnableTableSettings ) {
            var title = _shareConfig.Title;
            BindTitleAlign( $"{_shareConfig.TableSettingsId}.getTitleAlign('{title}')" );
            return this;
        }
        AttributeIfNotEmpty( "titleAlign", _shareConfig.TitleAlign );
        BindTitleAlign( _config.GetValue( AngularConst.BindTitleAlign ) );
        return this;
    }

    /// <summary>
    /// 配置标题对齐方式
    /// </summary>
    public virtual TableHeadColumnBuilder TitleAlign( string title ) {
        if ( _shareConfig.IsEnableTableSettings )
            BindTitleAlign( $"{_shareConfig.TableSettingsId}.getTitleAlign('{title}')" );
        return this;
    }

    /// <summary>
    /// 配置标题对齐方式
    /// </summary>
    public TableHeadColumnBuilder BindTitleAlign( string value ) {
        AttributeIfNotEmpty( "[titleAlign]", value );
        return this;
    }

    /// <summary>
    /// 配置是否折行显示
    /// </summary>
    public TableHeadColumnBuilder BreakWord() {
        AttributeIfNotEmpty( "[nzBreakWord]", _config.GetValue( UiConst.BreakWord ) );
        return this;
    }

    /// <summary>
    /// 配置自动省略
    /// </summary>
    public TableHeadColumnBuilder Ellipsis() {
        if ( _shareConfig.IsEnableTableSettings )
            return this;
        AttributeIfNotEmpty( "[nzEllipsis]", _config.GetValue( UiConst.Ellipsis ) );
        return this;
    }

    /// <summary>
    /// 配置列跨度
    /// </summary>
    public TableHeadColumnBuilder Colspan() {
        AttributeIfNotEmpty( "[colSpan]", _config.GetValue( UiConst.Colspan ) );
        return this;
    }

    /// <summary>
    /// 配置行跨度
    /// </summary>
    public TableHeadColumnBuilder Rowspan() {
        Rowspan( _config.GetValue( UiConst.Rowspan ) );
        return this;
    }

    /// <summary>
    /// 配置行跨度
    /// </summary>
    public TableHeadColumnBuilder Rowspan( string value ) {
        AttributeIfNotEmpty( "[rowSpan]", value );
        return this;
    }

    /// <summary>
    /// 配置列标识
    /// </summary>
    public TableHeadColumnBuilder ColumnKey() {
        AttributeIfNotEmpty( "nzColumnKey", _config.GetValue( UiConst.ColumnKey ) );
        AttributeIfNotEmpty( "[nzColumnKey]", _config.GetValue( AngularConst.BindColumnKey ) );
        return this;
    }

    /// <summary>
    /// 配置Operation标题
    /// </summary>
    public TableHeadColumnBuilder TitleOperation() {
        var value = _config.GetValue<bool?>( UiConst.TitleOperation );
        if ( value != true )
            return this;
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n ) {
            _config.SetAttribute( UiConst.Title, I18nKeys.Operation );
            return this;
        }
        _config.SetAttribute( UiConst.Title, "Operation" );
        return this;
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    public TableHeadColumnBuilder Title() {
        Title( _config.GetValue( UiConst.Title ) );
        return this;
    }

    /// <summary>
    /// 配置标题
    /// </summary>
    /// <param name="title">标题</param>
    public virtual void Title( string title ) {
        var options = NgZorroOptionsService.GetOptions();
        if ( title.IsEmpty() )
            return;
        if ( options.EnableI18n ) {
            this.AppendContentByI18n( title );
            return;
        }
        AppendContent( title );
    }

    /// <summary>
    /// 配置单元格控件
    /// </summary>
    public virtual TableHeadColumnBuilder CellControl() {
        CellControl( _config.GetValue( UiConst.CellControl ) );
        AttributeIfNotEmpty( "[nzCellControl]", _config.GetValue( AngularConst.BindCellControl ) );
        return this;
    }

    /// <summary>
    /// 配置单元格控件
    /// </summary>
    /// <param name="value">值</param>
    public virtual TableHeadColumnBuilder CellControl( string value ) {
        AttributeIfNotEmpty( "nzCellControl", value );
        return this;
    }

    /// <summary>
    /// 配置启用自定义列
    /// </summary>
    public TableHeadColumnBuilder EnableCustomColumn() {
        return EnableCustomColumn( _shareConfig.CellControl );
    }

    /// <summary>
    /// 配置启用自定义列
    /// </summary>
    public TableHeadColumnBuilder EnableCustomColumn( string cellControl ) {
        if ( _shareConfig.IsEnableCustomColumn == false )
            return this;
        CellControl( cellControl );
        return this;
    }

    /// <summary>
    /// 配置启用拖动调整列宽
    /// </summary>
    public TableHeadColumnBuilder EnableResizable() {
        if ( _shareConfig.IsEnableResizable == false )
            return this;
        return Resizable( _shareConfig.Title );
    }

    /// <summary>
    /// 配置拖动调整列宽
    /// </summary>
    public virtual TableHeadColumnBuilder Resizable( string title ) {
        Attribute( "nz-resizable" );
        Attribute( "nzPreview" );
        Attribute( "nzBounds", "window" );
        Attribute( "(nzResizeEnd)", $"{_shareConfig.TableSettingsId}.handleResize($event,'{title}')" );
        AppendHandleBuilder();
        return this;
    }

    /// <summary>
    /// 添加拖动手柄生成器
    /// </summary>
    protected void AppendHandleBuilder() {
        var handleBuilder = new ResizeHandleBuilder( _config );
        handleBuilder.Direction( ResizeDirection.Right );
        AppendContent( handleBuilder );
    }

    /// <summary>
    /// 配置事件
    /// </summary>
    public TableHeadColumnBuilder Events() {
        AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
        AttributeIfNotEmpty( "(nzFilterChange)", _config.GetValue( UiConst.OnFilterChange ) );
        OnSortOrderChange( _config.GetValue( UiConst.OnSortOrderChange ) );
        return this;
    }

    /// <summary>
    /// 排序事件
    /// </summary>
    public TableHeadColumnBuilder OnSortOrderChange( string value ) {
        AttributeIfNotEmpty( "(nzSortOrderChange)", value );
        return this;
    }

    /// <summary>
    /// 配置
    /// </summary>
    public override void Config() {
        base.Config();
        ShowCheckbox().Disabled().Indeterminate().Checked()
            .ShowRowSelection().Selections()
            .ShowSort().SortFn().SortDirections().SortOrder().Sort()
            .ShowFilter().FilterFn().Filters().FilterMultiple()
            .Width().Left().Right().Align().BreakWord().Ellipsis()
            .Colspan().Rowspan().ColumnKey()
            .TitleOperation().Title().TitleAlign()
            .CellControl().EnableCustomColumn().EnableResizable()
            .Events()
            .CheckBox().Radio().LineNumber();
    }

    /// <summary>
    /// 添加复选框
    /// </summary>
    public TableHeadColumnBuilder CheckBox() {
        if ( _shareConfig.IsShowCheckbox == false )
            return this;
        if ( _shareConfig.IsFirst == false )
            return this;
        AddCheckBox();
        return this;
    }

    /// <summary>
    /// 添加复选框
    /// </summary>
    protected virtual void AddCheckBox( string title = null ) {
        var checkboxBuilder = new TableHeadColumnBuilder( _config, _shareConfig );
        checkboxBuilder.ConfigCheckBox();
        PreBuilder = checkboxBuilder;
    }

    /// <summary>
    /// 配置复选框
    /// </summary>
    public void ConfigCheckBox() {
        var title = "util.checkbox";
        Attribute( "[nzShowCheckbox]", "true" );
        Attribute( "(nzCheckedChange)", $"{_shareConfig.TableExtendId}.masterToggle()" );
        Attribute( "[nzChecked]", $"{_shareConfig.TableExtendId}.isMasterChecked()" );
        Attribute( "[nzDisabled]", $"!{_shareConfig.TableExtendId}.dataSource.length" );
        Attribute( "[nzIndeterminate]", $"{_shareConfig.TableExtendId}.isMasterIndeterminate()" );
        EnableCustomColumn( title );
        if ( _shareConfig.IsEnableCustomColumn == false )
            BindWidth( $"{_shareConfig.TableExtendId}.config.table.checkboxWidth" );
        Left( _shareConfig.IsCheckboxLeft, title );
        if ( _shareConfig.IsEnableFixedColumn )
            Right( _shareConfig.IsCheckboxLeft, title );
        TitleAlign( title );
        ConfigRowSpan();
    }

    /// <summary>
    /// 配置行跨度
    /// </summary>
    protected void ConfigRowSpan() {
        if (_shareConfig.HeadRowNumber < 2)
            return;
        Rowspan(_shareConfig.HeadRowNumber.ToString());
    }

    /// <summary>
    /// 添加单选框列头
    /// </summary>
    public TableHeadColumnBuilder Radio() {
        if ( _shareConfig.IsShowCheckbox )
            return this;
        if ( _shareConfig.IsShowRadio == false )
            return this;
        if ( _shareConfig.IsFirst == false )
            return this;
        AddRadio();
        return this;
    }

    /// <summary>
    /// 添加单选框列头
    /// </summary>
    protected virtual void AddRadio( string title = null ) {
        var radioTitle = "util.radio";
        var radioBuilder = new TableHeadColumnBuilder( _config, _shareConfig );
        radioBuilder.EnableCustomColumn( radioTitle );
        radioBuilder.TitleAlign( radioTitle );
        radioBuilder.Left( _shareConfig.IsRadioLeft, radioTitle );
        if ( _shareConfig.IsEnableFixedColumn )
            radioBuilder.Right( _shareConfig.IsRadioLeft, radioTitle );
        if ( _shareConfig.IsEnableCustomColumn == false )
            radioBuilder.BindWidth( $"{_shareConfig.TableExtendId}.config.table.radioWidth" );
        radioBuilder.ConfigRowSpan();
        PreBuilder = radioBuilder;
    }

    /// <summary>
    /// 配置序号
    /// </summary>
    public TableHeadColumnBuilder LineNumber() {
        if ( _shareConfig.IsShowLineNumber == false )
            return this;
        if ( _shareConfig.IsFirst == false )
            return this;
        AddLineNumber();
        return this;
    }

    /// <summary>
    /// 添加序号
    /// </summary>
    protected virtual void AddLineNumber() {
        var title = "util.lineNumber";
        var lineNumberBuilder = new TableHeadColumnBuilder( _config, _shareConfig );
        lineNumberBuilder.ConfigLineNumber();
        lineNumberBuilder.EnableCustomColumn( title );
        lineNumberBuilder.TitleAlign( title );
        lineNumberBuilder.ConfigRowSpan();
        if ( PreBuilder == null ) {
            PreBuilder = lineNumberBuilder;
            return;
        }
        PreBuilder.PostBuilder = lineNumberBuilder;
    }

    /// <summary>
    /// 配置序号
    /// </summary>
    public void ConfigLineNumber() {
        var options = NgZorroOptionsService.GetOptions();
        Title( options.EnableI18n ? "util.lineNumber" : "序号" );
        if ( _shareConfig.IsEnableCustomColumn == false )
            BindWidth( $"{_shareConfig.TableExtendId}.config.table.lineNumberWidth" );
        Left( _shareConfig.IsLineNumberLeft, "util.lineNumber" );
        if ( _shareConfig.IsEnableFixedColumn )
            Right( _shareConfig.IsLineNumberLeft, "util.lineNumber" );
    }

    /// <summary>
    /// 添加表头单元格
    /// </summary>
    /// <param name="column">列</param>
    public virtual void AddColumn( ColumnInfo column ) {
        if ( column.IsFirst ) {
            if ( _shareConfig.IsShowCheckbox )
                AddCheckBox();
            if ( _shareConfig.IsShowCheckbox == false && _shareConfig.IsShowRadio )
                AddRadio();
            if ( _shareConfig.IsShowLineNumber )
                AddLineNumber();
        }
        if ( column.IsSort )
            Sort( column.Column );
        Title( column.Title );
        SetColumnWidth( column );
        Left( column.IsLeft, column.Title );
        Right( column.IsRight, column.Title );
        SetAcl( column.Acl, column.AclElseTemplateId );
        EnableCustomColumn( column.GetCellControl() );
        EnableResizable( column );
        TitleAlign( column.Title );
    }

    /// <summary>
    /// 设置列宽
    /// </summary>
    protected void SetColumnWidth( ColumnInfo column ) {
        if ( _shareConfig.IsEnableCustomColumn )
            return;
        if ( IsEnableResizable( column ) ) {
            Attribute( "[nzWidth]", GetWidthByTableSettings( column.Title, column.Width ) );
            return;
        }
        this.Width( column.Width );
    }

    /// <summary>
    /// 从表格设置获取宽度
    /// </summary>
    protected string GetWidthByTableSettings( string title, string width ) {
        if ( width.IsEmpty() )
            return $"{_shareConfig.TableSettingsId}.getWidth('{title}')";
        return $"{_shareConfig.TableSettingsId}.getWidth('{title}','{width}')";
    }

    /// <summary>
    /// 配置访问控制列表
    /// </summary>
    public TableHeadColumnBuilder SetAcl( string acl, string aclElseTemplateId ) {
        _config.SetAttribute( UiConst.Acl, acl );
        _config.SetAttribute( UiConst.AclElseTemplateId, aclElseTemplateId );
        this.Acl( _config );
        return this;
    }

    /// <summary>
    /// 配置启用拖动调整列宽
    /// </summary>
    protected void EnableResizable( ColumnInfo column ) {
        if ( IsEnableResizable( column ) == false )
            return;
        Resizable( column.Title );
    }

    /// <summary>
    /// 是否启用拖动调整列宽
    /// </summary>
    protected bool IsEnableResizable( ColumnInfo column ) {
        if ( column.IsEnableResizable )
            return true;
        return _shareConfig.IsEnableResizable;
    }
}