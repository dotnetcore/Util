namespace Util.Domain.Events; 

/// <summary>
/// 领域事件服务
/// </summary>
public interface IDomainEventManager {
    /// <summary>
    /// 领域事件集合
    /// </summary>
    IReadOnlyCollection<IEvent> DomainEvents { get; }
    /// <summary>
    /// 添加领域事件
    /// </summary>
    /// <param name="event">领域事件</param>
    void AddDomainEvent( IEvent @event );
    /// <summary>
    /// 移除领域事件
    /// </summary>
    /// <param name="event">领域事件</param>
    void RemoveDomainEvent( IEvent @event );
    /// <summary>
    /// 清空领域事件
    /// </summary>
    void ClearDomainEvents();
}