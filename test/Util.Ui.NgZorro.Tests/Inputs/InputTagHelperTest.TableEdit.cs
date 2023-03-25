using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 表格编辑
    /// </summary>
    public partial class InputTagHelperTest {
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

            //添加输入框组件
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
        /// 测试启用编辑模式 - 输入组件设置表达式
        /// </summary>
        [Fact]
        public void TestIsEdit_2() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //创建列
            var column = new TableColumnTagHelper().ToWrapper();
            column.SetContextAttribute( UiConst.IsEdit, true );
            column.SetContextAttribute( UiConst.Title, "a" );
            column.SetContextAttribute( UiConst.Column, "b" );
            table.AppendContent( column );

            //添加输入框组件
            _wrapper.SetExpression( t => t.Code );
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
            result.Append( "<nz-form-item class=\"mb0\">" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #c_id=\"\" #v_id=\"xValidationExtend\" displayName=\"code\" minLengthMessage=\"编码最小为10位\" " );
            result.Append( "name=\"code\" nz-input=\"\" requiredMessage=\"编码不能是空值\" x-validation-extend=\"\" [(ngModel)]=\"row.code\" [editRow]=\"id_row\" " );
            result.Append( "[maxlength]=\"100\" [minlength]=\"10\" [x-edit-control]=\"c_id\" [x-required-extend]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
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

