using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 表达式解析测试
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">编码</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"编码\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nz-input=\"\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[maxlength]=\"100\" [minlength]=\"10\" [required]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 手工设置容器组件
        /// </summary>
        [Fact]
        public void TestFor_2() {
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

            _wrapper.SetExpression( t => t.Code );
            formControl.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<form nz-form=\"\">" );
            result.Append( "<ng-container>" );
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control [nzSpan]=\"3\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"编码\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nz-input=\"\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[maxlength]=\"100\" [minlength]=\"10\" [required]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            result.Append( "</ng-container>" );
            result.Append( "</form>" );
            Assert.Equal( result.ToString(), form.GetResult() );
        }
    }
}

