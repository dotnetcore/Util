using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.InputNumbers {
    /// <summary>
    /// 数字输入框测试 - 表达式解析测试
    /// </summary>
    public partial class InputNumberTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Age );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">年龄</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<nz-input-number #v_id=\"xValidationExtend\" displayName=\"年龄\" name=\"age\" " );
            result.Append( "nzMax=\"8.8\" nzMin=\"5.5\" " );
            result.Append( "x-validation-extend=\"\" [(ngModel)]=\"model.age\" [required]=\"true\">" );
            result.Append( "</nz-input-number>" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

