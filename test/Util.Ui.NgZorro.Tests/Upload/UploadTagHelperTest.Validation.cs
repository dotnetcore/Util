using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Upload {
    /// <summary>
    /// 上传测试 - 验证测试
    /// </summary>
    public partial class UploadTagHelperTest {
        /// <summary>
        /// 测试必填项验证
        /// </summary>
        [Fact(Skip = "未实现")]
        public void TestRequired() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" x-upload-extend=\"\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" style=\"display: none\" x-validation-extend=\"\" [ngModel]=\"u_id.inputValue\" [required]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}