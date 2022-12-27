using Hangfire;
using System;
using Util.Configs;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire后台任务操作扩展
    /// </summary>
    public static class OptionsExtensions {
        /// <summary>
        /// 配置Hangfire后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        public static Options UseHangfire( this Options options, Action<IGlobalConfiguration> setupAction ) {
            return options.UseHangfire( setupAction, true );
        }

        /// <summary>
        /// 配置Hangfire后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        /// <param name="serverSetupAction">服务器配置操作</param>
        public static Options UseHangfire( this Options options, Action<IGlobalConfiguration> setupAction, Action<BackgroundJobServerOptions> serverSetupAction ) {
            return options.UseHangfire( setupAction, serverSetupAction, true );
        }

        /// <summary>
        /// 配置Hangfire后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        /// <param name="isScanJobs">是否扫描加载后台任务</param>
        public static Options UseHangfire( this Options options, Action<IGlobalConfiguration> setupAction, bool isScanJobs ) {
            return options.UseHangfire( setupAction, null, isScanJobs );
        }

        /// <summary>
        /// 配置Hangfire后台任务操作
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="setupAction">配置操作</param>
        /// <param name="serverSetupAction">服务器配置操作</param>
        /// <param name="isScanJobs">是否扫描加载后台任务</param>
        public static Options UseHangfire( this Options options, Action<IGlobalConfiguration> setupAction, Action<BackgroundJobServerOptions> serverSetupAction,bool isScanJobs ) {
            options.AddExtension( new HangfireOptionsExtension( setupAction, serverSetupAction, isScanJobs ) );
            return options;
        }
    }
}
