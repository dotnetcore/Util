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
        private UrlParameterBuilder _builder;

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
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_1() {
            _builder = new UrlParameterBuilder("a");
            Assert.Equal( 0, _builder.GetDictionary().Count );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_2() {
            _builder = new UrlParameterBuilder( "a=b" );
            Assert.Equal( 1, _builder.GetDictionary().Count );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_3() {
            _builder = new UrlParameterBuilder( "a=1&b=2" );
            Assert.Equal( 2, _builder.GetDictionary().Count );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_4() {
            _builder = new UrlParameterBuilder( "a=1&b" );
            Assert.Equal( 1, _builder.GetDictionary().Count );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_5() {
            _builder = new UrlParameterBuilder( "a=1&b=" );
            Assert.Equal( 1, _builder.GetDictionary().Count );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_6() {
            _builder = new UrlParameterBuilder( "http://test.com?b=2&c=3&a=1" );
            Assert.Equal( 3, _builder.GetDictionary().Count );
            Assert.Equal( "a=1&b=2&c=3", _builder.Result( true ) );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        [Fact]
        public void TestLoadUrl_7() {
            _builder = new UrlParameterBuilder( "http://test.com ? b = 2 & c & a = 1 " );
            Assert.Equal( "a=1&b=2", _builder.Result( true ) );
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
        /// 连接Url
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
