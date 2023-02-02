using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Forms {
    /// <summary>
    /// 表单标签测试
    /// </summary>
    public class FormLabelTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FormLabelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new FormLabelTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-form-label></nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填样式
        /// </summary>
        [Fact]
        public void TestRequired() {
            _wrapper.SetContextAttribute( UiConst.Required, true );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzRequired]=\"true\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填样式
        /// </summary>
        [Fact]
        public void TestBindRequired() {
            _wrapper.SetContextAttribute( AngularConst.BindRequired, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzRequired]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不显示冒号
        /// </summary>
        [Fact]
        public void TestNoColon() {
            _wrapper.SetContextAttribute( UiConst.NoColon, true );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzNoColon]=\"true\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不显示冒号
        /// </summary>
        [Fact]
        public void TestBindNoColon() {
            _wrapper.SetContextAttribute( AngularConst.BindNoColon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzNoColon]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签for
        /// </summary>
        [Fact]
        public void TestLabelFor() {
            _wrapper.SetContextAttribute( UiConst.LabelFor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzFor=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签for
        /// </summary>
        [Fact]
        public void TestBindLabelFor() {
            _wrapper.SetContextAttribute( AngularConst.BindLabelFor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzFor]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示信息
        /// </summary>
        [Fact]
        public void TestTooltipTitle() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzTooltipTitle=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示信息
        /// </summary>
        [Fact]
        public void TestBindTooltipTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzTooltipTitle]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示图标
        /// </summary>
        [Fact]
        public void TestTooltipIcon() {
            _wrapper.SetContextAttribute( UiConst.TooltipIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzTooltipIcon=\"account-book\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示图标
        /// </summary>
        [Fact]
        public void TestBindTooltipIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzTooltipIcon]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            _wrapper.SetContextAttribute( UiConst.Span, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzSpan=\"1\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置表单和表单容器标签跨度,使用标签属性进行覆盖
        /// </summary>
        [Fact]
        public void TestSpan_2() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.LabelSpan, 2 );

            var formContainer = new FormContainerTagHelper().ToWrapper();
            formContainer.SetContextAttribute( UiConst.LabelSpan, 3 );
            form.AppendContent( formContainer );

            var formItem = new FormItemTagHelper().ToWrapper();
            formContainer.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Span, 5 );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label nzSpan=\"5\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
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
            result.Append( "<nz-form-label [nzSpan]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestOffset() {
            _wrapper.SetContextAttribute( UiConst.Offset, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzOffset=\"1\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestBindOffset() {
            _wrapper.SetContextAttribute( AngularConst.BindOffset, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzOffset]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左移
        /// </summary>
        [Fact]
        public void TestPull() {
            _wrapper.SetContextAttribute( UiConst.Pull, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzPull=\"1\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试左移
        /// </summary>
        [Fact]
        public void TestBindPull() {
            _wrapper.SetContextAttribute( AngularConst.BindPull, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzPull]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右移
        /// </summary>
        [Fact]
        public void TestPush() {
            _wrapper.SetContextAttribute( UiConst.Push, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzPush=\"1\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右移
        /// </summary>
        [Fact]
        public void TestBindPush() {
            _wrapper.SetContextAttribute( AngularConst.BindPush, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzPush]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestOrder() {
            _wrapper.SetContextAttribute( UiConst.Order, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzOrder=\"1\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试栅格顺序
        /// </summary>
        [Fact]
        public void TestBindOrder() {
            _wrapper.SetContextAttribute( AngularConst.BindOrder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzOrder]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试flex布局
        /// </summary>
        [Fact]
        public void TestFlex() {
            _wrapper.SetContextAttribute( UiConst.Flex, "1" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label nzFlex=\"1\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试flex布局
        /// </summary>
        [Fact]
        public void TestBindFlex() {
            _wrapper.SetContextAttribute( AngularConst.BindFlex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzFlex]=\"a\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超窄尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXsSpan() {
            _wrapper.SetContextAttribute( UiConst.XsSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzXs]=\"{span:1}\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试窄尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestSmSpan() {
            _wrapper.SetContextAttribute( UiConst.SmSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzSm]=\"{span:1}\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试中尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestMdSpan() {
            _wrapper.SetContextAttribute( UiConst.MdSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzMd]=\"{span:1}\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestLgSpan() {
            _wrapper.SetContextAttribute( UiConst.LgSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzLg]=\"{span:1}\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试超宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXlSpan() {
            _wrapper.SetContextAttribute( UiConst.XlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzXl]=\"{span:1}\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试极宽尺寸栅格跨度
        /// </summary>
        [Fact]
        public void TestXxlSpan() {
            _wrapper.SetContextAttribute( UiConst.XxlSpan, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzXXl]=\"{span:1}\">" );
            result.Append( "</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label>a</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本 - 多语言
        /// </summary>
        [Fact]
        public void TestText_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-label>{{'a'|i18n}}</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式
        /// </summary>
        [Fact]
        public void TestFor() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzRequired]=\"true\">code</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 多语言
        /// </summary>
        [Fact]
        public void TestFor_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-label [nzRequired]=\"true\">{{'code'|i18n}}</nz-form-label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}