using Util.Configs;

namespace Util.Applications {
    /// <summary>
    /// 业务锁操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置业务锁
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseLock( this Options options ) {
            options.AddExtension( new LockOptionsExtension() );
            return options;
        }
    }
}
