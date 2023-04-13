using System;
using Util.FileStorage.Minio.Samples;
using Util.Helpers;
using Xunit;

namespace Util.FileStorage.Minio.Tests {
    /// <summary>
    /// 基于用户标识和时间的文件名处理器测试
    /// </summary>
    public class UserTimeFileNameProcessorTest : IDisposable {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public UserTimeFileNameProcessorTest() {
            Time.SetTime( new DateTime( 2012, 12, 12, 12, 12, 12, 123 ) );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 测试处理文件名
        /// </summary>
        [Fact]
        public void TestProcess_1() {
            var processor = new UserTimeFileNameProcessor( new TestSession() );
            var result = processor.Process( "a.jpg" );
            Assert.Equal( $"{TestSession.TestUserId}/2012-12-12-12-12-12-123/a.jpg", result.Name );
        }
    }
}
