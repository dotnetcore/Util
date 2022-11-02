using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格单元格文本内容
    /// </summary>
    public class TableColumnTextContent : ITableColumnContent {
        /// <inheritdoc />
        public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
            var column = builder.GetConfig().GetValue( UiConst.Column );
            return column.IsEmpty() ? null : new StringHtmlContent( $"{{{{row.{column}}}}}" );
        }
    }
}