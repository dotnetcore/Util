using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Xunit.Abstractions;

namespace Util.Ui.Angular.AntDesign.Tests.XUnitHelpers {
    /// <summary>
    /// 辅助操作
    /// </summary>
    public static class Helper {
        /// <summary>
        /// 获取结果
        /// </summary>
        /// <typeparam name="TTagHelper">TagHelper组件类型</typeparam>
        /// <param name="outputHelper">输出工具</param>
        /// <param name="component">TagHelper组件</param>
        /// <param name="contextAttributes">上下文属性集合</param>
        /// <param name="outputAttributes">输出属性集合</param>
        /// <param name="content">内容</param>
        /// <param name="items">项集合</param>
        public static string GetResult<TTagHelper>( ITestOutputHelper outputHelper, TTagHelper component, TagHelperAttributeList contextAttributes = null,
            TagHelperAttributeList outputAttributes = null, TagHelperContent content = null, IDictionary<object, object> items = null ) where TTagHelper : TagHelper {
            var context = new TagHelperContext( "", contextAttributes ?? new TagHelperAttributeList(), items ?? new Dictionary<object, object>(), Id.Guid() );
            var output = new TagHelperOutput( "", outputAttributes ?? new TagHelperAttributeList(), ( useCachedResult, encoder ) => Task.FromResult( content ) );
            component.ProcessAsync( context, output );
            var writer = new StringWriter();
            output.WriteTo( writer, HtmlEncoder.Default );
            var result = writer.ToString();
            outputHelper.WriteLine( result );
            return result;
        }
    }
}
