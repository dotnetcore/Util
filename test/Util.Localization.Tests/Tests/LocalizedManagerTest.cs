namespace Util.Localization.Store.Tests;

public class LocalizedManagerTest {
    /// <summary>
    /// 模拟缓存
    /// </summary>
    private readonly Mock<IMemoryCache> _mockMemoryCache;
    /// <summary>
    /// 模拟本地化资源存储器
    /// </summary>
    private readonly Mock<ILocalizedStore> _mockLocalizedStore;
    /// <summary>
    /// 本地化资源管理器
    /// </summary>
    private readonly LocalizedManager _manager;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public LocalizedManagerTest() {
        _mockMemoryCache = new Mock<IMemoryCache>();
        var mockCacheEntry = new Mock<ICacheEntry>();
        _mockMemoryCache.Setup( t => t.CreateEntry( It.IsAny<object>() ) ).Returns( mockCacheEntry.Object );
        _mockLocalizedStore = new Mock<ILocalizedStore>();
        _mockLocalizedStore.Setup( t => t.GetTypes() ).Returns( new List<string>() );
        var mockOptions = new Mock<IOptions<LocalizationOptions>>();
        _manager = new LocalizedManager( _mockLocalizedStore.Object, _mockMemoryCache.Object, mockOptions.Object );
        CultureInfo.CurrentUICulture = new CultureInfo( "zh-CN" );
    }

    /// <summary>
    /// 测试加载全部资源
    /// </summary>
    [Fact]
    public void TestLoadAllResources_1() {
        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", null ) ).Returns( resources );

        //执行
        _manager.LoadAllResources();

        //验证
        _mockMemoryCache.Verify( t => t.CreateEntry( "zh-CN--name" ) );
    }

    /// <summary>
    /// 测试加载全部资源 - 本地化配置设置区域文化 - 多个区域文化
    /// </summary>
    [Fact]
    public void TestLoadAllResources_2() {
        //设置区域文化
        _mockLocalizedStore.Setup( t => t.GetCultures() ).Returns( new []{ "en-US" } );

        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", null ) ).Returns( resources );
        var resources2 = new Dictionary<string, string> { { "name", "Name2" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "en-US", null ) ).Returns( resources2 );

        //执行
        _manager.LoadAllResources();

        //验证
        _mockMemoryCache.Verify( t => t.CreateEntry( "zh-CN--name" ) );
        _mockMemoryCache.Verify( t => t.CreateEntry( "en-US--name" ) );
    }

    /// <summary>
    /// 测试加载全部资源 - 1个资源类型
    /// </summary>
    [Fact]
    public void TestLoadAllResources_3() {
        //设置区域文化
        _mockLocalizedStore.Setup( t => t.GetCultures() ).Returns( new[] { "en-US" } );

        //设置资源类型
        _mockLocalizedStore.Setup( t => t.GetTypes() ).Returns( new List<string> { "type1" } );

        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", "type1" ) ).Returns( resources );
        var resources2 = new Dictionary<string, string> { { "name", "Name2" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "en-US", "type1" ) ).Returns( resources2 );

        //执行
        _manager.LoadAllResources();

        //验证
        _mockMemoryCache.Verify( t => t.CreateEntry( "zh-CN-type1-name" ) );
        _mockMemoryCache.Verify( t => t.CreateEntry( "en-US-type1-name" ) );
    }

    /// <summary>
    /// 测试加载全部资源 - 2个资源类型
    /// </summary>
    [Fact]
    public void TestLoadAllResources_4() {
        //设置区域文化
        _mockLocalizedStore.Setup( t => t.GetCultures() ).Returns( new[] { "en-US" } );

        //设置资源类型
        _mockLocalizedStore.Setup( t => t.GetTypes() ).Returns( new List<string> { "type1", "type2" } );

        //设置返回资源
        var resources = new Dictionary<string, string> { { "name", "名称" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", "type1" ) ).Returns( resources );

        var resources2 = new Dictionary<string, string> { { "name", "名称2" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "zh-CN", "type2" ) ).Returns( resources2 );

        var resources3 = new Dictionary<string, string> { { "name", "Name3" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "en-US", "type1" ) ).Returns( resources3 );

        var resources4 = new Dictionary<string, string> { { "name", "Name4" } };
        _mockLocalizedStore.Setup( t => t.GetResources( "en-US", "type2" ) ).Returns( resources4 );

        //执行
        _manager.LoadAllResources();

        //验证
        _mockMemoryCache.Verify( t => t.CreateEntry( "zh-CN-type1-name" ) );
        _mockMemoryCache.Verify( t => t.CreateEntry( "zh-CN-type2-name" ) );
        _mockMemoryCache.Verify( t => t.CreateEntry( "en-US-type1-name" ) );
        _mockMemoryCache.Verify( t => t.CreateEntry( "en-US-type2-name" ) );
    }
}