using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Factories {
    /// <summary>
    /// 表格列选择框标签生成器工厂
    /// </summary>
    public interface ISelectBuilderFactory {
        /// <summary>
        /// 创建表格列复选框标签生成器
        /// </summary>
        /// <param name="content">内容</param>
        TagBuilder CreateCheckbox( IHtmlContent content );
        /// <summary>
        /// 创建表格列单选框标签生成器
        /// </summary>
        /// <param name="content">内容</param>
        TagBuilder CreateRadio( IHtmlContent content );
    }
}
