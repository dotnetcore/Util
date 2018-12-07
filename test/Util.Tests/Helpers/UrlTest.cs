using Util.Helpers;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// Url操作测试
    /// </summary>
    public class UrlTest {
        /// <summary>
        /// 合并Url
        /// </summary>
        [Theory]
        [InlineData("http://a.com","b","http://a.com/b")]
        [InlineData( "http://a.com/", "b", "http://a.com/b" )]
        [InlineData( @"http://a.com\", "b", "http://a.com/b" )]
        public void Test(string url,string url2,string result) {
            Assert.Equal( result, Url.Combine( url, url2 ) );
        }

        /// <summary>
        /// 连接Url
        /// </summary>
        [Theory]
        [InlineData( "http://test.com", "a=1", "http://test.com?a=1" )]
        [InlineData( "http://test.com?", "a=1", "http://test.com?a=1" )]
        [InlineData( "http://test.com?c=3", "a=1", "http://test.com?c=3&a=1" )]
        [InlineData( "http://test.com?c=3&", "a=1", "http://test.com?c=3&a=1" )]
        public void TestJoinUrl( string url,string param, string result ) {
            Assert.Equal( result, Url.Join( url, param ) );
        }
    }
}
