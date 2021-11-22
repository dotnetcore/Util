using Util.Helpers;

namespace Util.Templates.Razor.Filters {
    /// <summary>
    /// 部分视图过滤器,移除模板中的await
    /// </summary>
    public class PartialAsyncFilter : ITemplateFilter {
        /// <summary>
        /// 过滤模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        public string Filter( string template ) {
            return Regex.Replace( template, @"await\s+Html.PartialAsync", "Html.PartialAsync" ); 
        }
    }
}
