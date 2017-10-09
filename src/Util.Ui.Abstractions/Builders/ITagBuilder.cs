using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace Util.Ui.Builders {
    /// <summary>
    /// 标签生成器
    /// </summary>
    public interface ITagBuilder {
        /// <summary>
        /// Html内容
        /// </summary>
        IHtmlContentBuilder InnerHtml { get; }
        /// <summary>
        /// 添加标识
        /// </summary>
        /// <param name="id">标识</param>
        ITagBuilder Id( string id );
        /// <summary>
        /// 添加属性,当属性名已存在则忽略，也可进行替换
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        ITagBuilder Attribute( string name, string value, bool replaceExisting = false );
        /// <summary>
        /// 添加class属性
        /// </summary>
        /// <param name="class">class属性值</param>
        ITagBuilder Class( string @class );
        /// <summary>
        /// 写入文本流
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        void WriteTo( TextWriter writer, HtmlEncoder encoder );
    }
}
