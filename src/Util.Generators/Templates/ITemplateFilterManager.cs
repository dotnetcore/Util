using System.Collections.Generic;
using Util.Generators.Contexts;

namespace Util.Generators.Templates {
    /// <summary>
    /// 模板过滤器管理器
    /// </summary>
    public interface ITemplateFilterManager {
        /// <summary>
        /// 获取模板过滤器
        /// </summary>
        public List<ITemplateFilter> GetFilters();
        /// <summary>
        /// 是否过滤模板,返回true则不生成该模板
        /// </summary>
        /// <param name="rootPath">模板根目录绝对路径</param>
        /// <param name="projectContext">项目上下文</param>
        bool IsFilter( string rootPath, ProjectContext projectContext );
    }
}
