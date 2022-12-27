using System;
using Microsoft.Extensions.DependencyInjection;

namespace Util.Scheduling {
    /// <summary>
    /// Hangfire执行上下文
    /// </summary>
    public class HangfireExecutionContext {
        /// <summary>
        /// 参数
        /// </summary>
        private readonly object _data;

        /// <summary>
        /// 初始化Hangfire执行上下文
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="data">服务提供器</param>
        public HangfireExecutionContext( IServiceProvider serviceProvider,object data ) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException( nameof( serviceProvider ) );
            _data = data;
        }

        /// <summary>
        /// 服务提供器
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

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
            return Util.Helpers.Convert.To<T>( _data );
        }
    }
}
