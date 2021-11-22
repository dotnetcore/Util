using System.Text;
using Util.Templates.Razor.Filters;
using Xunit;

namespace Util.Templates.Razor.Tests.Filters {
    /// <summary>
    /// 模型过滤器测试
    /// </summary>
    public class ModelFilterTest {
        /// <summary>
        /// 模型过滤器
        /// </summary>
        private readonly ModelFilter _filter;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ModelFilterTest() {
            _filter = new ModelFilter();
        }

        /// <summary>
        /// 测试将@model替换为@inherits RazorEngineCore.RazorEngineTemplateBase
        /// </summary>
        [Fact]
        public void TestFilter() {
            var template = new StringBuilder();
            template.Append( "@using Util.Templates.Razor.Tests.Samples.Models " );
            template.Append( "@model TestModel " );
            template.Append( "hello,@Model.Name" );
            var filterTemplate = _filter.Filter( template.ToString() );

            var result = new StringBuilder();
            result.Append( "@using Util.Templates.Razor.Tests.Samples.Models " );
            result.Append( "@inherits RazorEngineCore.RazorEngineTemplateBase<TestModel> " );
            result.Append( "hello,@Model.Name" );

            Assert.Equal( result.ToString(), filterTemplate );
        }
    }
}
