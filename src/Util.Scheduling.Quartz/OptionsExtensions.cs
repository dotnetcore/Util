using Quartz;
using System;
using Util.Configs;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz后台任务操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置Quartz后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="isScanJobs">是否扫描加载后台任务</param>
        public static Options UseQuartz( this Options options,bool isScanJobs = true ) {
            return UseQuartz( options, null, isScanJobs );
        }

        /// <summary>
        /// 配置Quartz后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseQuartz( this Options options, Action<IServiceCollectionQuartzConfigurator> setupAction ) {
            return UseQuartz( options, setupAction,true );
        }

        /// <summary>
        /// 配置Quartz后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        /// <param name="isScanJobs">是否扫描加载后台任务</param>
        public static Options UseQuartz( this Options options, Action<IServiceCollectionQuartzConfigurator> setupAction, bool isScanJobs ) {
            options.AddExtension( new QuartzOptionsExtension( setupAction, isScanJobs ) );
            return options;
        }
    }
}
