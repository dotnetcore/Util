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
            result.Append( "<nz-form-label [nzRequired]=\"true\">code</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"code\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nz-input=\"\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[maxlength]=\"100\" [minlength]=\"10\" [x-required-extend]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 密码类型
        /// </summary>
        [Fact]
        public void TestFor_2() {
	        _wrapper.SetExpression( t => t.Password );
	        var result = new StringBuilder();
	        result.Append( "<nz-form-item>" );
	        result.Append( "<nz-form-label>密码</nz-form-label>" );
	        result.Append( "<nz-form-control>" );
	        result.Append( "<input name=\"password\" nz-input=\"\" type=\"password\" [(ngModel)]=\"model.password\" />" );
	        result.Append( "</nz-form-control>" );
	        result.Append( "</nz-form-item>" );
	        Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 电子邮件验证
        /// </summary>
        [Fact]
        public void TestFor_3() {
            _wrapper.SetExpression( t => t.Email );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>电子邮件</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"电子邮件\" emailMessage=\"email错误\" name=\"email\" " );
            result.Append( "nz-input=\"\" type=\"email\" x-validation-extend=\"\" [(ngModel)]=\"model.email\" [email]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 手机号验证
        /// </summary>
        [Fact]
        public void TestFor_4() {
            _wrapper.SetExpression( t => t.Phone );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>手机号</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"手机号\" name=\"phone\" nz-input=\"\" " );
            result.Append( "pattern=\"^1[0-9]{10}$\" patternMessage=\"手机号错误\" x-validation-extend=\"\" [(ngModel)]=\"model.phone\" [isInvalidPhone]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 身份证验证
        /// </summary>
        [Fact]
        public void TestFor_5() {
            _wrapper.SetExpression( t => t.IdCard );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>身份证</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"身份证\" name=\"idCard\" nz-input=\"\" pattern=\"(^\\d{15}$)|(^\\d{18}$)|(^\\d{17}(\\d|X|x)$)\" " );
            result.Append( "patternMessage=\"身份证错误\" x-validation-extend=\"\" [(ngModel)]=\"model.idCard\" [isInvalidIdCard]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for - 正则验证
        /// </summary>
        [Fact]
        public void TestFor_6() {
            _wrapper.SetExpression( t => t.Regex );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>正则表达式</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"正则表达式\" name=\"regex\" nz-input=\"\" pattern=\"a\" " );
            result.Append( "patternMessage=\"正则表达式错误\" x-validation-extend=\"\" [(ngModel)]=\"model.regex\" />" );
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
        public void TestFor_7() {
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
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"code\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nz-input=\"\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" " );
            result.Append( "[maxlength]=\"100\" [minlength]=\"10\" [x-required-extend]=\"true\" />" );
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

