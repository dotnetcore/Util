using Xunit;

namespace Util.FileStorage.Minio.Tests {
    /// <summary>
    /// 文件处理结果测试
    /// </summary>
    public class FileResultTest {
        /// <summary>
        /// 测试文件处理结果
        /// </summary>
        [Fact]
        public void Test_1() {
            var fileInfo = new FileResult( "a.jpg", 1024, "b" );
            Assert.Equal( "a.jpg", fileInfo.FilePath );
            Assert.Equal( "a.jpg", fileInfo.FileName );
            Assert.Equal( "jpg", fileInfo.Extension );
            Assert.Equal( 1024, fileInfo.Size.GetSize() );
            Assert.Equal( "1 KB", fileInfo.Size.ToString() );
            Assert.Equal( "b", fileInfo.Bucket );
        }

        /// <summary>
        /// 测试文件处理结果 - 不带扩展名
        /// </summary>
        [Fact]
        public void Test_2() {
            var fileInfo = new FileResult( "a", 1024 );
            Assert.Equal( "a", fileInfo.FilePath );
            Assert.Equal( "a", fileInfo.FileName );
            Assert.True( fileInfo.Extension.IsEmpty() );
        }

        /// <summary>
        /// 测试文件处理结果 - 文件名带路径
        /// </summary>
        [Fact]
        public void Test_3() {
            var fileInfo = new FileResult( "a/b.jpg", 1024 );
            Assert.Equal( "a/b.jpg", fileInfo.FilePath );
            Assert.Equal( "b.jpg", fileInfo.FileName );
            Assert.Equal( "jpg", fileInfo.Extension );
        }
    }
}
