using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Util.Helpers;
using Util.Reflections;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz调度管理器
    /// </summary>
    public abstract class SchedulerManagerBase : ISchedulerManager {
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly ITypeFinder _typeFinder;

        /// <summary>
        /// 初始化Quartz调度管理器
        /// </summary>
        /// <param name="scopeFactory">服务范围工厂</param>
        /// <param name="typeFinder">类型查找器</param>
        protected SchedulerManagerBase( IServiceScopeFactory scopeFactory, ITypeFinder typeFinder ) {
            Ioc.ServiceScopeFactory = scopeFactory ?? throw new ArgumentNullException( nameof( scopeFactory ) );
            _typeFinder = typeFinder ?? throw new ArgumentNullException( nameof( typeFinder ) );
        }

        /// <inheritdoc />
        public virtual async Task<string> AddJobAsync<TJob>() where TJob : IJob, new() {
            return await AddJobAsync( new TJob() );
        }

        /// <inheritdoc />
        public abstract Task<string> AddJobAsync( IJob job );

        /// <inheritdoc />
        public virtual async Task ScanJobsAsync( bool isScanAllJobs = true ) {
            var types = _typeFinder.Find<IScan>() ?? new List<Type>();
            if ( isScanAllJobs ) {
                types.AddRange( _typeFinder.Find<IJob>() );
                types = types.DistinctBy( t => t.FullName ).ToList();
            }
            foreach ( var type in types ) {
                var job = Reflection.CreateInstance<IJob>( type );
                if ( job == null )
                    continue;
                await AddJobAsync( job );
            }
        }

        /// <inheritdoc />
        public abstract Task<IScheduler> GetSchedulerAsync();
    }
}
