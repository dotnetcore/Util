using System.Text;
using Util.Helpers;
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
    /// 表单测试
    /// </summary>
    public class FormTagHelperTest {
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
        public FormTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new FormTagHelper().ToWrapper();
            Id.SetId( "id" );
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
            result.Append( "<form nz-form=\"\"></form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<form #a=\"ngForm\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试布局
        /// </summary>
        [Fact]
        public void TestLayout() {
            _wrapper.SetContextAttribute( UiConst.Layout, FormLayout.Inline );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" nzLayout=\"inline\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试布局
        /// </summary>
        [Fact]
        public void TestBindLayout() {
            _wrapper.SetContextAttribute( AngularConst.BindLayout, "a" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [nzLayout]=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动提示
        /// </summary>
        [Fact]
        public void TestAutoTips() {
            _wrapper.SetContextAttribute( UiConst.AutoTips, "a" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [nzAutoTips]=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用自动提示
        /// </summary>
        [Fact]
        public void TestDisableAutoTips() {
            _wrapper.SetContextAttribute( UiConst.DisableAutoTips, "true" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [nzDisableAutoTips]=\"true\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不显示标签冒号
        /// </summary>
        [Fact]
        public void TestNoColon() {
            _wrapper.SetContextAttribute( UiConst.NoColon, true );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [nzNoColon]=\"true\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试不显示标签冒号
        /// </summary>
        [Fact]
        public void TestBindNoColon() {
            _wrapper.SetContextAttribute( AngularConst.BindNoColon, "a" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [nzNoColon]=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签提示图标
        /// </summary>
        [Fact]
        public void TestTooltipIcon() {
            _wrapper.SetContextAttribute( UiConst.TooltipIcon, AntDesignIcon.AlignCenter );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" nzTooltipIcon=\"align-center\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签提示图标
        /// </summary>
        [Fact]
        public void TestBindTooltipIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindTooltipIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [nzTooltipIcon]=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动完成打开
        /// </summary>
        [Fact]
        public void TestAutoComplete_On() {
            _wrapper.SetContextAttribute( UiConst.Autocomplete, true );
            var result = new StringBuilder();
            result.Append( "<form autocomplete=\"on\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动完成关闭
        /// </summary>
        [Fact]
        public void TestAutoComplete_Off() {
            _wrapper.SetContextAttribute( UiConst.Autocomplete, false );
            var result = new StringBuilder();
            result.Append( "<form autocomplete=\"off\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表单组
        /// </summary>
        [Fact]
        public void TestFormGroup() {
            _wrapper.SetContextAttribute( UiConst.FormGroup, "a" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\" [formGroup]=\"a\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">a</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提交事件
        /// </summary>
        [Fact]
        public void TestOnSubmit() {
            _wrapper.SetContextAttribute( UiConst.OnSubmit, "a" );
            var result = new StringBuilder();
            result.Append( "<form (ngSubmit)=\"a\" nz-form=\"\">" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动设置标签for
        /// </summary>
        [Fact]
        public void TestAutoLabelFor() {
            _wrapper.SetContextAttribute( UiConst.AutoLabelFor, true );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label nzFor=\"control_id\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input id=\"control_id\" nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签跨度
        /// </summary>
        [Fact]
        public void TestLabelSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelSpan, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );
            
            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签偏移量
        /// </summary>
        [Fact]
        public void TestLabelOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelOffset, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzOffset]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置控件跨度
        /// </summary>
        [Fact]
        public void TestControlSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlSpan, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置垂直对齐方式 - 手工创建formitem
        /// </summary>
        [Fact]
        public void TestAlign() {
            _wrapper.SetContextAttribute( UiConst.Align, Align.Middle );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置垂直对齐方式 - 自动生成formitem
        /// </summary>
        [Fact]
        public void TestAlign_2() {
            _wrapper.SetContextAttribute( UiConst.Align, Align.Middle );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelText, "a" );
            _wrapper.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}