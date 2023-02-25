using System.Threading.Tasks;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 生成器上下文构建器
    /// </summary>
    public interface IGeneratorContextBuilder {
        /// <summary>
        /// 创建生成器上下文
        /// </summary>
        Task<GeneratorContext> BuildAsync();
    }
}
