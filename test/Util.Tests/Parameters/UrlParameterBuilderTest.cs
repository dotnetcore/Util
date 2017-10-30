using Util.Parameters;
using Xunit;

namespace Util.Tests.Parameters {
    /// <summary>
    /// Url参数生成器测试
    /// </summary>
    public class UrlParameterBuilderTest {
        /// <summary>
        /// Url参数生成器
        /// </summary>
        private readonly UrlParameterBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public UrlParameterBuilderTest() {
            _builder = new UrlParameterBuilder();
        }

        /// <summary>
        /// 测试默认值
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Empty( _builder.Result() );
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            Assert.Equal( "a=b", _builder.Add( "a", "b" ).Result() );
            Assert.Equal( "a=b&c=d", _builder.Add( "c", "d" ).Result() );
        }

        /// <summary>
        /// 添加参数 - 测试空格
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            Assert.Equal( "b=2&a=1", _builder.Add( " b ", " 2 " ).Add( " a ", " 1 " ).Result() );
        }

        /// <summary>
        /// 添加参数 - 测试排序
        /// </summary>
        [Fact]
        public void TestResult_Sort() {
            Assert.Equal( "a=1&b=2", _builder.Add( "b", "2" ).Add( "a", "1" ).Result( true ) );
        }

        /// <summary>
        /// 连接URL
        /// </summary>
        [Theory]
        [InlineData( "http://test.com", "http://test.com?a=1&b=2" )]
        [InlineData( "http://test.com?", "http://test.com?a=1&b=2" )]
        [InlineData( "http://test.com?c=3", "http://test.com?c=3&a=1&b=2" )]
        [InlineData( "http://test.com?c=3&", "http://test.com?c=3&a=1&b=2" )]
        public void TestJoinUrl( string url, string result ) {
            Assert.Equal( result, _builder.Add( "a", "1" ).Add( "b", "2" ).JoinUrl( url ) );
        }
    }
}
