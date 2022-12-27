using Util.Configs;

namespace Util.Dates {
    /// <summary>
    /// 日期操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 使用Utc日期
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="isUseUtc">是否使用Utc日期</param>
        public static Options UseUtc( this Options options, bool isUseUtc = true ) {
            TimeOptions.IsUseUtc = isUseUtc;
            return options;
        }
    }
}
