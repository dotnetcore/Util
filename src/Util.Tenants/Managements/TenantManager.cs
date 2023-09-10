namespace Util.Tenants.Managements;

/// <summary>
/// 租户管理器
/// </summary>
public class TenantManager : ITenantManager {
    /// <summary>
    /// 当前租户标识
    /// </summary>
    private static readonly AsyncLocal<string> _currentTenantId;

    /// <summary>
    /// 初始化租户管理器
    /// </summary>
    static TenantManager() {
        _currentTenantId = new AsyncLocal<string>();
    }

    /// <summary>
    /// 初始化租户管理器
    /// </summary>
    /// <param name="tenantStore">租户存储器</param>
    /// <param name="viewAllTenantManager">查看租户管理器</param>
    /// <param name="switchTenantManager">切换租户管理器</param>
    /// <param name="session">用户会话</param>
    /// <param name="options">租户配置</param>
    public TenantManager( ITenantStore tenantStore, IViewAllTenantManager viewAllTenantManager, ISwitchTenantManager switchTenantManager,
        Sessions.ISession session, IOptions<TenantOptions> options ) {
        TenantStore = tenantStore ?? throw new ArgumentNullException( nameof( tenantStore ) );
        ViewAllTenantManager = viewAllTenantManager ?? throw new ArgumentNullException( nameof( viewAllTenantManager ) );
        SwitchTenantManager = switchTenantManager ?? throw new ArgumentNullException( nameof( switchTenantManager ) );
        Session = session ?? throw new ArgumentNullException( nameof( session ) );
        Options = options?.Value ?? TenantOptions.Null;
    }

    /// <summary>
    /// 租户存储器
    /// </summary>
    protected ITenantStore TenantStore { get; }
    /// <summary>
    /// 查看租户管理器
    /// </summary>
    protected IViewAllTenantManager ViewAllTenantManager { get; }
    /// <summary>
    /// 切换租户管理器
    /// </summary>
    protected ISwitchTenantManager SwitchTenantManager { get; }
    /// <summary>
    /// 用户会话
    /// </summary>
    protected Sessions.ISession Session { get; }
    /// <summary>
    /// 租户配置
    /// </summary>
    protected TenantOptions Options { get; }

    /// <summary>
    /// 当前租户标识
    /// </summary>
    public static string CurrentTenantId {
        get => _currentTenantId.Value;
        set => _currentTenantId.Value = value;
    }

    /// <inheritdoc />
    public virtual bool Enabled() {
        return Options.IsEnabled;
    }

    /// <inheritdoc />
    public virtual bool AllowMultipleDatabase() {
        return Options.IsAllowMultipleDatabase;
    }

    /// <inheritdoc />
    public virtual bool IsHost() {
        if ( Session.IsAuthenticated == false )
            return false;
        if ( Session.UserId.IsEmpty() )
            return false;
        if ( Session.TenantId != CurrentTenantId )
            return false;
        return Session.TenantId == Options.DefaultTenantId;
    }

    /// <inheritdoc />
    public virtual string GetTenantId() {
        if ( IsHost() == false )
            return CurrentTenantId;
        var switchTenantId = SwitchTenantManager.GetSwitchTenantId();
        return switchTenantId.IsEmpty() ? CurrentTenantId : switchTenantId;
    }

    /// <inheritdoc />
    public virtual TenantInfo GetTenant() {
        return TenantStore.GetTenant( GetTenantId() );
    }

    /// <inheritdoc />
    public virtual bool IsDisableTenantFilter() {
        if ( IsHost() == false )
            return false;
        return ViewAllTenantManager.IsDisableTenantFilter();
    }
}