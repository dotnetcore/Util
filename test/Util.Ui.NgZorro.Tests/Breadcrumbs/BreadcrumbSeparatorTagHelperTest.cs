using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.NgZorro.Components.Breadcrumbs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Breadcrumbs {
    /// <summary>
    /// 面包屑分隔符测试
    /// </summary>
    public class BreadcrumbSeparatorTagHelperTest {
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
        public BreadcrumbSeparatorTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new BreadcrumbSeparatorTagHelper().ToWrapper();
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
            result.Append( "<nz-breadcrumb-separator></nz-breadcrumb-separator>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-breadcrumb-separator>" );
            result.Append( "a" );
            result.Append( "</nz-breadcrumb-separator>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}