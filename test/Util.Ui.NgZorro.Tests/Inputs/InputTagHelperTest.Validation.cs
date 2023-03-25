using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 验证测试
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试必填项验证
        /// </summary>
        [Fact]
        public void TestRequired() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填项验证 - 设置ErrorTip
        /// </summary>
        [Fact]
        public void TestRequired_ErrorTip() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( UiConst.ErrorTip, "a" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control nzErrorTip=\"a\">" );
            result.Append( "<input nz-input=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填项验证 - 设置BindErrorTip
        /// </summary>
        [Fact]
        public void TestRequired_BindErrorTip() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( AngularConst.BindErrorTip, "a" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"a\">" );
            result.Append( "<input nz-input=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填项消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( UiConst.RequiredMessage, "a" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" requiredMessage=\"a\" x-validation-extend=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填项消息
        /// </summary>
        [Fact]
        public void TestBindRequiredMessage() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( AngularConst.BindRequiredMessage, "a" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [requiredMessage]=\"a\" [x-required-extend]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小长度验证
        /// </summary>
        [Fact]
        public void TestMinLength() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.MinLength, "2" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [minlength]=\"2\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小长度验证消息
        /// </summary>
        [Fact]
        public void TestMinLengthMessage() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.MinLength, "2" );
            _wrapper.SetContextAttribute( UiConst.MinLengthMessage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" minLengthMessage=\"a\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [minlength]=\"2\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小长度验证消息
        /// </summary>
        [Fact]
        public void TestBindMinLengthMessage() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.MinLength, "2" );
            _wrapper.SetContextAttribute( AngularConst.BindMinLengthMessage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [minLengthMessage]=\"a\" [minlength]=\"2\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大长度验证
        /// </summary>
        [Fact]
        public void TestMaxLength() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.MaxLength, "2" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [maxlength]=\"2\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试电子邮件验证消息
        /// </summary>
        [Fact]
        public void TestEmailMessage() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.Type, InputType.Email );
            _wrapper.SetContextAttribute( UiConst.EmailMessage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" emailMessage=\"a\" nz-input=\"\" type=\"email\" x-validation-extend=\"\" " );
            result.Append( "[(ngModel)]=\"model\" [email]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试电子邮件验证消息
        /// </summary>
        [Fact]
        public void TestBindEmailMessage() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.Type, InputType.Email );
            _wrapper.SetContextAttribute( AngularConst.BindEmailMessage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" type=\"email\" x-validation-extend=\"\" " );
            result.Append( "[(ngModel)]=\"model\" [emailMessage]=\"a\" [email]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestPattern_PatternMessage() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.Pattern, "a" );
            _wrapper.SetContextAttribute( UiConst.PatternMessage, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" pattern=\"a\" patternMessage=\"b\" " );
            result.Append( "x-validation-extend=\"\" [(ngModel)]=\"model\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestBindPattern_BindPatternMessage() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( AngularConst.BindPattern, "a" );
            _wrapper.SetContextAttribute( AngularConst.BindPatternMessage, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [patternMessage]=\"b\" " );
            result.Append( "[pattern]=\"a\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

