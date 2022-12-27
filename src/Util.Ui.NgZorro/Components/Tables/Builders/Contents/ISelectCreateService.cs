using Microsoft.AspNetCore.Html;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格列选择框创建服务
    /// </summary>
    public interface ISelectCreateService {
        /// <summary>
        /// 创建表格列复选框
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        /// <param name="content">内容</param>
        void CreateCheckbox( TableColumnBuilder builder, IHtmlContent content );
        /// <summary>
        /// 创建表格列单选框
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        /// <param name="content">内容</param>
        void CreateRadio( TableColumnBuilder builder, IHtmlContent content );
        /// <summary>
        /// 是否将内容添加到选择框
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        bool IsAddContentToSelect( TableColumnBuilder builder );
    }
}
