using Util.Helpers;
using Xunit;

namespace Util.Tests.Helpers; 

/// <summary>
/// Url测试
/// </summary>
public class UrlTest {
    /// <summary>
    /// 测试连接路径
    /// </summary>
    [Theory]
    [InlineData( null, null, "" )]
    [InlineData( "", "", "" )]
    [InlineData( "a", "", "a" )]
    [InlineData( "", "a", "a" )]
    [InlineData( "a", "b", "a/b" )]
    [InlineData( "a/", "b", "a/b" )]
    [InlineData( "a", "/b", "a/b" )]
    [InlineData( "a", "\\b", "a/b" )]
    [InlineData( "/a", "b", "/a/b" )]
    [InlineData( "a", "b/", "a/b/" )]
    [InlineData( "/a/", "/b/", "/a/b/" )]
    public void TestJoinPath( string path1, string path2, string result ) {
        Assert.Equal( result, Url.JoinPath( path1, path2 ) );
    }

    /// <summary>
    /// 测试连接路径 - 上级路径带./
    /// </summary>
    [Fact]
    public void TestJoinPath_2() {
        Assert.Equal( "a/b", Url.JoinPath( "./a", "b" ) );
    }

    /// <summary>
    /// 测试连接路径 - 下级路径带./
    /// </summary>
    [Fact]
    public void TestJoinPath_3() {
        Assert.Equal( "a/b", Url.JoinPath( "a", "./b" ) );
    }

    /// <summary>
    /// 测试连接路径 - 下级路径带../
    /// </summary>
    [Fact]
    public void TestJoinPath_4() {
        Assert.Equal( "a/c", Url.JoinPath( "a/b", "../c" ) );
    }

    /// <summary>
    /// 测试连接路径 - http打头
    /// </summary>
    [Fact]
    public void TestJoinPath_5() {
        Assert.Equal( "http://a.com/a/c", Url.JoinPath( "http://a.com", "a/b", "../c" ) );
    }

    /// <summary>
    /// 测试连接路径 - https打头
    /// </summary>
    [Fact]
    public void TestJoinPath_6() {
        Assert.Equal( "https://a.com/a/c", Url.JoinPath( "https://a.com/", "a/b/", "../c" ) );
    }

    /// <summary>
    /// 测试连接路径 - https打头,带..路径
    /// </summary>
    [Fact]
    public void TestJoinPath_7() {
        Assert.Equal( "https://a.com/a/c/D/F/g", Url.JoinPath( "Https://a.com/a/b/", "../c/D/e/", "../F/g" ) );
    }

    /// <summary>
    /// 测试连接路径 - https打头,带..路径
    /// </summary>
    [Fact]
    public void TestJoinPath_8() {
        Assert.Equal( "https://a.com/view/a", Url.JoinPath( "https://a.com", "view", "a" ) );
    }
}