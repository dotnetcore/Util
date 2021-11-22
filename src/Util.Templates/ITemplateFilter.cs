namespace Util.Templates {
    /// <summary>
    /// 模板过滤器
    /// </summary>
    public interface ITemplateFilter {
        /// <summary>
        /// 过滤模板
        /// </summary>
        /// <param name="template">模板字符串</param>
        string Filter( string template );
    }
}
