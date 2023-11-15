namespace Util.Localization.Store.Tests;

/// <summary>
/// 数据存储本地化资源查找器测试
/// </summary>
public class StoreStringLocalizerTest {
    /// <summary>
    /// 模拟缓存
    /// </summary>
    private readonly Mock<IMemoryCache> _mockMemoryCache;
    /// <summary>
    /// 模拟本地化资源存储器
    /// </summary>
    private readonly Mock<ILocalizedStore> _mockLocalizedStore;
    /// <summary>
    /// 模拟本地化配置
    /// </summary>
    private Mock<IOptions<LocalizationOptions>> _mockOptions;
    /// <summary>
    /// 本地化资源查找器
    /// </summary>
    private IStringLocalizer _localizer;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public StoreStringLocalizerTest() {
        _mockOptions = new Mock<IOptions<LocalizationOptions>>();
        _mockMemoryCache = new Mock<IMemoryCache>();
        var mockCacheEntry = new Mock<ICacheEntry>();
        _mockMemoryCache.Setup( t => t.CreateEntry( It.IsAny<object>() ) ).Returns( mockCacheEntry.Object );
        _mockLocalizedStore = new Mock<ILocalizedStore>();
        _localizer = new StoreStringLocalizer( NullLogger.Instance, _mockMemoryCache.Object, _mockLocalizedStore.Object, null, _mockOptions.Object );
        CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
    }

    /// <summary>
    /// 测试获取本地化值 - 未找到本地化值,返回key
    /// </summary>
    [Fact]
    public void Test_1() {
        var result = _localizer["value"];
        Assert.Equal( "value", result );
    }

    /// <summary>
    /// 测试获取本地化值 - 未找到本地化值,返回key - 带参数
    /// </summary>
    [Fact]
    public void Test_2() {
        var result = _localizer["value_{0}", "a"];
        Assert.Equal( "value_a", result );
    }

    /// <summary>
    /// 测试获取本地化值 - 从存储器获取值
    /// </summary>
    [Fact]
    public void Test_3() {
        //设置存储器获取资源
        _mockLocalizedStore.Setup( t => t.GetValue( "zh-CN", null, "name" ) ).Returns( "value" );

        //执行
        var result = _localizer["name"];

        //验证
        Assert.Equal( "value", result );
    }

    /// <summary>
    /// 测试获取本地化值 - 从存储器获取值 - 带参数
    /// </summary>
    [Fact]
    public void Test_4() {
        //设置存储器获取资源
        _mockLocalizedStore.Setup( t => t.GetValue( "zh-CN", null, "name_{0}" ) ).Returns( "value_{0}" );

        //执行
        var result = _localizer["name_{0}", "a"];

        //验证
        Assert.Equal( "value_a", result );
    }

    /// <summary>
    /// 测试获取本地化值 - 从存储器获取值 - 设置资源类型
    /// </summary>
    [Fact]
    public void Test_5() {
        //设置资源类型
        _localizer = new StoreStringLocalizer( NullLogger.Instance, _mockMemoryCache.Object, _mockLocalizedStore.Object, "type1", _mockOptions.Object );

        //设置存储器获取资源
        _mockLocalizedStore.Setup( t => t.GetValue( "zh-CN", "type1", "name_{0}" ) ).Returns( "value_{0}" );

        //执行
        var result = _localizer["name_{0}", "a"];

        //验证
        Assert.Equal( "value_a", result );
    }

    /// <summary>
    /// 测试获取全部本地化资源 - 包含父区域资源
    /// </summary>
    [Fact]
    public void TestGetAllStrings_1() {
        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", null ) ).Returns( resources );
        var resources2 = new Dictionary<string, string> { { "name2", "名称2" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh", null ) ).Returns( resources2 );

        //执行
        var result = _localizer.GetAllStrings().ToList();

        //验证
        Assert.Equal( 2, result.Count );
        Assert.Equal( "name", result[0].Name );
        Assert.Equal( "名称", result[0].Value );
        Assert.False( result[0].ResourceNotFound );
    }

    /// <summary>
    /// 测试获取全部本地化资源 - 不包含父区域资源
    /// </summary>
    [Fact]
    public void TestGetAllStrings_2() {
        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", null ) ).Returns( resources );
        var resources2 = new Dictionary<string, string> { { "name2", "名称2" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh", null ) ).Returns( resources2 );

        //执行
        var result = _localizer.GetAllStrings( false ).ToList();

        //验证
        Assert.Single( result );
        Assert.Equal( "name", result[0].Name );
        Assert.Equal( "名称", result[0].Value );
        Assert.False( result[0].ResourceNotFound );
    }

    /// <summary>
    /// 测试获取全部本地化资源 - 资源类型
    /// </summary>
    [Fact]
    public void TestGetAllStrings_3() {
        //设置资源类型
        _mockLocalizedStore.Setup( t => t.GetTypes() ).Returns( new List<string> { "type1", "type2" } );

        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", "type1" ) ).Returns( resources );

        var resources2 = new Dictionary<string, string> { { "name2", "名称2" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", "type2" ) ).Returns( resources2 );

        //执行
        var result = _localizer.GetAllStrings().ToList();

        //验证
        Assert.Equal( 2, result.Count );
    }
}