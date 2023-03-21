using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Forms {
    /// <summary>
    /// 表单域测试
    /// </summary>
    public class FormControlTagHelperTest {
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
        public FormControlTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new FormControlTagHelper().ToWrapper();
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
            result.Append( "<nz-form-control></nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验状态
        /// </summary>
        [Fact]
        public void TestValidateStatus() {
            _wrapper.SetContextAttribute( UiConst.ValidateStatus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzValidateStatus]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试展示校验状态图标
        /// </summary>
        [Fact]
        public void TestHasFeedback() {
            _wrapper.SetContextAttribute( UiConst.HasFeedback, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzHasFeedback]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外提示
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzExtra=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外提示 - 多语言
        /// </summary>
        [Fact]
        public void TestExtra_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzExtra]=\"'a'|i18n\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外提示
        /// </summary>
        [Fact]
        public void TestBindExtra() {
            _wrapper.SetContextAttribute( AngularConst.BindExtra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzExtra]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验成功状态提示
        /// </summary>
        [Fact]
        public void TestSuccessTip() {
            _wrapper.SetContextAttribute( UiConst.SuccessTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzSuccessTip=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验成功状态提示
        /// </summary>
        [Fact]
        public void TestBindSuccessTip() {
            _wrapper.SetContextAttribute( AngularConst.BindSuccessTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzSuccessTip]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验警告状态提示
        /// </summary>
        [Fact]
        public void TestWarningTip() {
            _wrapper.SetContextAttribute( UiConst.WarningTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzWarningTip=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验警告状态提示
        /// </summary>
        [Fact]
        public void TestBindWarningTip() {
            _wrapper.SetContextAttribute( AngularConst.BindWarningTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzWarningTip]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验错误状态提示
        /// </summary>
        [Fact]
        public void TestErrorTip() {
            _wrapper.SetContextAttribute( UiConst.ErrorTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzErrorTip=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验错误状态提示
        /// </summary>
        [Fact]
        public void TestBindErrorTip() {
            _wrapper.SetContextAttribute( AngularConst.BindErrorTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzErrorTip]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验中状态提示
        /// </summary>
        [Fact]
        public void TestValidatingTip() {
            _wrapper.SetContextAttribute( UiConst.ValidatingTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzValidatingTip=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验中状态提示
        /// </summary>
        [Fact]
        public void TestBindValidatingTip() {
            _wrapper.SetContextAttribute( AngularConst.BindValidatingTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzValidatingTip]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动提示
        /// </summary>
        [Fact]
        public void TestAutoTips() {
            _wrapper.SetContextAttribute( UiConst.AutoTips, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzAutoTips]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用自动提示
        /// </summary>
        [Fact]
        public void TestDisableAutoTips() {
            _wrapper.SetContextAttribute( UiConst.DisableAutoTips, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzDisableAutoTips]=\"true\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control>a</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            _wrapper.SetContextAttribute( UiConst.Span, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzSpan=\"1\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置表单和表单容器控件跨度,使用控件属性进行覆盖
        /// </summary>
        [Fact]
        public void TestSpan_2() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.ControlSpan, 2 );

            var formContainer = new FormContainerTagHelper().ToWrapper();
            formContainer.SetContextAttribute( UiConst.ControlSpan, 3 );
            form.AppendContent( formContainer );

            var formItem = new FormItemTagHelper().ToWrapper();
            formContainer.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Span, 5 );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control nzSpan=\"5\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestBindSpan() {
            _wrapper.SetContextAttribute( AngularConst.BindSpan, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzSpan]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestOffset() {
            _wrapper.SetContextAttribute( UiConst.Offset, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzOffset=\"1\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestBindOffset() {
            _wrapper.SetContextAttribute( AngularConst.BindOffset, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzOffset]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左移
        /// </summary>
        [Fact]
        public void TestPull() {
            _wrapper.SetContextAttribute( UiConst.Pull, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzPull=\"1\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左移
        /// </summary>
        [Fact]
        public void TestBindPull() {
            _wrapper.SetContextAttribute( AngularConst.BindPull, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzPull]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右移
        /// </summary>
        [Fact]
        public void TestPush() {
            _wrapper.SetContextAttribute( UiConst.Push, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzPush=\"1\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右移
        /// </summary>
        [Fact]
        public void TestBindPush() {
            _wrapper.SetContextAttribute( AngularConst.BindPush, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzPush]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestOrder() {
            _wrapper.SetContextAttribute( UiConst.Order, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzOrder=\"1\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestBindOrder() {
            _wrapper.SetContextAttribute( AngularConst.BindOrder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzOrder]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试flex布局
        /// </summary>
        [Fact]
        public void TestFlex() {
            _wrapper.SetContextAttribute( UiConst.Flex, "1" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control nzFlex=\"1\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试flex布局
        /// </summary>
        [Fact]
        public void TestBindFlex() {
            _wrapper.SetContextAttribute( AngularConst.BindFlex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzFlex]=\"a\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXsSpan() {
            _wrapper.SetContextAttribute( UiConst.XsSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzXs]=\"{span:1}\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestSmSpan() {
            _wrapper.SetContextAttribute( UiConst.SmSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzSm]=\"{span:1}\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestMdSpan() {
            _wrapper.SetContextAttribute( UiConst.MdSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzMd]=\"{span:1}\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestLgSpan() {
            _wrapper.SetContextAttribute( UiConst.LgSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzLg]=\"{span:1}\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXlSpan() {
            _wrapper.SetContextAttribute( UiConst.XlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzXl]=\"{span:1}\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXxlSpan() {
            _wrapper.SetContextAttribute( UiConst.XxlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-control [nzXXl]=\"{span:1}\">" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}