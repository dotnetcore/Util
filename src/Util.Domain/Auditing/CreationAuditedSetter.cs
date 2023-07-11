using Util.Helpers;

namespace Util.Domain.Auditing;

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
        InitCreationTime();
        if ( _userId.IsEmpty() )
            return;
        if ( _entity is ICreationAudited<Guid> entity ) {
            if ( IsEmpty( entity.CreatorId ) )
                entity.CreatorId = _userId.ToGuid();
            return;
        }
        if ( _entity is ICreationAudited<Guid?> entity2 ) {
            if ( IsEmpty( entity2.CreatorId ) )
                entity2.CreatorId = _userId.ToGuidOrNull();
            return;
        }
        if ( _entity is ICreationAudited<int> entity3 ) {
            if ( IsEmpty( entity3.CreatorId ) )
                entity3.CreatorId = _userId.ToInt();
            return;
        }
        if ( _entity is ICreationAudited<int?> entity4 ) {
            if ( IsEmpty( entity4.CreatorId ) )
                entity4.CreatorId = _userId.ToIntOrNull();
            return;
        }
        if ( _entity is ICreationAudited<string> entity5 ) {
            if ( IsEmpty( entity5.CreatorId ) )
                entity5.CreatorId = _userId.SafeString();
            return;
        }
        if ( _entity is ICreationAudited<long> entity6 ) {
            if ( IsEmpty( entity6.CreatorId ) )
                entity6.CreatorId = _userId.ToLong();
            return;
        }
        if ( _entity is ICreationAudited<long?> entity7 ) {
            if ( IsEmpty( entity7.CreatorId ) )
                entity7.CreatorId = _userId.ToLongOrNull();
            return;
        }
    }

    /// <summary>
    /// 初始化创建时间
    /// </summary>
    private void InitCreationTime() {
        if ( _entity is ICreationTime entity ) 
            entity.CreationTime ??= Time.Now;
    }

    /// <summary>
    /// 创建时间是否为空
    /// </summary>
    private bool IsEmpty<T>( T creatorId ) {
        if ( creatorId == null )
            return true;
        if ( creatorId.Equals( default(T) ) )
            return true;
        return false;
    }
}