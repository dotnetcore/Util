using System;
using Util.Configs;

namespace Util.FileStorage.Minio {
    /// <summary>
    /// Minio文件存储操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置Minio文件存储操作
        /// </summary>
        /// <param name="options">配置项</param>
        public static Options UseMinio( this Options options ) {
            options.AddExtension( new MinioOptionsExtension( null ) );
            return options;
        }

        /// <summary>
        /// 配置Minio文件存储操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">Minio配置操作</param>
        public static Options UseMinio( this Options options, Action<MinioOptions> setupAction ) {
            options.AddExtension( new MinioOptionsExtension( setupAction ) );
            return options;
        }
    }
}
