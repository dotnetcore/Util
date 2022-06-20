using System.Collections.Generic;

namespace Util.Configs {
    /// <summary>
    /// 配置项基类
    /// </summary>
    public abstract class OptionsBase : IOptions {
        /// <summary>
        /// 初始化配置项
        /// </summary>
        protected OptionsBase() {
            Extensions = new List<IOptionsExtension>();
        }

        /// <summary>
        /// 配置项扩展列表
        /// </summary>
        public List<IOptionsExtension> Extensions { get; }

        /// <summary>
        /// 添加配置项扩展
        /// </summary>
        /// <param name="extension">配置项扩展</param>
        public void AddExtension( IOptionsExtension extension ) {
            extension.CheckNull( nameof( extension ) );
            Extensions.Add( extension );
        }
    }
}
