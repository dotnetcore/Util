using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.DatePickers {
    /// <summary>
    /// 日期范围选择测试 - 表达式解析测试
    /// </summary>
    public partial class RangePickerTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">出生日期</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_birthday\">" );
            result.Append( "<nz-range-picker #birthday=\"\" #v_birthday=\"xValidationExtend\" displayName=\"出生日期\" name=\"birthday\" " );
            result.Append( "x-validation-extend=\"\" [(ngModel)]=\"model.birthday\" [required]=\"true\">" );
            result.Append( "</nz-range-picker>" );
            result.Append( "<ng-template #vt_birthday=\"\">" );
            result.Append( "{{v_birthday.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试解析表达式属性for-begin,for-end
        /// </summary>
        [Fact]
        public void TestForBegin_ForEnd_1() {
            _wrapper.SetExpression( UiConst.ForBegin, t => t.BeginBirthday );
            _wrapper.SetExpression( UiConst.ForEnd, t => t.EndBirthday );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">出生日期</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_begin_birthday\">" );
            result.Append( "<nz-range-picker #begin_birthday=\"\" #v_begin_birthday=\"xValidationExtend\" #x_begin_birthday=\"xRangePickerExtend\" " );
            result.Append( "displayName=\"出生日期\" name=\"begin_birthday\" x-range-picker-extend=\"\" x-validation-extend=\"\" " );
            result.Append( "[(beginDate)]=\"model.beginBirthday\" [(endDate)]=\"model.endBirthday\" [(ngModel)]=\"x_begin_birthday.rangeDates\" [required]=\"true\">" );
            result.Append( "</nz-range-picker>" );
            result.Append( "<ng-template #vt_begin_birthday=\"\">" );
            result.Append( "{{v_begin_birthday.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}