using Microsoft.AspNetCore.Html;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格列内容加载器
    /// </summary>
    public interface ITableColumnContentLoader {
        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        /// <param name="displayContent">显示内容</param>
        void Load( TableColumnBuilder builder, IHtmlContent displayContent );
    }
}
