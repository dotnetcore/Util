using Util.Domain.Events;

namespace Util.Domain.Entities; 

/// <summary>
/// 聚合根
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
public abstract class AggregateRoot<TEntity> : AggregateRoot<TEntity, Guid> where TEntity : IAggregateRoot<TEntity, Guid> {
    /// <summary>
    /// 初始化聚合根
    /// </summary>
    /// <param name="id">标识</param>
    protected AggregateRoot( Guid id ) : base( id ) {
    }
}

/// <summary>
/// 聚合根
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
/// <typeparam name="TKey">标识类型</typeparam>
public abstract class AggregateRoot<TEntity, TKey> : EntityBase<TEntity, TKey>, IAggregateRoot<TEntity, TKey>, IDomainEventManager where TEntity : IAggregateRoot<TEntity, TKey> {
    /// <summary>
    /// 领域事件列表
    /// </summary>
    private List<IEvent> _domainEvents;

    /// <summary>
    /// 初始化聚合根
    /// </summary>
    /// <param name="id">标识</param>
    protected AggregateRoot( TKey id ) : base( id ) {
    }

    /// <summary>
    /// 版本号
    /// </summary>
    public byte[] Version { get; set; }

    /// <inheritdoc />
    [NotMapped]
    public IReadOnlyCollection<IEvent> DomainEvents => _domainEvents?.AsReadOnly();

    /// <inheritdoc />
    public void AddDomainEvent( IEvent @event ) {
        if ( @event == null )
            return;
        _domainEvents ??= new List<IEvent>();
        _domainEvents.Add( @event );
    }

    /// <inheritdoc />
    public void RemoveDomainEvent( IEvent @event ) {
        if ( @event == null )
            return;
        _domainEvents?.Remove( @event );
    }

    /// <inheritdoc />
    public void ClearDomainEvents() {
        _domainEvents?.Clear();
    }
}