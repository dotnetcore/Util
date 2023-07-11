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
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<nz-upload #u_id=\"xUploadExtend\" x-upload-extend=\"\" [(model)]=\"model.code\" [(nzFileList)]=\"u_id.files\">" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            result.Append( "<input #v_id=\"xValidationExtend\" displayName=\"code\" name=\"input_id\" nz-input=\"\" style=\"display: none\" " );
            result.Append( "x-validation-extend=\"\" [ngModel]=\"u_id.inputValue\" [required]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}