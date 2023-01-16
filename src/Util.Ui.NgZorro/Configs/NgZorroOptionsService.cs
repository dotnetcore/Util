using Microsoft.Extensions.Options;
using System.Threading;
using Util.Helpers;

namespace Util.Ui.NgZorro.Configs {
    /// <summary>
    /// NgZorro配置服务
    /// </summary>
    public static class NgZorroOptionsService {
        /// <summary>
        /// NgZorro配置
        /// </summary>
        private static readonly AsyncLocal<NgZorroOptions> _options = new();

        /// <summary>
        /// 获取NgZorro配置
        /// </summary>
        public static NgZorroOptions GetOptions() {
            if ( _options.Value != null )
                return _options.Value;
            var options = Ioc.Create<IOptions<NgZorroOptions>>();
            if ( options == null )
                return new NgZorroOptions();
            return options.Value;
        }

        /// <summary>
        /// 设置NgZorro配置
        /// </summary>
        public static void SetOptions( NgZorroOptions options ) {
            _options.Value = options;
        }

        /// <summary>
        /// 清空NgZorro配置
        /// </summary>
        public static void ClearOptions() {
            _options.Value = null;
        }
    }
}
