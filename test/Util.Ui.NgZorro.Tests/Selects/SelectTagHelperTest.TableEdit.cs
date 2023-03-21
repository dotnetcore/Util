using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选择器测试 - 表格编辑
    /// </summary>
    public partial class SelectTagHelperTest {
        /// <summary>
        /// 测试启用编辑模式
        /// </summary>
        [Fact]
        public void TestIsEdit_1() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.IsEdit, true );
            column.SetContextAttribute( UiConst.Title, "a" );
            column.SetContextAttribute( UiConst.Column, "b" );
            table.AppendContent( column );

            //添加选择器组件
            column.AppendContent( _wrapper );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #e_id=\"xEditTable\" x-edit-table=\"\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr #id_row=\"xEditRow\" (click)=\"e_id.clickEdit(row.id)\" (dblclick)=\"e_id.dblClickEdit(row.id)\" [x-edit-row]=\"row\">" );
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"e_id.editId !== row.id;else e_id_b\">" );
            result.Append( "{{row.b}}" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #e_id_b=\"\">" );
            result.Append( "<nz-select #c_id=\"\" [editRow]=\"id_row\" [x-edit-control]=\"c_id\"></nz-select>" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }
    }
}

