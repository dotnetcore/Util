using Util.Helpers;

namespace Util.Templates.Razor.Filters {
    /// <summary>
    /// 模型过滤器,对模板中的@model进行替换
    /// </summary>
    public class ModelFilter : ITemplateFilter {
        /// <summary>
        /// 过滤模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        public string Filter( string template ) {
            return Regex.Replace( template, @"@model\s+(\w+)", "@inherits RazorEngineCore.RazorEngineTemplateBase<$1>" ); 
        }
    }
}
