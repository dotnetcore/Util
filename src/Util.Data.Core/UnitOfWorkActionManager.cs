using Util.Dependency;

namespace Util.Data;

/// <summary>
/// 工作单元操作管理器
/// </summary>
[Ioc( 1 )]
public class UnitOfWorkActionManager : IUnitOfWorkActionManager {
    /// <summary>
    /// 操作列表
    /// </summary>
    private readonly List<Func<Task>> _actions;

    /// <summary>
    /// 初始化工作单元操作管理器
    /// </summary>
    public UnitOfWorkActionManager() {
        _actions = new List<Func<Task>>();
    }

    /// <inheritdoc />
    public void Register( Func<Task> action ) {
        if ( action == null )
            return;
        _actions.Add( action );
    }

    /// <inheritdoc />
    public async Task ExecuteAsync() {
        foreach ( var action in _actions )
            await action();
        _actions.Clear();
    }
}