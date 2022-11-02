using System;
using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格单元格测试 - 编辑指令扩展
    /// </summary>
    public partial class TableColumnTagHelperTest {

        #region IsEdit

        /// <summary>
        /// 测试启用编辑模式 - 自动创建显示区域和控件区域
        /// </summary>
        [Fact]
        public void TestIsEdit_1() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置编辑模式
            _wrapper.SetContextAttribute( UiConst.IsEdit, true );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Column, "b" );

            //添加输入框组件
            var input = new InputTagHelper().ToWrapper();
            _wrapper.AppendContent( input );

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
            result.Append( "<input #c_id=\"\" nz-input=\"\" [editRow]=\"id_row\" [x-edit-control]=\"c_id\" />" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试启用编辑模式 - 自动创建显示区域和控件区域 - 设置表格标识
        /// </summary>
        [Fact]
        public void TestIsEdit_2() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.Id, "tb" );

            //添加列
            table.AppendContent( _wrapper );

            //设置编辑模式
            _wrapper.SetContextAttribute( UiConst.IsEdit, true );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Column, "b" );

            //添加输入框组件
            var input = new InputTagHelper().ToWrapper();
            _wrapper.AppendContent( input );

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
            result.Append( "<ng-container *ngIf=\"e_tb.editId !== row.id;else e_tb_b\">" );
            result.Append( "{{row.b}}" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #e_tb_b=\"\">" );
            result.Append( "<input #c_id=\"\" nz-input=\"\" [editRow]=\"tb_row\" [x-edit-control]=\"c_id\" />" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试启用编辑模式 - 自动创建显示区域和控件区域 - 设置表格标识,行标识,控件标识
        /// </summary>
        [Fact]
        public void TestIsEdit_3() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.Id, "tb" );

            //添加行
            var row = new TableRowTagHelper().ToWrapper();
            row.SetContextAttribute( UiConst.Id, "rowId" );
            table.AppendContent( row );

            //添加列
            row.AppendContent( _wrapper );

            //设置编辑模式
            _wrapper.SetContextAttribute( UiConst.IsEdit, true );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Column, "b" );

            //添加输入框组件
            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.Id, "input" );
            _wrapper.AppendContent( input );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table #e_tb=\"xEditTable\" #tb=\"\" x-edit-table=\"\">" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr #rowId=\"xEditRow\" (click)=\"e_tb.clickEdit(row.id)\" (dblclick)=\"e_tb.dblClickEdit(row.id)\" [x-edit-row]=\"row\">" );
            result.Append( "<td>" );
            result.Append( "<ng-container *ngIf=\"e_tb.editId !== row.id;else e_tb_b\">" );
            result.Append( "{{row.b}}" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #e_tb_b=\"\">" );
            result.Append( "<input #input=\"\" nz-input=\"\" [editRow]=\"rowId\" [x-edit-control]=\"input\" />" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            var tableResult = table.GetResult();
            _output.WriteLine( tableResult );

            //验证
            Assert.Equal( result.ToString(), tableResult );
        }

        /// <summary>
        /// 测试启用编辑模式 - 未设置content,抛出异常
        /// </summary>
        [Fact]
        public void TestIsEdit_4() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置编辑模式
            _wrapper.SetContextAttribute( UiConst.IsEdit, true );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Column, "b" );

            //验证
            Assert.Throws<InvalidOperationException>( () => table.GetResult() );
        }

        /// <summary>
        /// 测试启用编辑模式 - 手工创建显示区域和控件区域
        /// </summary>
        [Fact]
        public void TestIsEdit_5() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            _wrapper.SetContextAttribute( UiConst.IsEdit, true );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Column, "b" );
            table.AppendContent( _wrapper );

            //添加显示区域
            var display = new TableColumnDisplayTagHelper().ToWrapper();
            display.AppendContent( "c" );
            _wrapper.AppendContent( display );

            //添加控件区域
            var control = new TableColumnControlTagHelper().ToWrapper();
            _wrapper.AppendContent( control );

            //添加输入框组件
            var input = new InputTagHelper().ToWrapper();
            control.AppendContent( input );

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
            result.Append( "c" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #e_id_b=\"\">" );
            result.Append( "<input #c_id=\"\" nz-input=\"\" [editRow]=\"id_row\" [x-edit-control]=\"c_id\" />" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );

            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试启用编辑模式 - 手工创建显示区域和控件区域 - 设置控件区域标识
        /// </summary>
        [Fact]
        public void TestIsEdit_6() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            _wrapper.SetContextAttribute( UiConst.IsEdit, true );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Column, "b" );
            table.AppendContent( _wrapper );

            //添加显示区域
            var display = new TableColumnDisplayTagHelper().ToWrapper();
            display.AppendContent( "c" );
            _wrapper.AppendContent( display );

            //添加控件区域
            var control = new TableColumnControlTagHelper().ToWrapper();
            control.SetContextAttribute( UiConst.Id, "control_1" );
            _wrapper.AppendContent( control );

            //添加输入框组件
            var input = new InputTagHelper().ToWrapper();
            control.AppendContent( input );

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
            result.Append( "<ng-container *ngIf=\"e_id.editId !== row.id;else control_1\">" );
            result.Append( "c" );
            result.Append( "</ng-container>" );
            result.Append( "<ng-template #control_1=\"\">" );
            result.Append( "<input #c_id=\"\" nz-input=\"\" [editRow]=\"id_row\" [x-edit-control]=\"c_id\" />" );
            result.Append( "</ng-template>" );
            result.Append( "</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );

            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion
    }
}