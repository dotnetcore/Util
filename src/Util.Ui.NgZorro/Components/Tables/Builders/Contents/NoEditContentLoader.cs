using Microsoft.AspNetCore.Html;
using Util.Ui.Extensions;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 非编辑模式非第一列内容加载器
    /// </summary>
    public class NoEditContentLoader : ITableColumnContentLoader {
        /// <inheritdoc />
        public void Load( TableColumnBuilder builder, IHtmlContent content ) {
            content = GetContent( builder, content );
            builder.SetContent( content );
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        private IHtmlContent GetContent( TableColumnBuilder builder, IHtmlContent htmlContent ) {
            var content = builder.GetConfig().Content;
            if ( content.IsEmpty() == false )
                return content;
            return htmlContent;
        }
    }
}
