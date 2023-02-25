using System.Collections.Generic;

namespace Util.Generators.Configuration {
    /// <summary>
    /// 生成器配置项
    /// </summary>
    public class GeneratorOptions {
        /// <summary>
        /// 初始化生成器配置项
        /// </summary>
        public GeneratorOptions() {
            Projects = new Dictionary<string, ProjectOptions>();
            Messages = new MessageOptions();
        }

        /// <summary>
        /// 模板根目录路径
        /// </summary>
        public string TemplatePath { get; set; }
        /// <summary>
        /// 输出根目录路径
        /// </summary>
        public string OutputPath { get; set; }
        /// <summary>
        /// 项目列表
        /// </summary>
        public Dictionary<string, ProjectOptions> Projects { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public MessageOptions Messages { get; set; }
    }
}
