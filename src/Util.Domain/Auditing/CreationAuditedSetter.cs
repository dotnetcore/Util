using System;
using Util.Helpers;

namespace Util.Domain.Auditing {
    /// <summary>
    /// 创建操作审计设置器
    /// </summary>
    public class CreationAuditedSetter {
        /// <summary>
        /// 实体
        /// </summary>
        private readonly object _entity;
        /// <summary>
        /// 用户标识
        /// </summary>
        private readonly string _userId;

        /// <summary>
        /// 初始化创建操作审计设置器
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userId">用户标识</param>
        private CreationAuditedSetter( object entity, string userId ) {
            _entity = entity;
            _userId = userId;
        }

        /// <summary>
        /// 设置创建审计属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userId">用户标识</param>
        public static void Set( object entity, string userId ) {
            new CreationAuditedSetter( entity, userId ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            if ( _entity == null )
                return;
            if( _entity is ICreationAudited<Guid> entity ) {
                entity.CreationTime = Time.Now;
                entity.CreatorId = _userId.ToGuid();
                return;
            }
            if( _entity is ICreationAudited<Guid?> entity2 ) {
                entity2.CreationTime = Time.Now;
                entity2.CreatorId = _userId.ToGuidOrNull();
                return;
            }
            if( _entity is ICreationAudited<int> entity3 ) {
                entity3.CreationTime = Time.Now;
                entity3.CreatorId = _userId.ToInt();
                return;
            }
            if( _entity is ICreationAudited<int?> entity4 ) {
                entity4.CreationTime = Time.Now;
                entity4.CreatorId = _userId.ToIntOrNull();
                return;
            }
            if( _entity is ICreationAudited<string> entity5 ) {
                entity5.CreationTime = Time.Now;
                entity5.CreatorId = _userId.SafeString();
                return;
            }
            if( _entity is ICreationAudited<long> entity6 ) {
                entity6.CreationTime = Time.Now;
                entity6.CreatorId = _userId.ToLong();
                return;
            }
            if( _entity is ICreationAudited<long?> entity7 ) {
                entity7.CreationTime = Time.Now;
                entity7.CreatorId = _userId.ToLongOrNull();
                return;
            }
        }
    }
}
