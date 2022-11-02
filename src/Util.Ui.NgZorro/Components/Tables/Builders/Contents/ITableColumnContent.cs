using Microsoft.AspNetCore.Html;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格列内容
    /// </summary>
    public interface ITableColumnContent {
        /// <summary>
        /// 获取显示内容
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        IHtmlContent GetDisplayContent( TableColumnBuilder builder );
    }
}
