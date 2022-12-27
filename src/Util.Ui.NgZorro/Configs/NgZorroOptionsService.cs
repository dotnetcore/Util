using Microsoft.Extensions.Options;
using Util.Helpers;

namespace Util.Ui.NgZorro.Configs {
    /// <summary>
    /// NgZorro配置服务
    /// </summary>
    public static class NgZorroOptionsService {
        /// <summary>
        /// 获取NgZorro配置
        /// </summary>
        public static NgZorroOptions GetOptions() {
            var options = Ioc.Create<IOptions<NgZorroOptions>>();
            if ( options == null || options.Value == null )
                return new NgZorroOptions();
            return options.Value;
        }
    }
}
