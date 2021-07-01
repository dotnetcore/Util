using Util.Reflections;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Reflections {
    /// <summary>
    /// 应用程序域类型查找器测试
    /// </summary>
    public class AppDomainTypeFinderTest {
        /// <summary>
        /// 应用程序域类型查找器
        /// </summary>
        private readonly AppDomainTypeFinder _finder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AppDomainTypeFinderTest() {
            var assemblyFinder = new AppDomainAssemblyFinder();
            _finder = new AppDomainTypeFinder( assemblyFinder );
        }

        /// <summary>
        /// 测试查找实现类型列表
        /// </summary>
        [Fact]
        public void TestFind_1() {
            var types = _finder.Find<IA>();
            Assert.Single( types );
            Assert.Equal( typeof( A ), types[0] );
        }
    }
}
