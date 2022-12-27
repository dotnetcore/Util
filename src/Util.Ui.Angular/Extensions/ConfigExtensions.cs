using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.Angular.Extensions {
    /// <summary>
    /// 配置扩展
    /// </summary>
    public static class ConfigExtensions {
        /// <summary>
        /// 复制并移除标识
        /// </summary>
        /// <param name="config">配置</param>
        public static Config CopyRemoveId( this Config  config ) {
            var result = config.Copy();
            result.RemoveAttribute( UiConst.Id );
            result.RemoveAttribute( AngularConst.RawId );
            return result;
        }
    }
}
