using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents; 

/// <summary>
/// 表格单元格枚举内容
/// </summary>
public class TableColumnEnumContent : ITableColumnContent {
    /// <inheritdoc />
    public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
        var column = builder.GetConfig().GetValue( UiConst.Column );
        var content = builder.GetConfig().GetValue( UiConst.EnumContent );
        return column.IsEmpty() ? null : new StringHtmlContent( content );
    }
}