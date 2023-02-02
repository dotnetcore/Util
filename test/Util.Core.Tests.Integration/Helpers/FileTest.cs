using System.Threading.Tasks;
using Util.Helpers;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 文件流操作
    /// </summary>
    public class FileTest {
        /// <summary>
        /// 测试读取文件到字符串
        /// </summary>
        [Fact]
        public void TestReadToString() {
            var filePath = Util.Helpers.Common.GetPhysicalPath( "/Samples/FileSample.txt" );
            Assert.Equal( "test", File.ReadToString( filePath ) );
        }

        /// <summary>
        /// 测试读取文件到字符串
        /// </summary>
        [Fact]
        public async Task TestReadToStringAsync() {
            var filePath = Util.Helpers.Common.GetPhysicalPath( "/Samples/FileSample.txt" );
            Assert.Equal( "test",await File.ReadToStringAsync( filePath ) );
        }
    }
}
