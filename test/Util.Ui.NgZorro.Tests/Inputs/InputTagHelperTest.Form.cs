using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 表单结构相关
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试垂直对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            _wrapper.SetContextAttribute( UiConst.Align, Align.Middle );
            var result = new StringBuilder();
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外提示
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control nzExtra=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
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
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzExtra]=\"'a'|i18n\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试额外提示
        /// </summary>
        [Fact]
        public void TestBindExtra() {
            _wrapper.SetContextAttribute( AngularConst.BindExtra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzExtra]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验成功状态提示
        /// </summary>
        [Fact]
        public void TestSuccessTip() {
            _wrapper.SetContextAttribute( UiConst.SuccessTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control nzSuccessTip=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验警告状态提示
        /// </summary>
        [Fact]
        public void TestWarningTip() {
            _wrapper.SetContextAttribute( UiConst.WarningTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control nzWarningTip=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验错误状态提示
        /// </summary>
        [Fact]
        public void TestErrorTip() {
            _wrapper.SetContextAttribute( UiConst.ErrorTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control nzErrorTip=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试校验中状态提示
        /// </summary>
        [Fact]
        public void TestValidatingTip() {
            _wrapper.SetContextAttribute( UiConst.ValidatingTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control nzValidatingTip=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签文本
        /// </summary>
        [Fact]
        public void TestLabelText() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单独设置标签跨度,不会创建表单结构
        /// </summary>
        [Fact]
        public void TestLabelSpan() {
            _wrapper.SetContextAttribute( UiConst.LabelSpan, 3 );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同时设置标签文本和标签跨度
        /// </summary>
        [Fact]
        public void TestLabelSpan_2() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" ).SetContextAttribute( UiConst.LabelSpan, 3 );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"3\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签跨度,手工创建nz-form-label
        /// </summary>
        [Fact]
        public void TestLabelSpan_3() {
            var form = new FormTagHelper().ToWrapper();
            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            _wrapper.SetContextAttribute( UiConst.LabelSpan, 3 );
            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( _wrapper );
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
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试设置表单和表单容器标签跨度,进行覆盖
        /// </summary>
        [Fact]
        public void TestLabelSpan_4() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.LabelSpan, 2 );

            var formContainer = new FormContainerTagHelper().ToWrapper();
            formContainer.SetContextAttribute( UiConst.LabelSpan, 3 );
            form.AppendContent( formContainer );

            var formItem = new FormItemTagHelper().ToWrapper();
            formContainer.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            _wrapper.SetContextAttribute( UiConst.LabelSpan,5 );
            formControl.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"5\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试设置表单标签跨度,手工创建form-control,自动创建form-label,继承容器属性
        /// </summary>
        [Fact]
        public void TestLabelSpan_5() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.LabelSpan, 2 );

            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            formControl.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzSpan]=\"2\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), GetResult( form ) );
        }

        /// <summary>
        /// 测试控件跨度 - 默认会自动创建nz-form-control,nz-form-item
        /// </summary>
        [Fact]
        public void TestControlSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlSpan, 3 );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置控件跨度 - 手工创建nz-form-item,自动创建nz-form-control
        /// </summary>
        [Fact]
        public void TestControlSpan_2() {
            var formItem = new FormItemTagHelper().ToWrapper();

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            _wrapper.SetContextAttribute( UiConst.ControlSpan, 3 );
            formItem.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), formItem.GetResult() );
        }

        /// <summary>
        /// 测试设置控件跨度 - 手工创建nz-form-item,nz-form-control
        /// </summary>
        [Fact]
        public void TestControlSpan_3() {
            var form = new FormTagHelper().ToWrapper();
            
            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            var formControl = new FormControlTagHelper().ToWrapper();
            formItem.AppendContent( formControl );

            _wrapper.SetContextAttribute( UiConst.ControlSpan, 3 );
            formControl.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试设置表单和表单容器标签跨度,进行覆盖
        /// </summary>
        [Fact]
        public void TestControlSpan_4() {
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
            formItem.AppendContent( formControl );

            _wrapper.SetContextAttribute( UiConst.ControlSpan, 5 );
            formControl.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"5\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试自动设置表单标签的 nzFor 属性,不会自动创建表单标签
        /// </summary>
        [Fact]
        public void TestAutoLabelFor() {
            _wrapper.SetContextAttribute( UiConst.AutoLabelFor, true );
            var result = new StringBuilder();
            result.Append( "<input id=\"control_id\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动创建控件Id,并设置标签for
        /// </summary>
        [Fact]
        public void TestAutoLabelFor_2() {
            var form = new FormTagHelper().ToWrapper();
            
            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            _wrapper.SetContextAttribute( UiConst.AutoLabelFor, true );
            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( _wrapper );
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
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试手工设置控件Id,并设置标签for
        /// </summary>
        [Fact]
        public void TestAutoLabelFor_3() {
            var form = new FormTagHelper().ToWrapper();
            
            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            _wrapper.SetContextAttribute( AngularConst.RawId, "a" );
            _wrapper.SetContextAttribute( UiConst.AutoLabelFor, true );
            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( _wrapper );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label nzFor=\"a\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input id=\"a\" nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试表单设置标签for,表单控件取消设置
        /// </summary>
        [Fact]
        public void TestAutoLabelFor_4() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.AutoLabelFor, true );
            
            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formLabel = new FormLabelTagHelper().ToWrapper();
            formLabel.AppendContent( "a" );
            formItem.AppendContent( formLabel );

            _wrapper.SetContextAttribute( UiConst.AutoLabelFor, false );
            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( _wrapper );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试同时设置标签文本和标签for
        /// </summary>
        [Fact]
        public void TestAutoLabelFor_5() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" ).SetContextAttribute( UiConst.AutoLabelFor, true );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label nzFor=\"control_id\">a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input id=\"control_id\" nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

