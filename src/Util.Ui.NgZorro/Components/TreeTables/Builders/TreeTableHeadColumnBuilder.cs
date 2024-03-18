using Util.Ui.Angular.Configs;
using Util.Ui.NgZorro.Components.Tables.Builders;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Components.Tables.Helpers;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
namespace Util.Ui.NgZorro.Components.TreeTables.Builders;

/// <summary>
/// 树形表头单元格标签生成器
/// </summary>
public class TreeTableHeadColumnBuilder : TableHeadColumnBuilder {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;
    /// <summary>
    /// 表头列共享配置
    /// </summary>
    private readonly TableHeadColumnShareConfig _shareConfig;

    /// <summary>
    /// 初始化树形表头单元格标签生成器
    /// </summary>
    /// <param name="config">配置</param>
    /// <param name="shareConfig">表头列共享配置</param>
    public TreeTableHeadColumnBuilder( Config config, TableHeadColumnShareConfig shareConfig ) : base( config, shareConfig ) {
        _config = config;
        _shareConfig = shareConfig;
    }

    /// <summary>
    /// 配置标题对齐方式
    /// </summary>
    public override TableHeadColumnBuilder TitleAlign() {
        if ( _shareConfig.IsFirst )
            return this;
        if ( _shareConfig.IsEnableTableSettings ) {
            var title = _config.GetValue( UiConst.Title );
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
    public override TableHeadColumnBuilder TitleAlign( string title ) {
        if ( _shareConfig.IsFirst )
            return this;
        if ( _shareConfig.IsEnableTableSettings )
            BindTitleAlign( $"{_shareConfig.TableSettingsId}.getTitleAlign('{title}')" );
        return this;
    }

    /// <summary>
    /// 配置对齐方式
    /// </summary>
    public override TableHeadColumnBuilder Align() {
        if ( _shareConfig.IsFirst )
            return this;
        if ( _shareConfig.IsEnableTableSettings )
            return this;
        AttributeIfNotEmpty( "nzAlign", _config.GetValue<TableHeadColumnAlign?>( UiConst.Align )?.Description() );
        BindAlign( _config.GetValue( AngularConst.BindAlign ) );
        return this;
    }

    /// <inheritdoc />
    protected override void ConfigContent( Config config ) {
        if ( _shareConfig.IsFirst && _shareConfig.IsShowCheckbox )
            return;
        base.ConfigContent( config );
    }

    /// <summary>
    /// 添加表头单元格
    /// </summary>
    /// <param name="column">列</param>
    public override void AddColumn( ColumnInfo column ) {
        if ( column.IsFirst )
            AddFirstColumn( column );
        else
            Title( column.Title );
        if ( column.IsSort )
            Sort( column.Column );
        SetColumnWidth( column );
        Left( column.IsLeft, column.Title );
        Right( column.IsRight, column.Title );
        SetAcl( column.Acl, column.AclElseTemplateId );
        EnableCustomColumn( column.GetCellControl() );
        EnableResizable( column );
        TitleAlign( column.Title );
    }

    /// <summary>
    /// 添加首列
    /// </summary>
    private void AddFirstColumn( ColumnInfo column ) {
        if ( _shareConfig.IsShowCheckbox ) {
            AddCheckBox( column.Title );
            return;
        }
        if ( _shareConfig.IsShowCheckbox == false && _shareConfig.IsShowRadio ) {
            AddRadio( column.Title );
            return;
        }
        if ( _shareConfig.IsShowLineNumber ) {
            AddLineNumber();
            return;
        }
        Title( column.Title );
    }

    /// <summary>
    /// 配置拖动调整列宽
    /// </summary>
    public override TableHeadColumnBuilder Resizable( string title ) {
        Attribute( "nz-resizable" );
        Attribute( "nzPreview" );
        Attribute( "nzBounds", "window" );
        Attribute( "(nzResizeEnd)", $"{_shareConfig.TableSettingsId}.handleResize($event,'{title}')" );
        if (_shareConfig.IsFirst) {
            if( _shareConfig.IsShowCheckbox )
                return this;
            if ( _shareConfig.IsShowRadio )
                return this;
        }
        AppendHandleBuilder();
        return this;
    }

    /// <inheritdoc />
    protected override void AddCheckBox( string title = null ) {
        title = GetTitle( title );
        if ( title.IsEmpty() )
            title = _config.Content?.GetContent();
        var checkboxBuilder = new TreeTableMasterCheckBoxBuilder( _shareConfig.TableExtendId, title );
        SetContent( checkboxBuilder );
        if ( _shareConfig.IsEnableResizable )
            AppendHandleBuilder();
        Left( _shareConfig.IsCheckboxLeft );
    }

    /// <summary>
    /// 获取标题
    /// </summary>
    /// <param name="title">标题</param>
    private string GetTitle( string title ) {
        title ??= _config.GetValue( UiConst.Title );
        var options = NgZorroOptionsService.GetOptions();
        if ( options.EnableI18n )
            return "{{" + $"'{title}'|i18n" + "}}";
        return title;
    }

    /// <inheritdoc />
    protected override void AddRadio( string title = null ) {
        title = GetTitle( title );
        if ( title.IsEmpty() )
            title = _config.Content?.GetContent();
        SetContent( title );
        if ( _shareConfig.IsEnableResizable )
            AppendHandleBuilder();
        Left( _shareConfig.IsRadioLeft );
    }
}