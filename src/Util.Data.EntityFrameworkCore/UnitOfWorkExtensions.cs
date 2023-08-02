namespace Util.Data.EntityFrameworkCore; 

/// <summary>
/// 工作单元扩展
/// </summary>
public static class UnitOfWorkExtensions {
    /// <summary>
    /// 获取已应用的迁移列表
    /// </summary>
    /// <param name="source">工作单元</param>
    public static async Task<List<string>> GetAppliedMigrationsAsync( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if ( source is not DbContext unitOfWork )
            return new List<string>();
        var result = await unitOfWork.Database.GetAppliedMigrationsAsync();
        return result.ToList();
    }

    /// <summary>
    /// 应用迁移
    /// </summary>
    /// <param name="source">工作单元</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task MigrateAsync( this IUnitOfWork source, CancellationToken cancellationToken = default ) {
        source.CheckNull( nameof( source ) );
        if ( source is not DbContext unitOfWork )
            return;
        await unitOfWork.Database.MigrateAsync( cancellationToken );
    }

    /// <summary>
    /// 创建数据库架构
    /// </summary>
    /// <param name="source">工作单元</param>
    public static bool EnsureCreated( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if( source is not DbContext unitOfWork )
            return false;
        return unitOfWork.Database.EnsureCreated();
    }

    /// <summary>
    /// 创建数据库架构
    /// </summary>
    /// <param name="source">工作单元</param>
    public static async Task<bool> EnsureCreatedAsync( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if( source is not DbContext unitOfWork )
            return false;
        return await unitOfWork.Database.EnsureCreatedAsync();
    }

    /// <summary>
    /// 删除数据库架构
    /// </summary>
    /// <param name="source">工作单元</param>
    public static bool EnsureDeleted( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if( source is not DbContext unitOfWork )
            return false;
        return unitOfWork.Database.EnsureDeleted();
    }

    /// <summary>
    /// 删除数据库架构
    /// </summary>
    /// <param name="source">工作单元</param>
    public static async Task<bool> EnsureDeletedAsync( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if( source is not DbContext unitOfWork )
            return false;
        return await unitOfWork.Database.EnsureDeletedAsync();
    }

    /// <summary>
    /// 清空缓存
    /// </summary>
    /// <param name="source">工作单元</param>
    public static void ClearCache( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if ( source is not DbContext unitOfWork )
            return;
        unitOfWork.ChangeTracker.Clear();
    }

    /// <summary>
    /// 获取更改跟踪调试视图
    /// </summary>
    /// <param name="source">工作单元</param>
    public static string GetChangeTrackerDebugView( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if( source is not DbContext unitOfWork )
            return null;
        unitOfWork.ChangeTracker.DetectChanges();
        return unitOfWork.ChangeTracker.DebugView.LongView;
    }

    /// <summary>
    /// 是否更改
    /// </summary>
    /// <param name="source">工作单元</param>
    public static bool IsChange( this IUnitOfWork source ) {
        source.CheckNull( nameof( source ) );
        if ( source is not DbContext unitOfWork )
            return false;
        return unitOfWork.ChangeTracker.Entries().Any( t => t.State == EntityState.Modified );
    }

    /// <summary>
    /// 是否可连接
    /// </summary>
    /// <param name="source">工作单元</param>
    /// <param name="cancellationToken">取消令牌</param>
    public static async Task<bool> CanConnectAsync( this IUnitOfWork source, CancellationToken cancellationToken = default ) {
        source.CheckNull( nameof( source ) );
        if ( source is not DbContext unitOfWork )
            return false;
        return await unitOfWork.Database.CanConnectAsync( cancellationToken );
    }
}