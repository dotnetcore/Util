using System;
using Util.Configs;

namespace Util.Ui.NgZorro {
    /// <summary>
    /// NgZorro配置扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置NgZorro依赖服务
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">NgZorro配置操作</param>
        public static Options UseNgZorro( this Options options, Action<NgZorroOptions> setupAction = null ) {
            options.CheckNull( nameof( options ) );
            options.AddExtension( new NgZorroOptionsExtension( setupAction ) );
            return options;
        }
    }
}
