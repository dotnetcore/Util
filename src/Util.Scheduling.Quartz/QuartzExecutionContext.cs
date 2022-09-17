using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Util.Scheduling {
    /// <summary>
    /// Quartz执行上下文
    /// </summary>
    public class QuartzExecutionContext {
        /// <summary>
        /// 初始化Quartz执行上下文
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="context">执行上下文</param>
        public QuartzExecutionContext( IServiceProvider serviceProvider, IJobExecutionContext context ) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException( nameof( serviceProvider ) );
            Context = context ?? throw new ArgumentNullException( nameof( context ) );
        }

        /// <summary>
        /// 服务提供器
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 执行上下文
        /// </summary>
        public IJobExecutionContext Context { get; }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T">服务类型</typeparam>
        public T GetService<T>() {
            return ServiceProvider.GetService<T>();
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        public T GetData<T>() {
            var json = Context.JobDetail.JobDataMap.GetString( JobBase.DataKey );
            return Util.Helpers.Json.ToObject<T>( json );
        }
    }
}
