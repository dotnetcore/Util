using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using Util.Configs;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire操作配置扩展
    /// </summary>
    public class HangfireOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// Hangfire配置操作
        /// </summary>
        private readonly Action<IGlobalConfiguration> _setupAction;
        /// <summary>
        /// Hangfire服务器配置操作
        /// </summary>
        private readonly Action<BackgroundJobServerOptions> _serverSetupAction;
        /// <summary>
        /// 是否扫描加载后台任务
        /// </summary>
        private readonly bool _isScanJobs;

        /// <summary>
        /// 初始化Hangfire操作配置扩展
        /// </summary>
        /// <param name="setupAction">Hangfire配置操作</param>
        /// <param name="serverSetupAction">是否扫描加载后台任务</param>
        /// <param name="isScanJobs">是否扫描加载后台任务</param>
        public HangfireOptionsExtension( Action<IGlobalConfiguration> setupAction, Action<BackgroundJobServerOptions> serverSetupAction, bool isScanJobs ) {
            _setupAction = setupAction;
            _serverSetupAction = serverSetupAction;
            _isScanJobs = isScanJobs;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            AddHangfire( services );
            AddSchedulerBuilder( services );
            AddSchedulerOptions( services );
            AddHostedService( services );
        }

        /// <summary>
        /// 添加Hangfire服务
        /// </summary>
        private void AddHangfire( IServiceCollection services ) {
            services.AddHangfire( _setupAction );
            if( _serverSetupAction != null )
                services.Configure( _serverSetupAction );
        }

        /// <summary>
        /// 添加后台任务调度器服务
        /// </summary>
        private void AddSchedulerBuilder( IServiceCollection services ) {
            services.TryAddSingleton<ISchedulerManager, HangfireSchedulerManager>();
        }

        /// <summary>
        /// 添加后台任务调度器配置
        /// </summary>
        private void AddSchedulerOptions( IServiceCollection services ) {
            void Action( SchedulerOptions t ) => t.IsScanJobs = _isScanJobs;
            services.Configure( (Action<SchedulerOptions>)Action );
        }

        /// <summary>
        /// 添加启动服务
        /// </summary>
        private void AddHostedService( IServiceCollection services ) {
            services.AddHostedService<HostService>();
        }
    }
}
