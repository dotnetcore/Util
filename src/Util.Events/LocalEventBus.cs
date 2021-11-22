using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util.Events {
    /// <summary>
    /// 基于内存的本地事件总线
    /// </summary>
    public class LocalEventBus : ILocalEventBus {
        /// <summary>
        /// 服务提供器
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 初始化本地事件总线
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        public LocalEventBus( IServiceProvider serviceProvider ) {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException( nameof( serviceProvider ) );
        }

        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <param name="event">事件</param>
        public async Task PublishAsync<TEvent>( TEvent @event ) where TEvent : IEvent {
            if( @event == null )
                return;
            var eventType = @event.GetType();
            var handlers = GetEventHandlers( eventType );
            if( handlers == null )
                return;
            foreach( var handler in handlers.Where( t => t.Enabled ).OrderBy( t => t.Order ) ) {
                var method = typeof( IEventHandler<> ).MakeGenericType( eventType ).GetMethod( "HandleAsync", new[] { eventType } );
                if( method == null )
                    return;
                var result = method.Invoke( handler, new object[] { @event } );
                if( result == null )
                    return;
                await (Task)result;
            }
        }

        /// <summary>
        /// 获取事件处理器列表
        /// </summary>
        private IEnumerable<IEventHandler> GetEventHandlers( Type eventType ) {
            var handlerType = typeof( IEventHandler<> ).MakeGenericType( eventType );
            var serviceType = typeof( IEnumerable<> ).MakeGenericType( handlerType );
            var handlers = _serviceProvider.GetService( serviceType );
            return handlers as IEnumerable<IEventHandler>;
        }
    }
}
