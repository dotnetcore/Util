using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Extensions;
using Util.Ui.Builders;
using Util.Ui.NgZorro.Components.Buttons.Builders;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents;

/// <summary>
/// 表格单元格文本内容
/// </summary>
public class TableColumnTextContent : ITableColumnContent {
    /// <inheritdoc />
    public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
        var config = builder.GetConfig();
        var column = config.GetValue( UiConst.Column );
        if ( column.IsEmpty() )
            return null;
        var columnBuilder = new StringHtmlContent( $"{{{{row.{column}}}}}" );
        var buttonBuilder = GetCopyToClipboardButton( config.Copy() );
        if ( buttonBuilder == null )
            return columnBuilder;
        var containerBuilder = new EmptyContainerTagBuilder();
        containerBuilder.AppendContent( columnBuilder );
        containerBuilder.AppendContent( buttonBuilder );
        return containerBuilder;
    }

    /// <summary>
    /// 获取复制到剪贴板按钮
    /// </summary>
    private IHtmlContent GetCopyToClipboardButton( Config config ) {
        if ( config.GetValue<bool?>( UiConst.Clipboard ) != true )
            return null;
        var id = config.GetValue( UiConst.Id );
        var column = config.GetValue( UiConst.Column );
        var value = $"row.{column}";
        config.SetAttribute( UiConst.Id, $"btn_{id}_{column.Kebaberize().Replace( "-", "_" )}" );
        config.SetAttribute( UiConst.CopyToClipboard, value );
        var buttonBuilder = new ButtonBuilder( config );
        buttonBuilder.Attribute( "nz-button" );
        buttonBuilder.NgIf( value );
        buttonBuilder.Id( config ).CopyToClipboard().Type().Icon();
        return buttonBuilder;
    }
}