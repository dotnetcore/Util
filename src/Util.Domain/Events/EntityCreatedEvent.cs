using Util.Events;

namespace Util.Domain.Events {
    /// <summary>
    /// 实体创建事件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class EntityCreatedEvent<TEntity> : IEvent{
        /// <summary>
        /// 初始化实体创建事件
        /// </summary>
        /// <param name="entity">实体</param>
        public EntityCreatedEvent( TEntity entity ) {
            Entity = entity;
        }

        /// <summary>
        /// 实体
        /// </summary>
        public TEntity Entity { get; }
    }
}
