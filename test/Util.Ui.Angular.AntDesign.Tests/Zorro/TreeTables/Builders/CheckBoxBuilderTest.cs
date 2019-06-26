using Util.Helpers;
using Util.Ui.Zorro.TreeTables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.TreeTables.Builders {
    /// <summary>
    /// 树形表格复选框生成器测试
    /// </summary>
    public class CheckBoxBuilderTest {
        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test() {
            var builder = new CheckBoxBuilder("a","b");
            var result = new String();
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"a.toggle(row)\" " );
            result.Append( "*ngIf=\"a.isShowCheckbox()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"a.isChecked(row)\" " );
            result.Append( "[nzIndeterminate]=\"a.isIndeterminate(row)\">" );
            result.Append( "{{b}}" );
            result.Append( "</label>" );
            Assert.Equal( result.ToString(), builder.ToString() );
        }
    }
}
