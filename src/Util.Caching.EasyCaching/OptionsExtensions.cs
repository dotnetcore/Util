using System;
using EasyCaching.Core.Configurations;
using Util.Configs;

namespace Util.Caching.EasyCaching {
    /// <summary>
    /// EasyCaching缓存操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置EasyCaching缓存操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">EasyCaching缓存配置操作</param>
        public static Options UseEasyCaching( this Options options, Action<EasyCachingOptions> setupAction ) {
            options.AddExtension( new EasyCachingOptionsExtension( setupAction ) );
            return options;
        }
    }
}
