using System.Threading.Tasks;
using Util.Helpers;

namespace Util.Generators.Configuration {
    /// <summary>
    /// 生成器配置项构建器
    /// </summary>
    public class GeneratorOptionsBuilder : IGeneratorOptionsBuilder {
        /// <summary>
        /// 构建生成器配置项
        /// </summary>
        public Task<GeneratorOptions> BuildAsync() {
            var result = Config.Get<GeneratorOptions>( "Generator" );
            return Task.FromResult( result );
        }
    }
}
