using System.Linq;
using Util.Reflections;
using Xunit;

namespace Util.Tests.Reflections {
    /// <summary>
    /// 应用程序域程序集查找器测试
    /// </summary>
    public class AppDomainAssemblyFinderTest {
        /// <summary>
        /// 程序集查找器
        /// </summary>
        private readonly AppDomainAssemblyFinder _finder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AppDomainAssemblyFinderTest() {
            _finder = new AppDomainAssemblyFinder();
        }

        /// <summary>
        /// 测试查找程序集列表 - 当前测试项目程序集被自动加载到应用程序域
        /// </summary>
        [Fact]
        public void TestFind_1() {
            var assemblies = _finder.Find();
            var names = assemblies.Select( t => t.FullName ).ToList();
            Assert.True( names.Exists( t => t.StartsWith( "Util.Core.Tests.Integration" ) ) );
        }

        /// <summary>
        /// 测试查找程序集列表 - Util.Events程序集被引用但未被调用,未初始加载到应用程序域,需要在获取之前进行加载
        /// </summary>
        [Fact]
        public void TestFind_2() {
            var assemblies = _finder.Find();
            var names = assemblies.Select( t => t.FullName ).ToList();
            Assert.True( names.Exists( t => t.StartsWith( "Util.Events" ) ) );
        }

        /// <summary>
        /// 测试查找程序集列表 - 过滤Microsoft程序集
        /// </summary>
        [Fact]
        public void TestFind_3() {
            _finder.AssemblySkipPattern = "^Microsoft";
            var assemblies = _finder.Find();
            var names = assemblies.Select( t => t.FullName ).ToList();
            Assert.False( names.Exists( t => t.StartsWith( "Microsoft" ) ) );
        }
    }
}
