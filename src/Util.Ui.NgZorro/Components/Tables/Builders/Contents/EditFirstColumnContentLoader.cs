using Microsoft.AspNetCore.Html;
using Util.Ui.NgZorro.Components.Tables.Builders.Factories;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 编辑模式第一列内容加载器
    /// </summary>
    public class EditFirstColumnContentLoader : NoEditFirstColumnContentLoader {
        /// <summary>
        /// 初始化编辑模式第一列内容加载器
        /// </summary>
        /// <param name="factory">表格列选择框标签生成器工厂</param>
        public EditFirstColumnContentLoader( ISelectBuilderFactory factory ) : base( factory ) {
        }

        /// <summary>
        /// 获取显示内容
        /// </summary>
        protected override IHtmlContent GetDisplayContent( TableColumnBuilder builder, IHtmlContent htmlContent ) {
            return htmlContent;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        protected override void AddContent( TableColumnBuilder builder, IHtmlContent content ) {
            var loader = new EditContentLoader();
            loader.Load( builder, content );
        }
    }
}
