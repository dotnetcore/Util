using System.Threading.Tasks;
using Util.Generators.Contexts;

namespace Util.Generators.Resources {
    /// <summary>
    /// 静态资源管理器
    /// </summary>
    public interface IResourceManager {
        /// <summary>
        /// 导入静态资源
        /// </summary>
        /// <param name="templateRootPath">模板根目录路径</param>
        /// <param name="outputRootPath">输出根目录路径</param>
        /// <param name="project">项目上下文</param>
        Task ImportsAsync( string templateRootPath, string outputRootPath,ProjectContext project );
    }
}
