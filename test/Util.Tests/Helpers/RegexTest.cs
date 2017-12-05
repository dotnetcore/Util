using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 正则操作测试
    /// </summary>
    public class RegexTest {
        /// <summary>
        /// 测试获取值
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="resultPattern">结果模式字符串</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( "", "", "", "" )]
        [InlineData( "123", "a", "", "" )]
        [InlineData( "123", @"\d", "", "1" )]
        [InlineData( "123abc456", @"\d+([a-z]+\d+)", "$1", "abc456" )]
        [InlineData( "123abc456", @"\d+([a-z]\d+)", "$1", "" )]
        public void TestGetValue( string input, string pattern,string resultPattern, string result ) {
            Assert.Equal( result, Util.Helpers.Regex.GetValue( input, pattern, resultPattern ) );
        }

        /// <summary>
        /// 测试获取值集合
        /// </summary>
        [Fact]
        public void TestGetValues() {
            Assert.Empty( Util.Helpers.Regex.GetValues( "", "",null ) );
            Assert.Empty( Util.Helpers.Regex.GetValues( "123abc456", @"\d{5}",new []{"$1"} ) );
            Assert.Equal( "123", Util.Helpers.Regex.GetValues( "123abc456", @"(\d*)", new[] { "$1" } )["$1"] );
            Assert.Equal( "abc", Util.Helpers.Regex.GetValues( "123abc456", @"\d*([a-z]*)\d*", new[] { "$1" } )["$1"] );
            Assert.Equal( "123", Util.Helpers.Regex.GetValues( "123abc456", @"(\d*)([a-z]*)(\d*)", new[] { "$1", "$2", "$3" } )["$1"] );
            Assert.Equal( "abc", Util.Helpers.Regex.GetValues( "123abc456", @"(\d*)([a-z]*)(\d*)", new[] { "$1", "$2", "$3" } )["$2"] );
            Assert.Equal( "456", Util.Helpers.Regex.GetValues( "123abc456", @"(\d*)([a-z]*)(\d*)", new[] { "$1", "$2", "$3" } )["$3"] );
        }
    }
}
