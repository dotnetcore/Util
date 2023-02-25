using System.Linq;
using Util.Generators.Contexts;
using Util.Generators.Templates;
using Xunit;

namespace Util.Generators.Razor.Tests {
    /// <summary>
    /// Razor模板查找器测试
    /// </summary>
    public class RazorTemplateFinderTest {
        /// <summary>
        /// Razor模板查找器
        /// </summary>
        private readonly ITemplateFinder _finder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RazorTemplateFinderTest( ITemplateFinder finder ) {
            _finder = finder;
        }

        /// <summary>
        /// 测试查找模板列表
        /// </summary>
        [Fact]
        public void TestFind() {
            var result = _finder.Find( "Templates",new ProjectContext( new GeneratorContext() ) ).ToList();
            Assert.Equal( 3, result.Count );
        }
    }
}
