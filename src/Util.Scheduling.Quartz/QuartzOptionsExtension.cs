using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Quartz;
using System;
using Util.Configs;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz操作配置扩展
    /// </summary>
    public class QuartzOptionsExtension : OptionsExtensionBase {
        /// <summary>
        /// Quartz配置操作
        /// </summary>
        private readonly Action<IServiceCollectionQuartzConfigurator> _action;
        /// <summary>
        /// 是否扫描加载后台任务
        /// </summary>
        private readonly bool _isScanJobs;

        /// <summary>
        /// 初始化Quartz操作配置扩展
        /// </summary>
        /// <param name="action">Quartz配置操作</param>
        /// <param name="isScanJobs">是否扫描加载后台任务</param>
        public QuartzOptionsExtension( Action<IServiceCollectionQuartzConfigurator> action, bool isScanJobs ) {
            _action = action;
            _isScanJobs = isScanJobs;
        }

        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            AddQuartz( services );
            AddSchedulerBuilder( services );
            AddSchedulerOptions( services );
            AddHostedService( services );
        }

        /// <summary>
        /// 添加Quartz服务
        /// </summary>
        private void AddQuartz( IServiceCollection services ) {
            if ( _action == null ) {
                services.AddQuartz( options => {
                    options.UseMicrosoftDependencyInjectionJobFactory();
                } );
                return;
            }
            services.AddQuartz( options => {
                options.UseMicrosoftDependencyInjectionJobFactory();
                _action( options );
            } );
        }

        /// <summary>
        /// 添加后台任务调度器服务
        /// </summary>
        private void AddSchedulerBuilder( IServiceCollection services ) {
            services.TryAddSingleton<ISchedulerManager, QuartzSchedulerManager>();
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
