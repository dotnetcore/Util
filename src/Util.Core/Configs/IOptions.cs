using System.Collections.Generic;

namespace Util.Configs {
    /// <summary>
    /// 配置项
    /// </summary>
    public interface IOptions {
        /// <summary>
        /// 配置项扩展列表
        /// </summary>
        List<IOptionsExtension> Extensions { get; }
        /// <summary>
        /// 添加配置项扩展
        /// </summary>
        /// <param name="extension">配置项扩展</param>
        void AddExtension( IOptionsExtension extension );
    }
}
