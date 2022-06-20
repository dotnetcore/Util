using Util.Configs;

namespace Util.Localization {
    /// <summary>
    /// 本地化操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置Json本地化
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="resourcesPath">资源路径,默认值: Resources</param>
        public static Options UseJsonLocalization( this Options options,string resourcesPath = "Resources" ) {
            options.Extensions.Add( new JsonLocalizationOptionsExtension( resourcesPath ) );
            return options;
        }
    }
}
