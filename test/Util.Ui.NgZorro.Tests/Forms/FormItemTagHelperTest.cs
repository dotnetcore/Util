using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Forms {
    /// <summary>
    /// 表单项测试
    /// </summary>
    public class FormItemTagHelperTest {
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
        public FormItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new FormItemTagHelper().ToWrapper();
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
            result.Append( "<nz-form-item></nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试垂直对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            _wrapper.SetContextAttribute( UiConst.Align, Align.Middle );
            var result = new StringBuilder();
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试垂直对齐方式
        /// </summary>
        [Fact]
        public void TestBindAlign() {
            _wrapper.SetContextAttribute( AngularConst.BindAlign, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item [nzAlign]=\"a\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间隔
        /// </summary>
        [Fact]
        public void TestGutter() {
            _wrapper.SetContextAttribute( UiConst.Gutter, "2" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item [nzGutter]=\"2\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试水平排列方式
        /// </summary>
        [Fact]
        public void TestJustify() {
            _wrapper.SetContextAttribute( UiConst.Justify, Justify.Center );
            var result = new StringBuilder();
            result.Append( "<nz-form-item nzJustify=\"center\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试水平排列方式
        /// </summary>
        [Fact]
        public void TestBindJustify() {
            _wrapper.SetContextAttribute( AngularConst.BindJustify, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item [nzJustify]=\"a\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}