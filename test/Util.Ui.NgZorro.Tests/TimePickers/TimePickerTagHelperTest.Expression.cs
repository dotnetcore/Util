using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.TimePickers {
    /// <summary>
    /// 时间选择测试 - 表达式解析测试
    /// </summary>
    public partial class TimePickerTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">出生日期</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<nz-time-picker #v_id=\"xValidationExtend\" displayName=\"出生日期\" name=\"birthday\" " );
            result.Append( "x-validation-extend=\"\" [(ngModel)]=\"model.birthday\" [required]=\"true\">" );
            result.Append( "</nz-time-picker>" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}