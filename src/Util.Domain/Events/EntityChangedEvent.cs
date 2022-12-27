using Util.Events;

namespace Util.Domain.Events {
    /// <summary>
    /// 实体变更事件,当实体新增,修改,删除时均触发
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class EntityChangedEvent<TEntity> : IEvent {
        /// <summary>
        /// 初始化实体变更事件
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="changeType">变更类型</param>
        public EntityChangedEvent( TEntity entity, EntityChangeType changeType ) {
            Entity = entity;
            ChangeType = changeType;
        }

        /// <summary>
        /// 实体
        /// </summary>
        public TEntity Entity { get; }

        /// <summary>
        /// 变更类型
        /// </summary>
        public EntityChangeType ChangeType { get; }
    }
}
