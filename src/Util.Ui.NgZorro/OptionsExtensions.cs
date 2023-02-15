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

        /// <summary>
        /// 是否启用默认项文本
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="isEnableDefaultOptionText">是否启用默认项文本,默认值: true</param>
        public static NgZorroOptions EnableDefaultOptionText( this NgZorroOptions options, bool isEnableDefaultOptionText = true ) {
            options.CheckNull( nameof( options ) );
            options.EnableDefaultOptionText = isEnableDefaultOptionText;
            return options;
        }

        /// <summary>
        /// 是否启用多语言
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="isEnableI18n">是否启用多语言,默认值: true</param>
        public static NgZorroOptions EnableI18n( this NgZorroOptions options, bool isEnableI18n = true ) {
            options.CheckNull( nameof( options ) );
            options.EnableI18n = isEnableI18n;
            return options;
        }
    }
}
