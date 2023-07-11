using System.Threading;
using System.Threading.Tasks;
using Util.Data;
using Util.Dependency;
using Util.Events;

namespace Util.Tests.Events; 

/// <summary>
/// 测试事件总线
/// </summary>
public interface ITestEventBus : IEventBus, ITransientDependency {
}

/// <summary>
/// 测试事件总线,用于测试工作单元操作管理器
/// </summary>
public class TestEventBus : ITestEventBus {
    private readonly IUnitOfWorkActionManager _manager;
    private readonly ILocalEventBus _eventBus;
    public TestEventBus( IUnitOfWorkActionManager unitOfWorkActionManager, ILocalEventBus eventBus ) {
        _manager = unitOfWorkActionManager;
        _eventBus = eventBus;
    }
    public Task PublishAsync<TEvent>( TEvent @event, CancellationToken cancellationToken = default ) where TEvent : IEvent {
        _manager.Register( async () => await _eventBus.PublishAsync( @event, cancellationToken ) );
        return Task.CompletedTask;
    }
}