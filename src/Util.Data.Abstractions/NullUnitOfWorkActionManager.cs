namespace Util.Data;

/// <summary>
/// 空工作单元操作管理器
/// </summary>
public class NullUnitOfWorkActionManager : IUnitOfWorkActionManager {
    /// <summary>
    /// 初始化空工作单元操作管理器
    /// </summary>
    public NullUnitOfWorkActionManager() {
    }

    /// <summary>
    /// 空工作单元操作管理器实例
    /// </summary>
    public static readonly IUnitOfWorkActionManager Instance = new NullUnitOfWorkActionManager();

    /// <inheritdoc />
    public void Register( Func<Task> action ) {
    }

    /// <inheritdoc />
    public Task ExecuteAsync() {
        return Task.CompletedTask;
    }
}