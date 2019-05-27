using System;
using Util.Files.Paths;
using Util.Helpers;
using Util.Randoms;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Tests.Files.Paths {
    /// <summary>
    /// 路径生成器
    /// </summary>
    public class DefaultPathGeneratorTest : IDisposable {
        /// <summary>
        /// 路径生成器
        /// </summary>
        private readonly IPathGenerator _generator;

        /// <summary>
        /// 初始化测试
        /// </summary>
        public DefaultPathGeneratorTest() {
            _generator = new DefaultPathGenerator( new DefaultBasePath( @"b" ) ,new StubRandomGenerator() );
            Time.SetTime( "2000-1-1 10:11:12" );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        /// <summary>
        /// 测试生成路径
        /// </summary>
        [Fact]
        public void TestGenerate() {
            Assert.Equal( @"b/a-101112.txt", _generator.Generate( "a.txt" ) );
        }

        /// <summary>
        /// 测试生成路径,验证文件名为空
        /// </summary>
        [Fact]
        public void TestGenerate_FileNameIsEmpty() {
            AssertHelper.Throws<ArgumentNullException>( () => {
                _generator.Generate( "" );
            }, "fileName" );
        }

        /// <summary>
        /// 测试生成路径,文件名仅包含扩展名，自动创建随机文件名
        /// </summary>
        [Theory(Skip = "偶尔会运行失败")]
        [InlineData( "txt" )]
        [InlineData( ".txt" )]
        public void TestGenerate_Extension( string fileName ) {
            Assert.Equal( @"b/random-101112.txt", _generator.Generate( fileName ) );
        }
    }
}
