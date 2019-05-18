using Util.Helpers;
using Util.Ui.Zorro.TreeTables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.TreeTables.Builders {
    /// <summary>
    /// 树形表格标题复选框生成器测试
    /// </summary>
    public class MasterCheckBoxBuilderTest {
        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test() {
            var builder = new MasterCheckBoxBuilder("a","b");
            var result = new String();
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"a.masterToggle()\" " );
            result.Append( "*ngIf=\"a.showCheckbox\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"a.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"a.isMasterIndeterminate()\">" );
            result.Append( "b" );
            result.Append( "</label>" );
            Assert.Equal( result.ToString(), builder.ToString() );
        }
    }
}
