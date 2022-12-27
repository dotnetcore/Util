using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Steps;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Steps {
    /// <summary>
    /// 步骤测试
    /// </summary>
    public class StepTagHelperTest {
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
        public StepTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new StepTagHelper().ToWrapper();
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
            result.Append( "<nz-step></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step nzTitle=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzTitle]=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试子标题
        /// </summary>
        [Fact]
        public void TestSubtitle() {
            _wrapper.SetContextAttribute( UiConst.Subtitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step nzSubtitle=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试子标题
        /// </summary>
        [Fact]
        public void TestBindSubtitle() {
            _wrapper.SetContextAttribute( AngularConst.BindSubtitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzSubtitle]=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestDescription() {
            _wrapper.SetContextAttribute( UiConst.Description, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step nzDescription=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestBindDescription() {
            _wrapper.SetContextAttribute( AngularConst.BindDescription, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzDescription]=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestIcon() {
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.Alert );
            var result = new StringBuilder();
            result.Append( "<nz-step nzIcon=\"alert\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestBindIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzIcon]=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestStatus() {
            _wrapper.SetContextAttribute( UiConst.Status, StepStatus.Finish );
            var result = new StringBuilder();
            result.Append( "<nz-step nzStatus=\"finish\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestBindStatus() {
            _wrapper.SetContextAttribute( AngularConst.BindStatus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzStatus]=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzDisabled]=\"true\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step [nzDisabled]=\"a\"></nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-step>a</nz-step>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}