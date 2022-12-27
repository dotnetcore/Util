using Util.Helpers;
using Xunit;

namespace Util.Tests.Helpers {
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
    }
}
