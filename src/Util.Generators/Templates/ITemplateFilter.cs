using Util.Generators.Contexts;

namespace Util.Generators.Templates {
    /// <summary>
    /// 模板过滤器
    /// </summary>
    public interface ITemplateFilter {
        /// <summary>
        /// 是否过滤模板,返回true则不生成该模板
        /// </summary>
        /// <param name="path">模板绝对路径</param>
        /// <param name="projectContext">项目上下文</param>
        bool IsFilter( string path, ProjectContext projectContext );
    }
}
