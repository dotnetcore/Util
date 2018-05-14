using System;
using Util.Sessions;

namespace Util.Domains.Auditing {
    /// <summary>
    /// 修改操作审计初始化器
    /// </summary>
    public class ModificationAuditedInitializer {
        /// <summary>
        /// 初始化修改操作审计初始化器
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="session">用户上下文</param>
        private ModificationAuditedInitializer( object entity, ISession session ) {
            _entity = entity;
            _session = session;
        }

        /// <summary>
        /// 实体
        /// </summary>
        private readonly object _entity;
        /// <summary>
        /// 用户会话
        /// </summary>
        private readonly ISession _session;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="session">用户上下文</param>
        public static void Init( object entity, ISession session ) {
            new ModificationAuditedInitializer( entity, session ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            if( _entity is IModificationAudited<Guid>) {
                InitGuid();
                return;
            }
            if ( _entity is IModificationAudited<Guid?> ) {
                InitNullableGuid();
                return;
            }
            if ( _entity is IModificationAudited<int> ) {
                InitInt();
                return;
            }
            if ( _entity is IModificationAudited<int?> ) {
                InitNullableInt();
                return;
            }
            if ( _entity is IModificationAudited<string> ) {
                InitString();
                return;
            }
            if ( _entity is IModificationAudited<long> ) {
                InitLong();
                return;
            }
            if ( _entity is IModificationAudited<long?> ) {
                InitNullableLong();
                return;
            }
        }

        /// <summary>
        /// 初始化Guid
        /// </summary>
        private void InitGuid() {
            var result = (IModificationAudited<Guid>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.ToGuid();
        }

        /// <summary>
        /// 初始化可空Guid
        /// </summary>
        private void InitNullableGuid() {
            var result = (IModificationAudited<Guid?>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.ToGuidOrNull();
        }

        /// <summary>
        /// 初始化int
        /// </summary>
        private void InitInt() {
            var result = (IModificationAudited<int>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.ToInt();
        }

        /// <summary>
        /// 初始化可空int
        /// </summary>
        private void InitNullableInt() {
            var result = (IModificationAudited<int?>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.ToIntOrNull();
        }

        /// <summary>
        /// 初始化字符串
        /// </summary>
        private void InitString() {
            var result = (IModificationAudited<string>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.SafeString();
        }

        /// <summary>
        /// 初始化Long
        /// </summary>
        private void InitLong() {
            var result = (IModificationAudited<long>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.ToLong();
        }

        /// <summary>
        /// 初始化可空Long
        /// </summary>
        private void InitNullableLong() {
            var result = (IModificationAudited<long?>)_entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierId = _session.UserId.ToLongOrNull();
        }
    }
}
