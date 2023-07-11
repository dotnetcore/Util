using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选择器测试 - 验证测试
    /// </summary>
    public partial class SelectTagHelperTest {
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
            result.Append( "<nz-select #v_id=\"xValidationExtend\" x-validation-extend=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\"></nz-select>" );
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
        public void TestRequiredMessage() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( UiConst.RequiredMessage, "a" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<nz-select #v_id=\"xValidationExtend\" requiredMessage=\"a\" x-validation-extend=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\"></nz-select>" );
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
            result.Append( "<nz-select #v_id=\"xValidationExtend\" x-validation-extend=\"\" [(ngModel)]=\"model\" [requiredMessage]=\"a\" [x-required-extend]=\"true\"></nz-select>" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

