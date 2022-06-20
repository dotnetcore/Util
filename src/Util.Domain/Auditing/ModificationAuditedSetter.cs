using System;
using Util.Helpers;

namespace Util.Domain.Auditing {
    /// <summary>
    /// 修改操作审计设置器
    /// </summary>
    public class ModificationAuditedSetter {
        /// <summary>
        /// 实体
        /// </summary>
        private readonly object _entity;
        /// <summary>
        /// 用户标识
        /// </summary>
        private readonly string _userId;

        /// <summary>
        /// 初始化修改操作审计设置器
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userId">用户标识</param>
        private ModificationAuditedSetter( object entity, string userId ) {
            _entity = entity;
            _userId = userId;
        }

        /// <summary>
        /// 设置修改审计属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userId">用户标识</param>
        public static void Set( object entity, string userId ) {
            new ModificationAuditedSetter( entity, userId ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            if ( _entity == null )
                return;
            if( _entity is IModificationAudited<Guid> entity ) {
                entity.LastModificationTime = Time.Now;
                entity.LastModifierId = _userId.ToGuid();
                return;
            }
            if ( _entity is IModificationAudited<Guid?> entity2 ) {
                entity2.LastModificationTime = Time.Now;
                entity2.LastModifierId = _userId.ToGuidOrNull();
                return;
            }
            if ( _entity is IModificationAudited<int> entity3 ) {
                entity3.LastModificationTime = Time.Now;
                entity3.LastModifierId = _userId.ToInt();
                return;
            }
            if ( _entity is IModificationAudited<int?> entity4 ) {
                entity4.LastModificationTime = Time.Now;
                entity4.LastModifierId = _userId.ToIntOrNull();
                return;
            }
            if ( _entity is IModificationAudited<string> entity5 ) {
                entity5.LastModificationTime = Time.Now;
                entity5.LastModifierId = _userId.SafeString();
                return;
            }
            if ( _entity is IModificationAudited<long> entity6 ) {
                entity6.LastModificationTime = Time.Now;
                entity6.LastModifierId = _userId.ToLong();
                return;
            }
            if ( _entity is IModificationAudited<long?> entity7 ) {
                entity7.LastModificationTime = Time.Now;
                entity7.LastModifierId = _userId.ToLongOrNull();
                return;
            }
        }
    }
}
