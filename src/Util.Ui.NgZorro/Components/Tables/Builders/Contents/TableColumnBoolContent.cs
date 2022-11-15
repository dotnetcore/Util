using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格单元格布尔内容
    /// </summary>
    public class TableColumnBoolContent : ITableColumnContent {
        /// <inheritdoc />
        public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
            var column = builder.GetConfig().GetValue( UiConst.Column );
            if ( column.IsEmpty() )
                return null;
            var tableExtendId = builder.GetTableColumnShareConfig().TableExtendId;
            return new StringHtmlContent( $"{{{{row.{column}?{tableExtendId}.config.text.yes:{tableExtendId}.config.text.no}}}}" );
        }
    }
}