using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Util.Ui.NgZorro.Components.InputNumbers;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.InputNumbers {
    /// <summary>
    /// 数字输入框测试 - 测试属性覆盖
    /// </summary>
    public partial class InputNumberTagHelperTest {
        /// <summary>
        /// 测试垂直对齐方式 - form设置垂直对齐方式,formitem覆盖
        /// </summary>
        [Fact]
        public void TestAlign_Override_1() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.Align, Align.Bottom );

            var formItem = new FormItemTagHelper().ToWrapper();
            formItem.SetContextAttribute( UiConst.Align, Align.Middle );
            form.AppendContent( formItem );

            var formControl = new FormControlTagHelper().ToWrapper();
            formControl.AppendContent( _wrapper );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试垂直对齐方式 - form设置垂直对齐方式,数字输入框覆盖
        /// </summary>
        [Fact]
        public void TestAlign_Override_2() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.Align, Align.Bottom );

            var formItem = new FormItemTagHelper().ToWrapper();
            form.AppendContent( formItem );

            var formControl = new FormControlTagHelper().ToWrapper();
            _wrapper.SetContextAttribute( UiConst.Align, Align.Middle );
            formControl.AppendContent( _wrapper );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试垂直对齐方式 - form设置垂直对齐方式,formitem覆盖,数字输入框覆盖,formitem优先级最高
        /// </summary>
        [Fact]
        public void TestAlign_Override_3() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.Align, Align.Bottom );

            var formItem = new FormItemTagHelper().ToWrapper();
            formItem.SetContextAttribute( UiConst.Align, Align.Middle );
            form.AppendContent( formItem );

            var formControl = new FormControlTagHelper().ToWrapper();
            _wrapper.SetContextAttribute( UiConst.Align, Align.Top );
            formControl.AppendContent( _wrapper );
            formItem.AppendContent( formControl );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试垂直对齐方式 - 两个组件
        /// </summary>
        [Fact]
        public void TestAlign_Override_4() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.Align, Align.Bottom );

            _wrapper.SetContextAttribute( UiConst.Align, Align.Middle );
            form.AppendContent( _wrapper );

            var input = new InputNumberTagHelper().ToWrapper();
            form.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );

            result.Append( "<nz-form-item nzAlign=\"bottom\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );

            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }

        /// <summary>
        /// 测试垂直对齐方式 - 两个组件,其中一个的formitem手工创建
        /// </summary>
        [Fact]
        public void TestAlign_Override_5() {
            var form = new FormTagHelper().ToWrapper();
            form.SetContextAttribute( UiConst.Align, Align.Bottom );

            var formItem = new FormItemTagHelper().ToWrapper();
            formItem.SetContextAttribute( UiConst.Align, Align.Middle );
            form.AppendContent( formItem );

            var formControl = new FormControlTagHelper().ToWrapper();
            _wrapper.SetContextAttribute( UiConst.Align, Align.Top );
            formControl.AppendContent( _wrapper );
            formItem.AppendContent( formControl );

            var input = new InputNumberTagHelper().ToWrapper();
            form.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<nz-form-item nzAlign=\"middle\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );

            result.Append( "<nz-form-item nzAlign=\"bottom\">" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-number></nz-input-number>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );

            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }
    }
}

