using Util.Helpers;
using Util.Ui.Zorro.TreeTables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.TreeTables.Builders {
    /// <summary>
    /// 树形表格列td生成器测试
    /// </summary>
    public class TreeTableColumnBuilderTest {
        /// <summary>
        /// 测试
        /// </summary>
        [Fact]
        public void Test() {
            var builder = new TreeTableColumnBuilder();
            builder.SetColumn( "a", "b", 20 );
            var result = new String();
            result.Append( "<td " );
            result.Append( "(nzExpandChange)=\"a.collapse(row,$event)\" " );
            result.Append( "[nzExpand]=\"a.isExpand(row)\" " );
            result.Append( "[nzIndentSize]=\"row.level*20\" " );
            result.Append( "[nzShowExpand]=\"!a.isLeaf(row)\"" );
            result.Append( ">" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"a.toggle(row)\" " );
            result.Append( "*ngIf=\"a.showCheckbox\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"a.isChecked(row)\" " );
            result.Append( "[nzIndeterminate]=\"a.isIndeterminate(row)\">" );
            result.Append( "{{b}}" );
            result.Append( "</label>" );
            result.Append( "<ng-container *ngIf=\"!a.showCheckbox\">" );
            result.Append( "{{b}}" );
            result.Append( "</ng-container>" );
            result.Append( "</td>" );
            Assert.Equal( result.ToString(), builder.ToString() );
        }
    }
}
