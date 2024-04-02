using System.Collections.Generic;
using Moq;
using Util.Ui.Razor.Internal;
using Xunit;

namespace Util.Ui.Tests.Razor;

/// <summary>
/// Razor视图容器测试
/// </summary>
public class RazorViewContainerTest {
    /// <summary>
    /// Razor视图容器
    /// </summary>
    private readonly RazorViewContainer _container;
    /// <summary>
    /// 分部视图路径模拟解析器
    /// </summary>
    private readonly Mock<IPartViewPathResolver> _mockPartViewPathResolver;
    /// <summary>
    /// 视图内容模拟解析器
    /// </summary>
    private readonly Mock<IViewContentResolver> _mockContentResolver;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public RazorViewContainerTest() {
        _mockPartViewPathResolver = new Mock<IPartViewPathResolver>();
        _mockContentResolver = new Mock<IViewContentResolver>();
        _container = new RazorViewContainer( _mockPartViewPathResolver.Object, _mockContentResolver.Object );
    }

    /// <summary>
    /// 测试添加视图 - 不包含分部视图
    /// </summary>
    [Fact]
    public void TestAddView_1() {
        //变量定义
        var path = "/path1";
        var content = "@page a";

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );

        //执行
        var result = _container.AddView( path );
        Assert.True( result is MainView );
        Assert.Equal( path, result.Path );
        Assert.Empty( result.PartViews );
    }

    /// <summary>
    /// 测试添加视图 - 1个分部视图
    /// </summary>
    [Fact]
    public void TestAddView_2() {
        //变量定义
        var path = "/path1";
        var content = "@page a";
        var partPath = "/path2";

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [partPath] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( partPath ) ).Returns( "a" );

        //执行
        var result = _container.AddView( path );
        Assert.True( result is MainView );
        Assert.Equal( path, result.Path );
        Assert.Single( result.PartViews );
        Assert.Equal( partPath, result.PartViews[0].Path );
        Assert.Single( result.PartViews[0].MainViews );
    }

    /// <summary>
    /// 测试添加视图 - 2个分部视图
    /// </summary>
    [Fact]
    public void TestCreateView_3() {
        //变量定义
        var path = "/path1";
        var content = "@page a";
        var path2 = "/path2";
        var path3 = "/path3";

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [path2, path3] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( path2 ) ).Returns( "a" );
        _mockContentResolver.Setup( t => t.Resolve( path3 ) ).Returns( "a" );

        //执行
        var result = _container.AddView( path );
        Assert.Equal( 2, result.PartViews.Count );
        Assert.Equal( path2, result.PartViews[0].Path );
        Assert.Single( result.PartViews[0].MainViews );
        Assert.Equal( path3, result.PartViews[1].Path );
        Assert.Single( result.PartViews[1].MainViews );
    }

    /// <summary>
    /// 测试添加视图 - 2个分部视图 - 分部视图嵌套
    /// </summary>
    [Fact]
    public void TestCreateView_4() {
        //变量定义
        var path = "/path1";
        var content = "@page a";
        var path2 = "/path2";
        var path3 = "/path3";
        var path4 = "/path4";
        var content2 = "b";

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [path2, path3] );
        _mockPartViewPathResolver.Setup( t => t.Resolve( path3, content2 ) ).Returns( [path4] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( path2 ) ).Returns( "a" );
        _mockContentResolver.Setup( t => t.Resolve( path3 ) ).Returns( content2 );
        _mockContentResolver.Setup( t => t.Resolve( path4 ) ).Returns( "a" );

        //执行
        var result = _container.AddView( path );
        Assert.Equal( 2, result.PartViews.Count );
        Assert.Equal( path2, result.PartViews[0].Path );
        Assert.Single( result.PartViews[0].MainViews );
        Assert.Equal( path3, result.PartViews[1].Path );
        Assert.Single( result.PartViews[1].MainViews );
        Assert.Single( result.PartViews[1].PartViews );
        Assert.Equal( path4, result.PartViews[1].PartViews[0].Path );
        Assert.Equal( path3, result.PartViews[1].PartViews[0].MainViews[0].Path );
    }

    /// <summary>
    /// 测试获取关联视图路径列表 - 获取1个主视图
    /// </summary>
    [Fact]
    public void TestGetViewPaths_1() {
        //变量定义
        var path = "/path1";
        var content = "@page a";
        var list = new List<string> { path };

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );

        //初始化容器
        _container.Init( list );

        //执行
        var result = _container.GetViewPaths( path );
        Assert.Single( result );
        Assert.Equal( path, result[0] );
    }

    /// <summary>
    /// 测试获取关联视图路径列表 - 获取分部视图路径 - 1个主视图引用分部视图
    /// </summary>
    [Fact]
    public void TestGetViewPaths_2() {
        //变量定义
        var path = "/path1";
        var content = "@page a";
        var partPath = "/path2";
        var list = new List<string> { path };

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [partPath] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( partPath ) ).Returns( "a" );

        //初始化容器
        _container.Init( list );

        //执行
        var result = _container.GetViewPaths( partPath );
        Assert.Single( result );
        Assert.Equal( path, result[0] );
    }

    /// <summary>
    /// 测试获取关联视图路径列表 - 获取分部视图路径 - 2个主视图引用分部视图
    /// </summary>
    [Fact]
    public void TestGetViewPaths_3() {
        //变量定义
        var path = "/path1";
        var path2 = "/path2";
        var content = "@page a";
        var partPath = "/partPath";
        var list = new List<string> { path, path2 };

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [partPath] );
        _mockPartViewPathResolver.Setup( t => t.Resolve( path2, content ) ).Returns( [partPath] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( path2 ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( partPath ) ).Returns( "a" );

        //初始化容器
        _container.Init( list );

        //执行
        var result = _container.GetViewPaths( partPath );
        Assert.Equal( 2, result.Count );
        Assert.Equal( path, result[0] );
        Assert.Equal( path2, result[1] );
    }

    /// <summary>
    /// 测试获取关联视图路径列表 - 获取分部视图路径 - 分部视图嵌套
    /// </summary>
    [Fact]
    public void TestGetViewPaths_4() {
        //变量定义
        var path = "/path1";
        var path2 = "/path2";
        var content = "@page a";
        var content2 = "a";
        var partPath = "/partPath";
        var partPath2 = "/partPath2";
        var list = new List<string> { path, path2 };

        //方法设置
        _mockPartViewPathResolver.Setup( t => t.Resolve( path, content ) ).Returns( [partPath] );
        _mockPartViewPathResolver.Setup( t => t.Resolve( path2, content ) ).Returns( [partPath2] );
        _mockPartViewPathResolver.Setup( t => t.Resolve( partPath2, content2 ) ).Returns( [partPath] );
        _mockContentResolver.Setup( t => t.Resolve( path ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( path2 ) ).Returns( content );
        _mockContentResolver.Setup( t => t.Resolve( partPath ) ).Returns( "a" );
        _mockContentResolver.Setup( t => t.Resolve( partPath2 ) ).Returns( content2 );

        //初始化容器
        _container.Init( list );

        //执行
        var result = _container.GetViewPaths( partPath );
        Assert.Equal( 2, result.Count );
        Assert.Equal( path, result[0] );
        Assert.Equal( path2, result[1] );
    }
}