using Util.Domain.Compare;

namespace Util.Domain.Events; 

/// <summary>
/// 实体修改事件
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
public class EntityUpdatedEvent<TEntity> : IEvent {
    /// <summary>
    /// 初始化实体修改事件
    /// </summary>
    /// <param name="entity">实体</param>
    /// <param name="changeValues">变更值集合</param>
    public EntityUpdatedEvent( TEntity entity, ChangeValueCollection changeValues ) {
        Entity = entity;
        ChangeValues = changeValues;
    }

    /// <summary>
    /// 实体
    /// </summary>
    public TEntity Entity { get; }

    /// <summary>
    /// 变更值集合
    /// </summary>
    public ChangeValueCollection ChangeValues { get; }
}