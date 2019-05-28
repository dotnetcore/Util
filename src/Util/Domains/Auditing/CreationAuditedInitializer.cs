using System;

namespace Util.Domains.Auditing {
    /// <summary>
    /// 创建操作审计初始化器
    /// </summary>
    public class CreationAuditedInitializer {
        /// <summary>
        /// 实体
        /// </summary>
        private readonly object _entity;
        /// <summary>
        /// 用户标识
        /// </summary>
        private readonly string _userId;
        /// <summary>
        /// 用户名称
        /// </summary>
        private readonly string _userName;

        /// <summary>
        /// 初始化创建操作审计初始化器
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userId">用户标识</param>
        /// <param name="userName">用户名称</param>
        private CreationAuditedInitializer( object entity, string userId, string userName ) {
            _entity = entity;
            _userId = userId;
            _userName = userName;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userId">用户标识</param>
        /// <param name="userName">用户名称</param>
        public static void Init( object entity, string userId, string userName ) {
            new CreationAuditedInitializer( entity, userId, userName ).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init() {
            if ( _entity == null )
                return;
            InitCreationTime();
            InitCreator();
            if ( string.IsNullOrWhiteSpace( _userId ) )
                return;
            if( _entity is ICreationAudited<Guid> ) {
                InitGuid();
                return;
            }
            if( _entity is ICreationAudited<Guid?> ) {
                InitNullableGuid();
                return;
            }
            if( _entity is ICreationAudited<int> ) {
                InitInt();
                return;
            }
            if( _entity is ICreationAudited<int?> ) {
                InitNullableInt();
                return;
            }
            if( _entity is ICreationAudited<string> ) {
                InitString();
                return;
            }
            if( _entity is ICreationAudited<long> ) {
                InitLong();
                return;
            }
            if( _entity is ICreationAudited<long?> ) {
                InitNullableLong();
                return;
            }
        }

        /// <summary>
        /// 初始化创建时间
        /// </summary>
        private void InitCreationTime() {
            if( _entity is ICreationTime result )
                result.CreationTime = DateTime.Now;
        }

        /// <summary>
        /// 初始化创建人
        /// </summary>
        private void InitCreator() {
            if ( string.IsNullOrWhiteSpace( _userName ) )
                return;
            if( _entity is ICreator result )
                result.Creator = _userName;
        }

        /// <summary>
        /// 初始化Guid
        /// </summary>
        private void InitGuid() {
            var result = (ICreationAudited<Guid>)_entity;
            result.CreatorId = _userId.ToGuid();
        }

        /// <summary>
        /// 初始化可空Guid
        /// </summary>
        private void InitNullableGuid() {
            var result = (ICreationAudited<Guid?>)_entity;
            result.CreatorId = _userId.ToGuidOrNull();
        }

        /// <summary>
        /// 初始化int
        /// </summary>
        private void InitInt() {
            var result = (ICreationAudited<int>)_entity;
            result.CreatorId = _userId.ToInt();
        }

        /// <summary>
        /// 初始化可空int
        /// </summary>
        private void InitNullableInt() {
            var result = (ICreationAudited<int?>)_entity;
            result.CreatorId = _userId.ToIntOrNull();
        }

        /// <summary>
        /// 初始化字符串
        /// </summary>
        private void InitString() {
            var result = (ICreationAudited<string>)_entity;
            result.CreatorId = _userId.SafeString();
        }

        /// <summary>
        /// 初始化Long
        /// </summary>
        private void InitLong() {
            var result = (ICreationAudited<long>)_entity;
            result.CreatorId = _userId.ToLong();
        }

        /// <summary>
        /// 初始化可空Long
        /// </summary>
        private void InitNullableLong() {
            var result = (ICreationAudited<long?>)_entity;
            result.CreatorId = _userId.ToLongOrNull();
        }
    }
}
