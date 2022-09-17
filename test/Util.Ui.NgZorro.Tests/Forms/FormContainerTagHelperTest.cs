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
    /// 表单容器测试
    /// </summary>
    public class FormContainerTagHelperTest {
        
        #region 测试初始化

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
        public FormContainerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new FormContainerTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        #endregion

        #region 默认测试

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<ng-container></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Align(垂直对齐方式)

        /// <summary>
        /// 测试设置垂直对齐方式
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
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置垂直对齐方式
        /// </summary>
        [Fact]
        public void TestBindAlign() {
            _wrapper.SetContextAttribute( AngularConst.BindAlign, "a" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item [nzAlign]=\"a\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Gutter(栅格间隔)

        /// <summary>
        /// 测试设置栅格间隔
        /// </summary>
        [Fact]
        public void TestGutter() {
            _wrapper.SetContextAttribute( UiConst.Gutter, "2" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item [nzGutter]=\"2\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Justify(水平排列方式)

        /// <summary>
        /// 测试设置水平排列方式
        /// </summary>
        [Fact]
        public void TestJustify() {
            _wrapper.SetContextAttribute( UiConst.Justify, Justify.Center );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item nzJustify=\"center\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置水平排列方式
        /// </summary>
        [Fact]
        public void TestBindJustify() {
            _wrapper.SetContextAttribute( AngularConst.BindJustify, "a" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item [nzJustify]=\"a\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签常规栅格测试

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
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签跨度 - 全部form label都会被设置
        /// </summary>
        [Fact]
        public void TestLabelSpan_2() {
            _wrapper.SetContextAttribute( UiConst.LabelSpan, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var formItem2 = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem2 );

            var formLabel2 = new FormLabelTagHelper().ToWrapper();
            formLabel2.AppendContent( "b" );
            formItem2.AppendContent( formLabel2 );

            var formControl2 = new FormControlTagHelper().ToWrapper();
            formControl2.AppendContent( new InputTagHelper() );
            formItem2.AppendContent( formControl2 );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">b</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签跨度,表单先设置,使用表单容器进行覆盖
        /// </summary>
        [Fact]
        public void TestLabelSpan_3() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.LabelSpan, 2 );

            _wrapper.SetContextAttribute( UiConst.LabelSpan, 3 );
            form.AppendContent( _wrapper );

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
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试设置标签跨度,添加两个输入框,一个自动创建nz-form-item,一个手工创建
        /// </summary>
        [Fact]
        public void TestLabelSpan_4() {
            _wrapper.SetContextAttribute( UiConst.LabelSpan, 3 );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelText, "a" );
            _wrapper.AppendContent( input );

            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
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
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzOffset]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelOrder, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzOrder]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签栅格左移
        /// </summary>
        [Fact]
        public void TestLabelPull() {
            _wrapper.SetContextAttribute( UiConst.LabelPull, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzPull]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签栅格右移
        /// </summary>
        [Fact]
        public void TestLabelPush() {
            _wrapper.SetContextAttribute( UiConst.LabelPush, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzPush]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签Flex布局
        /// </summary>
        [Fact]
        public void TestLabelFlex() {
            _wrapper.SetContextAttribute( UiConst.LabelFlex, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzFlex]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签超窄尺寸栅格测试

        /// <summary>
        /// 测试标签超窄尺寸栅格
        /// </summary>
        [Fact]
        public void TestLabelXs_1() {
            _wrapper.SetContextAttribute( UiConst.LabelXs, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"b\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestLabelXs_2() {
            _wrapper.SetContextAttribute( UiConst.LabelXs, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelXs, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸栅格,表单标签覆盖
        /// </summary>
        [Fact]
        public void TestLabelXs_3() {
            _wrapper.SetContextAttribute( UiConst.LabelXs, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Xs, "c" );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestLabelXsSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelXsSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"{span:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestLabelXsOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelXsOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"{offset:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelXsOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelXsOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"{order:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestLabelXsPull() {
            _wrapper.SetContextAttribute( UiConst.LabelXsPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"{pull:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超窄尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestLabelXsPush() {
            _wrapper.SetContextAttribute( UiConst.LabelXsPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXs]=\"{push:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签窄尺寸栅格测试

        /// <summary>
        /// 测试标签窄尺寸栅格
        /// </summary>
        [Fact]
        public void TestLabelSm_1() {
            _wrapper.SetContextAttribute( UiConst.LabelSm, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"b\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestLabelSm_2() {
            _wrapper.SetContextAttribute( UiConst.LabelSm, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelSm, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸栅格,表单标签覆盖
        /// </summary>
        [Fact]
        public void TestLabelSm_3() {
            _wrapper.SetContextAttribute( UiConst.LabelSm, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Sm, "c" );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestLabelSmSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelSmSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"{span:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestLabelSmOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelSmOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"{offset:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelSmOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelSmOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"{order:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestLabelSmPull() {
            _wrapper.SetContextAttribute( UiConst.LabelSmPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"{pull:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签窄尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestLabelSmPush() {
            _wrapper.SetContextAttribute( UiConst.LabelSmPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSm]=\"{push:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签中尺寸栅格测试

        /// <summary>
        /// 测试标签中尺寸栅格
        /// </summary>
        [Fact]
        public void TestLabelMd_1() {
            _wrapper.SetContextAttribute( UiConst.LabelMd, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"b\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestLabelMd_2() {
            _wrapper.SetContextAttribute( UiConst.LabelMd, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelMd, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸栅格,表单标签覆盖
        /// </summary>
        [Fact]
        public void TestLabelMd_3() {
            _wrapper.SetContextAttribute( UiConst.LabelMd, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Md, "c" );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestLabelMdSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelMdSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"{span:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestLabelMdOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelMdOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"{offset:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelMdOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelMdOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"{order:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestLabelMdPull() {
            _wrapper.SetContextAttribute( UiConst.LabelMdPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"{pull:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签中尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestLabelMdPush() {
            _wrapper.SetContextAttribute( UiConst.LabelMdPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzMd]=\"{push:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签宽尺寸栅格测试

        /// <summary>
        /// 测试标签宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestLabelLg_1() {
            _wrapper.SetContextAttribute( UiConst.LabelLg, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"b\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestLabelLg_2() {
            _wrapper.SetContextAttribute( UiConst.LabelLg, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelLg, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸栅格,表单标签覆盖
        /// </summary>
        [Fact]
        public void TestLabelLg_3() {
            _wrapper.SetContextAttribute( UiConst.LabelLg, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Lg, "c" );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestLabelLgSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelLgSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"{span:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestLabelLgOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelLgOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"{offset:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelLgOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelLgOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"{order:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestLabelLgPull() {
            _wrapper.SetContextAttribute( UiConst.LabelLgPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"{pull:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签宽尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestLabelLgPush() {
            _wrapper.SetContextAttribute( UiConst.LabelLgPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzLg]=\"{push:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签超宽尺寸栅格测试

        /// <summary>
        /// 测试标签超宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestLabelXl_1() {
            _wrapper.SetContextAttribute( UiConst.LabelXl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"b\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestLabelXl_2() {
            _wrapper.SetContextAttribute( UiConst.LabelXl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelXl, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸栅格,表单标签覆盖
        /// </summary>
        [Fact]
        public void TestLabelXl_3() {
            _wrapper.SetContextAttribute( UiConst.LabelXl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Xl, "c" );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestLabelXlSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelXlSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"{span:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestLabelXlOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelXlOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"{offset:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelXlOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelXlOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"{order:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestLabelXlPull() {
            _wrapper.SetContextAttribute( UiConst.LabelXlPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"{pull:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签超宽尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestLabelXlPush() {
            _wrapper.SetContextAttribute( UiConst.LabelXlPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXl]=\"{push:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单标签极宽尺寸栅格测试

        /// <summary>
        /// 测试标签极宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestLabelXxl_1() {
            _wrapper.SetContextAttribute( UiConst.LabelXxl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"b\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestLabelXxl_2() {
            _wrapper.SetContextAttribute( UiConst.LabelXxl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelXxl, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸栅格,表单标签覆盖
        /// </summary>
        [Fact]
        public void TestLabelXxl_3() {
            _wrapper.SetContextAttribute( UiConst.LabelXxl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.SetContextAttribute( UiConst.Xxl, "c" );
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"c\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestLabelXxlSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelXxlSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"{span:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestLabelXxlOffset() {
            _wrapper.SetContextAttribute( UiConst.LabelXxlOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"{offset:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestLabelXxlOrder() {
            _wrapper.SetContextAttribute( UiConst.LabelXxlOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"{order:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestLabelXxlPull() {
            _wrapper.SetContextAttribute( UiConst.LabelXxlPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"{pull:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签极宽尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestLabelXxlPush() {
            _wrapper.SetContextAttribute( UiConst.LabelXxlPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzXXl]=\"{push:1}\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件常规栅格测试

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
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置控件跨度 - 全部form control都会被设置
        /// </summary>
        [Fact]
        public void TestControlSpan_2() {
            _wrapper.SetContextAttribute( UiConst.ControlSpan, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var formItem2 = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem2 );

            var formLabel2 = new FormLabelTagHelper().ToWrapper();
            formLabel2.AppendContent( "b" );
            formItem2.AppendContent( formLabel2 );

            var formControl2 = new FormControlTagHelper().ToWrapper();
            formControl2.AppendContent( new InputTagHelper() );
            formItem2.AppendContent( formControl2 );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>b</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置控件跨度,表单先设置,使用表单容器进行覆盖
        /// </summary>
        [Fact]
        public void TestControlSpan_3() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.ControlSpan, 2 );

            _wrapper.SetContextAttribute( UiConst.ControlSpan, 3 );
            form.AppendContent( _wrapper );

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
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试设置控件偏移量
        /// </summary>
        [Fact]
        public void TestControlOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlOffset, 3 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzOffset]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件超窄尺寸栅格测试

        /// <summary>
        /// 测试控件超窄尺寸栅格
        /// </summary>
        [Fact]
        public void TestControlXs_1() {
            _wrapper.SetContextAttribute( UiConst.ControlXs, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlXs_2() {
            _wrapper.SetContextAttribute( UiConst.ControlXs, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.ControlXs, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlXs_3() {
            _wrapper.SetContextAttribute( UiConst.ControlXs, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Xs, "c" );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestControlXsSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlXsSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"{span:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestControlXsOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlXsOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"{offset:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestControlXsOrder() {
            _wrapper.SetContextAttribute( UiConst.ControlXsOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"{order:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestControlXsPull() {
            _wrapper.SetContextAttribute( UiConst.ControlXsPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"{pull:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超窄尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestControlXsPush() {
            _wrapper.SetContextAttribute( UiConst.ControlXsPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXs]=\"{push:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件窄尺寸栅格测试

        /// <summary>
        /// 测试控件窄尺寸栅格
        /// </summary>
        [Fact]
        public void TestControlSm_1() {
            _wrapper.SetContextAttribute( UiConst.ControlSm, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlSm_2() {
            _wrapper.SetContextAttribute( UiConst.ControlSm, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.ControlSm, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlSm_3() {
            _wrapper.SetContextAttribute( UiConst.ControlSm, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Sm, "c" );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestControlSmSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlSmSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"{span:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestControlSmOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlSmOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"{offset:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestControlSmOrder() {
            _wrapper.SetContextAttribute( UiConst.ControlSmOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"{order:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestControlSmPull() {
            _wrapper.SetContextAttribute( UiConst.ControlSmPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"{pull:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件窄尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestControlSmPush() {
            _wrapper.SetContextAttribute( UiConst.ControlSmPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSm]=\"{push:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件中尺寸栅格测试

        /// <summary>
        /// 测试控件中尺寸栅格
        /// </summary>
        [Fact]
        public void TestControlMd_1() {
            _wrapper.SetContextAttribute( UiConst.ControlMd, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlMd_2() {
            _wrapper.SetContextAttribute( UiConst.ControlMd, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.ControlMd, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlMd_3() {
            _wrapper.SetContextAttribute( UiConst.ControlMd, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Md, "c" );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestControlMdSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlMdSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"{span:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestControlMdOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlMdOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"{offset:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestControlMdOrder() {
            _wrapper.SetContextAttribute( UiConst.ControlMdOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"{order:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestControlMdPull() {
            _wrapper.SetContextAttribute( UiConst.ControlMdPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"{pull:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件中尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestControlMdPush() {
            _wrapper.SetContextAttribute( UiConst.ControlMdPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzMd]=\"{push:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件宽尺寸栅格测试

        /// <summary>
        /// 测试控件宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestControlLg_1() {
            _wrapper.SetContextAttribute( UiConst.ControlLg, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlLg_2() {
            _wrapper.SetContextAttribute( UiConst.ControlLg, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.ControlLg, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlLg_3() {
            _wrapper.SetContextAttribute( UiConst.ControlLg, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Lg, "c" );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestControlLgSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlLgSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"{span:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestControlLgOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlLgOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"{offset:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestControlLgOrder() {
            _wrapper.SetContextAttribute( UiConst.ControlLgOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"{order:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestControlLgPull() {
            _wrapper.SetContextAttribute( UiConst.ControlLgPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"{pull:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件宽尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestControlLgPush() {
            _wrapper.SetContextAttribute( UiConst.ControlLgPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzLg]=\"{push:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件超宽尺寸栅格测试

        /// <summary>
        /// 测试控件超宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestControlXl_1() {
            _wrapper.SetContextAttribute( UiConst.ControlXl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlXl_2() {
            _wrapper.SetContextAttribute( UiConst.ControlXl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.ControlXl, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlXl_3() {
            _wrapper.SetContextAttribute( UiConst.ControlXl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Xl, "c" );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestControlXlSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlXlSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"{span:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestControlXlOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlXlOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"{offset:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestControlXlOrder() {
            _wrapper.SetContextAttribute( UiConst.ControlXlOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"{order:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestControlXlPull() {
            _wrapper.SetContextAttribute( UiConst.ControlXlPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"{pull:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件超宽尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestControlXlPush() {
            _wrapper.SetContextAttribute( UiConst.ControlXlPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXl]=\"{push:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region 表单控件极宽尺寸栅格测试

        /// <summary>
        /// 测试控件极宽尺寸栅格
        /// </summary>
        [Fact]
        public void TestControlXxl_1() {
            _wrapper.SetContextAttribute( UiConst.ControlXxl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlXxl_2() {
            _wrapper.SetContextAttribute( UiConst.ControlXxl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.ControlXxl, "c" );
            formControl.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸栅格,表单控件覆盖
        /// </summary>
        [Fact]
        public void TestControlXxl_3() {
            _wrapper.SetContextAttribute( UiConst.ControlXxl, "b" );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.SetContextAttribute( UiConst.Xxl, "c" );
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"c\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸响应式栅格跨度
        /// </summary>
        [Fact]
        public void TestControlXxlSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlXxlSpan, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"{span:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸响应式栅格偏移量
        /// </summary>
        [Fact]
        public void TestControlXxlOffset() {
            _wrapper.SetContextAttribute( UiConst.ControlXxlOffset, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"{offset:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸响应式栅格顺序
        /// </summary>
        [Fact]
        public void TestControlXxlOrder() {
            _wrapper.SetContextAttribute( UiConst.ControlXxlOrder, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"{order:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸响应式栅格左移
        /// </summary>
        [Fact]
        public void TestControlXxlPull() {
            _wrapper.SetContextAttribute( UiConst.ControlXxlPull, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"{pull:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件极宽尺寸响应式栅格右移
        /// </summary>
        [Fact]
        public void TestControlXxlPush() {
            _wrapper.SetContextAttribute( UiConst.ControlXxlPush, 1 );
            var formItem = new FormItemTagHelper().ToWrapper();
            _wrapper.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( new InputTagHelper() );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzXXl]=\"{push:1}\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}