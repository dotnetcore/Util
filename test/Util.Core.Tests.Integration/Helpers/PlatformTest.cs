using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 平台操作测试
    /// </summary>
    public class PlatformTest {
        /// <summary>
        /// 测试获取物理路径
        /// </summary>
        [Fact]
        public void TestGetPhysicalPath_1() {
            var path = Util.Helpers.Common.GetPhysicalPath( "a/b.txt" );
            var result = $"{System.AppContext.BaseDirectory}a/b.txt";
            Assert.Equal( result,path );
        }

        /// <summary>
        /// 测试获取物理路径 - 以/开头
        /// </summary>
        [Fact]
        public void TestGetPhysicalPath_2() {
            var path = Util.Helpers.Common.GetPhysicalPath( "/a/b.txt" );
            var result = $"{System.AppContext.BaseDirectory}a/b.txt";
            Assert.Equal( result, path );
        }

        /// <summary>
        /// 测试获取物理路径 - 以\开头
        /// </summary>
        [Fact]
        public void TestGetPhysicalPath_3() {
            var path = Util.Helpers.Common.GetPhysicalPath( "\\a\\b.txt" );
            var result = $"{System.AppContext.BaseDirectory}a\\b.txt";
            Assert.Equal( result, path );
        }

        /// <summary>
        /// 测试获取物理路径
        /// </summary>
        [Fact]
        public void TestGetPhysicalPath_4() {
            var path = Util.Helpers.Common.GetPhysicalPath( "~/a/b.txt" );
            var result = $"{System.AppContext.BaseDirectory}a/b.txt";
            Assert.Equal( result, path );
        }
    }
}
