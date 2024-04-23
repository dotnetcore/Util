using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Upload {
    /// <summary>
    /// 上传测试 - 表达式测试
    /// </summary>
    public partial class UploadTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">code</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_code\">" );
            result.Append( "<nz-upload #code=\"\" #u_code=\"xUploadExtend\" (nzChange)=\"u_code.handleChange($event)\" x-upload-extend=\"\" [(model)]=\"model.code\" [(nzFileList)]=\"u_code.files\" [nzFilter]=\"u_code.filters\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            result.Append( "<input #v_code=\"xValidationExtend\" displayName=\"code\" name=\"input_code\" nz-input=\"\" style=\"display: none\" " );
            result.Append( "x-validation-extend=\"\" [ngModel]=\"u_code.inputValue\" [required]=\"true\" />" );
            result.Append( "<ng-template #vt_code=\"\">" );
            result.Append( "{{v_code.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}