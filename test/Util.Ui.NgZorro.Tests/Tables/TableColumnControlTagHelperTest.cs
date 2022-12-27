using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格编辑列控件区域测试
    /// </summary>
    public class TableColumnControlTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableColumnControlTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TableColumnControlTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void Test_1() {
            var result = new StringBuilder();
            result.Append( "<ng-template></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试在编辑模式中输出
        /// </summary>
        [Fact]
        public void Test_2() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.Id, "tb" );

            //添加列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.IsEdit, true );
            column.SetContextAttribute( UiConst.Title, "a" );
            column.SetContextAttribute( UiConst.Column, "name" );
            table.AppendContent( column );

            //添加控件区域
            _wrapper.AppendContent( "a" );
            column.AppendContent( _wrapper );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #e_tb=\"xEditTable\" #tb=\"\" x-edit-table=\"\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr #tb_row=\"xEditRow\" (click)=\"e_tb.clickEdit(row.id)\" (dblclick)=\"e_tb.dblClickEdit(row.id)\" [x-edit-row]=\"row\">" );
            result.Append( "<td>" );
            result.Append( "<ng-template #e_tb_name=\"\">" );
            result.Append( "a" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试在编辑模式中输出 - 设置控件区域标识
        /// </summary>
        [Fact]
        public void Test_3() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.Id, "tb" );

            //添加列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.IsEdit, true );
            column.SetContextAttribute( UiConst.Title, "a" );
            column.SetContextAttribute( UiConst.Column, "name" );
            table.AppendContent( column );

            //添加显示区域
            var display = new TableColumnDisplayTagHelper().ToWrapper();
            display.AppendContent( "a" );
            column.AppendContent( display );

            //添加控件区域并设置标识
            _wrapper.SetContextAttribute( UiConst.Id, "id" );
            _wrapper.AppendContent( "b" );
            column.AppendContent( _wrapper );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #e_tb=\"xEditTable\" #tb=\"\" x-edit-table=\"\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr #tb_row=\"xEditRow\" (click)=\"e_tb.clickEdit(row.id)\" (dblclick)=\"e_tb.dblClickEdit(row.id)\" [x-edit-row]=\"row\">" );
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"e_tb.editId !== row.id;else id\">" );
            result.Append( "a" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #id=\"\">" );
            result.Append( "b" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<ng-template>a</ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}