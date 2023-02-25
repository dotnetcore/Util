using System.Threading.Tasks;

namespace Util.Generators.Configuration {
    /// <summary>
    /// 生成器配置项构建器
    /// </summary>
    public interface IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        Task<GeneratorOptions> BuildAsync();
    }
}
