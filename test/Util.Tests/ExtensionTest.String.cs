using Xunit;

namespace Util.Tests {
    /// <summary>
    /// 扩展测试 - 字符串
    /// </summary>
    public partial class ExtensionTest {
        /// <summary>
        /// 测试移除末尾字符串
        /// </summary>
        [Theory]
        [InlineData( null, "a", "" )]
        [InlineData( "a", null, "a" )]
        [InlineData("","a","")]
        [InlineData( "a", "a", "" )]
        [InlineData( "a", "ab", "a" )]
        [InlineData( "aabbcc", "ab", "aabbcc" )]
        [InlineData( "abc", "b", "abc" )]
        [InlineData( "abcb", "bc", "abcb" )]
        [InlineData( "abc", "bc", "a" )]
        [InlineData( "abc ", "bc ", "a" )]
        [InlineData( "abc ", "bc", "abc " )]
        [InlineData( "abc", "bc ", "abc" )]
        [InlineData( "abc ", "Bc", "abc " )]
        [InlineData( "abc ", "Bc ", "a" )]
        public void TestRemoveEnd( string input,string remove,string result ) {
            Assert.Equal( result, input.RemoveEnd( remove ) );
        }
    }
}
