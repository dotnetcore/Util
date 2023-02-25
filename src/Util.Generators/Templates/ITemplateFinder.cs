using System.Collections.Generic;
using Util.Generators.Contexts;

namespace Util.Generators.Templates {
    /// <summary>
    /// 模板查找器
    /// </summary>
    public interface ITemplateFinder {
        /// <summary>
        /// 查找模板列表
        /// </summary>
        /// <param name="rootPath">模板根目录绝对路径</param>
        /// <param name="projectContext">项目上下文</param>
        IEnumerable<ITemplate> Find( string rootPath, ProjectContext projectContext );
    }
}
