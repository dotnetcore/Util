using Microsoft.AspNetCore.Html;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格列选择框创建服务
    /// </summary>
    public class TableSelectCreateService : ISelectCreateService {
        /// <inheritdoc />
        public void CreateCheckbox( TableColumnBuilder builder, IHtmlContent content ) {
            var columnBuilder = new TableColumnBuilder( builder.GetConfig(), builder.GetTableColumnShareConfig() );
            columnBuilder.AddCheckbox();
            builder.PreBuilder = columnBuilder;
        }

        /// <inheritdoc />
        public void CreateRadio( TableColumnBuilder builder, IHtmlContent content ) {
            var columnBuilder = new TableColumnBuilder( builder.GetConfig(), builder.GetTableColumnShareConfig() );
            var radioBuilder = new TableColumnRadioBuilder( builder.GetConfig(), builder.GetTableColumnShareConfig().TableExtendId );
            columnBuilder.AppendContent( radioBuilder );
            builder.PreBuilder = columnBuilder;
        }

        /// <summary>
        /// 是否将内容添加到选择框
        /// </summary>
        /// <param name="builder">表格单元格标签生成器</param>
        public bool IsAddContentToSelect( TableColumnBuilder builder ) {
            return false;
        }
    }
}
