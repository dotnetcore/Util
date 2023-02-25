using Util.Logging;

namespace Util.Generators.Logs {
    /// <summary>
    /// 空生成器日志操作
    /// </summary>
    public class NullGeneratorLogger : GeneratorLogger {
        /// <summary>
        /// 初始化空生成器日志操作
        /// </summary>
        public NullGeneratorLogger() : base( Log<Generator>.Null ) {
        }

        /// <summary>
        /// 空生成器日志操作实例
        /// </summary>
        public static readonly IGeneratorLogger Instance = new NullGeneratorLogger();
    }
}
