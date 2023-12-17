using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents; 

/// <summary>
/// 表格单元格布尔内容
/// </summary>
public class TableColumnBoolContent : ITableColumnContent {
    /// <inheritdoc />
    public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
        var column = builder.GetConfig().GetValue( UiConst.Column );
        if ( column.IsEmpty() )
            return null;
        var options = NgZorroOptionsService.GetOptions();
        var result = GetResult( options, column );
        return new StringHtmlContent( result );
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    private string GetResult(NgZorroOptions options,string column) {
        if ( options.GetTableColumnBoolContentAction != null )
            return options.GetTableColumnBoolContentAction( column );
        var result = new StringBuilder();
        result.AppendLine( $"<i *ngIf=\"!row.{column}\" nz-icon nzType=\"close\"></i>" );
        result.AppendLine( $"<i *ngIf=\"row.{column}\" nz-icon nzType=\"check\"></i>" );
        return result.ToString();
    }
}