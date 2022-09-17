using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Breadcrumbs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Breadcrumbs {
    /// <summary>
    /// 面包屑项测试
    /// </summary>
    public class BreadcrumbItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public BreadcrumbItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new BreadcrumbItemTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb-item></nz-breadcrumb-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试弹出层
        /// </summary>
        [Fact]
        public void TestOverlay() {
            _wrapper.SetContextAttribute( UiConst.Overlay, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb-item [nzOverlay]=\"a\"></nz-breadcrumb-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb-item>" );
            result.Append( "a" );
            result.Append( "</nz-breadcrumb-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}