using Util.Generators.Contexts;
using Xunit;

namespace Util.Generators.Tests.Contexts {
    /// <summary>
    /// 输出测试
    /// </summary>
    public class OutputTest {
        /// <summary>
        /// 测试输出路径
        /// </summary>
        [Fact]
        public void TestPath() {
            var output = new Output {
                RootPath = @"c:\",
                RelativeRootPath = @"a\b",
                FileNameNoExtension = "e",
                Extension = ".cs"
            };
            Assert.Equal( @"c:\a\b\e.cs", output.Path );
        }

        /// <summary>
        /// 测试复制
        /// </summary>
        [Fact]
        public void TestCopyTo() {
            var output = new Output {
                RootPath = "a",
                RelativeRootPath = "b",
                FileNameNoExtension = "c",
                Extension = "d",
                NamingConvention = NamingConvention.CamelCase
            };
            var copy = new Output();
            output.CopyTo( copy );
            Assert.Equal( "a",copy.RootPath );
            Assert.Equal( "b", copy.RelativeRootPath );
            Assert.Equal( "c", copy.FileNameNoExtension );
            Assert.Equal( "d", copy.Extension );
            Assert.Equal( NamingConvention.CamelCase, copy.NamingConvention );
        }
    }
}
