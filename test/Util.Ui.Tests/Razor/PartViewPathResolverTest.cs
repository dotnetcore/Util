using System.Text;
using Moq;
using Util.Ui.Razor.Internal;
using Xunit;

namespace Util.Ui.Tests.Razor;

/// <summary>
/// 分部视图路径解析器测试
/// </summary>
public class PartViewPathResolverTest {
    /// <summary>
    /// 分部视图路径解析器
    /// </summary>
    private readonly PartViewPathResolver _resolver;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public PartViewPathResolverTest() {
        var mockFinder = new Mock<IPartViewPathFinder>();
        mockFinder.Setup( t => t.Find( It.IsAny<string>(), It.IsAny<string>() ) ).Returns<string, string>( ( _, partName ) => partName );
        _resolver = new PartViewPathResolver( mockFinder.Object );
    }

    /// <summary>
    /// 测试解析分部视图路径 - 解析空值
    /// </summary>
    [Fact]
    public void TestResolve_1() {
        Assert.Empty( _resolver.Resolve( null, "a" ) );
        Assert.Empty( _resolver.Resolve( "a", null ) );
        Assert.Empty( _resolver.Resolve( "a", "" ) );
        Assert.Empty( _resolver.Resolve( "a", " " ) );
        Assert.Empty( _resolver.Resolve( "a", "a" ) );
    }

    /// <summary>
    /// 测试解析分部视图路径 - 包含1个分部视图
    /// </summary>
    [Fact]
    public void TestResolve_2() {
        var result = _resolver.Resolve( "Views/Home", "@page\r\n\r\ntest\r\n\r\n\r\n\r\n   <partial name=\"Part\"/>  abc" );
        Assert.Single( result );
        Assert.Equal( "Part", result[0] );
    }

    /// <summary>
    /// 测试解析分部视图路径 - 包含2个分部视图
    /// </summary>
    [Fact]
    public void TestResolve_3() {
        var content = new StringBuilder();
        content.AppendLine( "  @page\r\n\r\ntest\r\n\r\n\r\n\r\n   <partial name=\"Part\"/>  abc " );
        content.AppendLine( "r\ntest\r\n\r\n\r\n\r\n   <   partial   name  =  \"Part2\"   /  >  bbb " );
        var result = _resolver.Resolve( "Views/Home", content.ToString() );
        Assert.Equal( 2, result.Count );
        Assert.Equal( "Part", result[0] );
        Assert.Equal( "Part2", result[1] );
    }
}