using Util.Tenants.Managements;
using Util.Tenants.Tests.Samples;
using ISession = Util.Sessions.ISession;

namespace Util.Tenants.Tests.Managements;

/// <summary>
/// 租户管理器测试
/// </summary>
public class TenantManagerTest {

    #region 测试初始化

    /// <summary>
    /// 模拟租户存储器
    /// </summary>
    private readonly Mock<ITenantStore> _mockStore;
    /// <summary>
    /// 模拟查看租户管理器
    /// </summary>
    private readonly Mock<IViewAllTenantManager> _mockView;
    /// <summary>
    /// 模拟切换租户管理器
    /// </summary>
    private readonly Mock<ISwitchTenantManager> _mockSwitch;
    /// <summary>
    /// 模拟配置
    /// </summary>
    private readonly Mock<IOptions<TenantOptions>> _mockOptions;
    /// <summary>
    /// 租户管理器
    /// </summary>
    private TenantManager _tenantManager;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public TenantManagerTest() {
        _mockStore = new Mock<ITenantStore>();
        _mockView = new Mock<IViewAllTenantManager>();
        _mockSwitch = new Mock<ISwitchTenantManager>();
        _mockOptions = new Mock<IOptions<TenantOptions>>();
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { IsEnabled = true } );
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, GetTestSession(), _mockOptions.Object );
    }

    /// <summary>
    /// 获取测试用户会话
    /// </summary>
    private ISession GetTestSession() {
        return new TestSession( false, null, null );
    }

    #endregion

    #region IsHost

    /// <summary>
    /// 测试是否平台供应商
    /// </summary>
    [Fact]
    public void TestIsHost_1() {
        //设置
        var tenantId = "t";
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { DefaultTenantId = tenantId } );
        TenantManager.CurrentTenantId = tenantId;

        //执行
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //验证
        Assert.True( _tenantManager.IsHost() );
    }

    /// <summary>
    /// 测试是否平台供应商 - 未登录
    /// </summary>
    [Fact]
    public void TestIsHost_2() {
        //设置
        var tenantId = "t";
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { DefaultTenantId = tenantId } );
        TenantManager.CurrentTenantId = tenantId;

        //执行
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( false, "u", tenantId ), _mockOptions.Object );

        //验证
        Assert.False( _tenantManager.IsHost() );
    }

    /// <summary>
    /// 测试是否平台供应商 - 用户名为空
    /// </summary>
    [Fact]
    public void TestIsHost_3() {
        //设置
        var tenantId = "t";
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { DefaultTenantId = tenantId } );
        TenantManager.CurrentTenantId = tenantId;

        //执行
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "", tenantId ), _mockOptions.Object );

        //验证
        Assert.False( _tenantManager.IsHost() );
    }

    /// <summary>
    /// 测试是否平台供应商 - 用户会话中的租户标识与当前租户不同
    /// </summary>
    [Fact]
    public void TestIsHost_4() {
        //设置
        var tenantId = "t";
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { DefaultTenantId = tenantId } );
        TenantManager.CurrentTenantId = "t2";

        //执行
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //验证
        Assert.False( _tenantManager.IsHost() );
    }

    /// <summary>
    /// 测试是否平台供应商 - 当前租户标识与默认租户不同
    /// </summary>
    [Fact]
    public void TestIsHost_5() {
        //设置
        var tenantId = "t";
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { DefaultTenantId = "" } );
        TenantManager.CurrentTenantId = tenantId;

        //执行
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //验证
        Assert.False( _tenantManager.IsHost() );
    }

    #endregion

    #region GetTenantId

    /// <summary>
    /// 测试获取当前租户标识 - 普通租户,返回租户标识
    /// </summary>
    [Fact]
    public void TestGetTenantId_1() {
        //设置当前租户标识
        TenantManager.CurrentTenantId = "a";

        //执行
        var result = _tenantManager.GetTenantId();

        //验证
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// 测试获取当前租户标识 - 平台供应商,未切换租户,返回平台供应商租户标识
    /// </summary>
    [Fact]
    public void TestGetTenantId_2() {
        //变量定义
        var tenantId = "t";

        //设置当前租户标识
        TenantManager.CurrentTenantId = tenantId;

        //设置
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { IsEnabled = true, DefaultTenantId = tenantId } );

        //重新初始化
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //执行
        var result = _tenantManager.GetTenantId();

        //验证
        Assert.Equal( tenantId, result );
    }

    /// <summary>
    /// 测试获取当前租户标识 - 平台供应商,切换租户,返回切换的租户标识
    /// </summary>
    [Fact]
    public void TestGetTenantId_3() {
        //变量定义
        var tenantId = "t";

        //设置当前租户标识
        TenantManager.CurrentTenantId = tenantId;

        //设置
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { IsEnabled = true, DefaultTenantId = tenantId } );
        _mockSwitch.Setup( t => t.GetSwitchTenantId() ).Returns( "t2" );

        //重新初始化
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //执行
        var result = _tenantManager.GetTenantId();

        //验证
        Assert.Equal( "t2", result );
    }

    #endregion

    #region IsDisableTenantFilter

    /// <summary>
    /// 测试是否禁用租户过滤器 - 普通租户,不禁用
    /// </summary>
    [Fact]
    public void TestIsDisableTenantFilter_1() {
        //设置
        _mockView.Setup( t => t.IsDisableTenantFilter() ).Returns( true );

        //执行
        var result = _tenantManager.IsDisableTenantFilter();

        //验证
        Assert.False( result );
    }

    /// <summary>
    /// 测试是否禁用租户过滤器 - 平台供应商,查看租户管理器设置为true
    /// </summary>
    [Fact]
    public void TestIsDisableTenantFilter_2() {
        //变量定义
        var tenantId = "t";

        //设置当前租户标识
        TenantManager.CurrentTenantId = tenantId;

        //设置
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { IsEnabled = true, DefaultTenantId = tenantId } );
        _mockView.Setup( t => t.IsDisableTenantFilter() ).Returns( true );

        //重新初始化
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //执行
        var result = _tenantManager.IsDisableTenantFilter();

        //验证
        Assert.True( result );
    }

    /// <summary>
    /// 测试是否禁用租户过滤器 - 平台供应商,查看租户管理器设置为false
    /// </summary>
    [Fact]
    public void TestIsDisableTenantFilter_3() {
        //变量定义
        var tenantId = "t";

        //设置当前租户标识
        TenantManager.CurrentTenantId = tenantId;

        //设置
        _mockOptions.Setup( t => t.Value ).Returns( new TenantOptions { IsEnabled = true, DefaultTenantId = tenantId } );
        _mockView.Setup( t => t.IsDisableTenantFilter() ).Returns( false );

        //重新初始化
        _tenantManager = new TenantManager( _mockStore.Object, _mockView.Object, _mockSwitch.Object, new TestSession( true, "u", tenantId ), _mockOptions.Object );

        //执行
        var result = _tenantManager.IsDisableTenantFilter();

        //验证
        Assert.False( result );
    }

    #endregion
}