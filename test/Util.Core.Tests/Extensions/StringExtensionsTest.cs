using System.IO;
using System.Text;
using Xunit;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 字符串扩展测试
    /// </summary>
    public class StringExtensionsTest {
        /// <summary>
        /// 测试移除起始字符串 - 字符串
        /// </summary>
        [Fact]
        public void TestRemoveStart_String() {
            Assert.Equal( "bc", "abc".RemoveStart( "a" ) );
        }

        /// <summary>
        /// 测试移除末尾字符串 - 字符串
        /// </summary>
        [Fact]
        public void TestRemoveEnd_String() {
            Assert.Equal( "ab", "abc".RemoveEnd( "c" ) );
        }

        /// <summary>
        /// 测试移除起始字符串 - StringBuilder
        /// </summary>
        [Fact]
        public void TestRemoveStart_StringBuilder() {
            var builder = new StringBuilder( "abc" );
            Assert.Equal( "bc", builder.RemoveStart( "a" ).ToString() );
        }

        /// <summary>
        /// 测试移除末尾字符串 - StringBuilder
        /// </summary>
        [Fact]
        public void TestRemoveEnd_StringBuilder() {
            var builder = new StringBuilder( "abc" );
            Assert.Equal( "ab", builder.RemoveEnd( "c" ).ToString() );
        }

        /// <summary>
        /// 测试移除起始字符串 - StringWriter
        /// </summary>
        [Fact]
        public void TestRemoveStart_StringWriter() {
            var writer = new StringWriter();
            writer.Write( "abc" );
            Assert.Equal( "bc", writer.RemoveStart( "a" ).ToString() );
        }

        /// <summary>
        /// 测试移除末尾字符串 - StringWriter
        /// </summary>
        [Fact]
        public void TestRemoveEnd_StringWriter() {
            var writer = new StringWriter();
            writer.Write( "abc" );
            Assert.Equal( "ab", writer.RemoveEnd( "c" ).ToString() );
        }
    }
}
