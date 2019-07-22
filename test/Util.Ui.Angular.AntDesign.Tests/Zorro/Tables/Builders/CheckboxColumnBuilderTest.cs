using Util.Ui.Zorro.Tables.Builders;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables.Builders {
    /// <summary>
    /// 复选框列生成器测试
    /// </summary>
    public class CheckboxColumnBuilderTest {
        /// <summary>
        /// 复选框列生成器
        /// </summary>
        private readonly CheckboxColumnBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CheckboxColumnBuilderTest() {
            _builder = new CheckboxColumnBuilder("id");
        }

        /// <summary>
        /// 测试输出
        /// </summary>
        [Fact]
        public void Test() {
            var result = new String();
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"id_wrapper.checkedSelection.toggle(row)\" " );
            result.Append( "[nzChecked]=\"id_wrapper.checkedSelection.isSelected(row)\" " );
            result.Append( "[nzShowCheckbox]=\"id_wrapper.multiple\">" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"id_wrapper.checkRowOnly(row)\" " );
            result.Append( "*ngIf=\"!id_wrapper.multiple\" name=\"radio_id\" nz-radio=\"\" " );
            result.Append( "[ngModel]=\"id_wrapper.checkedSelection.isSelected(row)\">" );
            result.Append( "</label>" );
            result.Append( "</td>" );

            Assert.Equal( result.ToString(), _builder.ToString() );
        }
    }
}
