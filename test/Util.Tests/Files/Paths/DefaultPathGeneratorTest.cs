using System;
using System.IO;
using Util.Files.Paths;
using Util.Randoms;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Tests.Files.Paths {
    /// <summary>
    /// 路径生成器
    /// </summary>
    public class DefaultPathGeneratorTest {
        /// <summary>
        /// 路径生成器
        /// </summary>
        private readonly IPathGenerator _generator;

        /// <summary>
        /// 初始化测试
        /// </summary>
        public DefaultPathGeneratorTest() {
            _generator = new DefaultPathGenerator( new DefaultBasePath( @"c:\" ) ,new StubRandomGenerator() );
        }

        /// <summary>
        /// 测试生成路径
        /// </summary>
        [Fact]
        public void TestGenerate() {
            Assert.Equal( @"c:\a.txt", _generator.Generate( "a.txt" ) );
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
        [Theory]
        [InlineData( "txt" )]
        [InlineData( ".txt" )]
        public void TestGenerate_OnlyExtension( string fileName ) {
            Assert.Equal( @"c:\random.txt", _generator.Generate( fileName ) );
        }
    }
}
