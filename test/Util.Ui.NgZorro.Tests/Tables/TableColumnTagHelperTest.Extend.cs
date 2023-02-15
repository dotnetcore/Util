using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表格单元格测试 - 指令扩展
    /// </summary>
    public partial class TableColumnTagHelperTest {

        #region 辅助操作

        /// <summary>
        /// 添加启用扩展的表格起始标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendExtendTable( StringBuilder result ) {
            result.Append( "<nz-table #x_id=\"xTableExtend\" " );
            result.Append( "(nzPageIndexChange)=\"x_id.pageIndexChange($event)\" (nzPageSizeChange)=\"x_id.pageSizeChange($event)\" " );
            result.Append( "x-table-extend=\"\" " );
            result.Append( "[(nzPageIndex)]=\"x_id.queryParam.page\" [(nzPageSize)]=\"x_id.queryParam.pageSize\" " );
            result.Append( "[nzData]=\"x_id.dataSource\" " );
            result.Append( "[nzFrontPagination]=\"false\" [nzLoading]=\"x_id.loading\" [nzShowQuickJumper]=\"true\" " );
            result.Append( "[nzShowSizeChanger]=\"true\" [nzShowTotal]=\"total_id\" [nzTotal]=\"x_id.total\">" );
        }

        /// <summary>
        /// 添加表格总行数模板标签
        /// </summary>
        /// <param name="result">结果</param>
        private void AppendTotalTemplate( StringBuilder result ) {
            result.Append( "<ng-template #total_id=\"\" let-range=\"range\" let-total=\"\">" );
            result.Append( "{{ 'util.tableTotalTemplate'|i18n:{start:range[0],end:range[1],total:total} }}" );
            result.Append( "</ng-template>" );
        }

        #endregion

        #region Column

        /// <summary>
        /// 测试列名
        /// </summary>
        [Fact]
        public void TestColumn() {
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列名
        /// </summary>
        [Fact]
        public void TestColumn_2() {
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            _wrapper.AppendContent( "b" );
            var result = new StringBuilder();
            result.Append( "<td>b</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Title

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题和内容
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试标题 - 多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            //启用多语言
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );

            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题和内容
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>{{'a'|i18n}}</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region TitleOperation

        /// <summary>
        /// 测试Operation标题
        /// </summary>
        [Fact]
        public void TestTitleOperation() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题和内容
            _wrapper.SetContextAttribute( UiConst.TitleOperation, true );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>Operation</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试Operation标题 - 多语言
        /// </summary>
        [Fact]
        public void TestTitleOperation_I18n() {
            //启用多语言
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );

            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题和内容
            _wrapper.SetContextAttribute( UiConst.TitleOperation, true );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th>{{'util.operation'|i18n}}</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试设置复选框
        /// </summary>
        [Fact]
        public void TestCheckbox() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowCheckbox = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzShowCheckbox]=\"true\">" );
            result.Append( "</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Radio

        /// <summary>
        /// 测试设置单选框
        /// </summary>
        [Fact]
        public void TestRadio_1() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>" );
            result.Append( "<label (click)=\"$event.stopPropagation()\" (ngModelChange)=\"x_id.checkRowOnly(row)\" name=\"r_x_id\" nz-radio=\"\" [ngModel]=\"x_id.isChecked(row)\">" );
            result.Append( "</label>" );
            result.Append( "</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置单选框 - 如果已设置复选框,则单选框不生效
        /// </summary>
        [Fact]
        public void TestRadio_2() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowCheckbox = true, IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"x_id.toggle(row)\" " );
            result.Append( "[nzChecked]=\"x_id.isChecked(row)\" " );
            result.Append( "[nzShowCheckbox]=\"true\">" );
            result.Append( "</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LineNumber

        /// <summary>
        /// 测试序号
        /// </summary>
        [Fact]
        public void TestLineNumber() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowLineNumber = true } );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{row.lineNumber}}</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试序号 - 带标题
        /// </summary>
        [Fact]
        public void TestLineNumber_Title() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.ShowLineNumber, true );

            //添加列
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            _wrapper.SetContextAttribute( UiConst.Title, "b" );
            table.AppendContent( _wrapper );

            //结果
            var result = new StringBuilder();
            AppendExtendTable( result );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">序号</th>" );
            result.Append( "<th>b</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td>{{row.lineNumber}}</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        /// <summary>
        /// 测试序号 - 带标题,多语言支持
        /// </summary>
        [Fact]
        public void TestLineNumber_Title_I18n() {
            //启用多语言
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );

            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.ShowLineNumber, true );

            //添加列
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            _wrapper.SetContextAttribute( UiConst.Title, "b" );
            table.AppendContent( _wrapper );

            //结果
            var result = new StringBuilder();
            AppendExtendTable( result );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
            result.Append( "<th>{{'b'|i18n}}</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td>{{row.lineNumber}}</td>" );
            result.Append( "<td>{{row.a}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region Bool

        /// <summary>
        /// 测试布尔类型列
        /// </summary>
        [Fact]
        public void TestType_Bool() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Bool );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{row.a?'是':'否'}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试布尔类型列 - 支持多语言
        /// </summary>
        [Fact]
        public void TestType_Bool_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Bool );
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            var result = new StringBuilder();
            result.Append( "<td>{{(row.a?'util.yes':'util.no')|i18n}}</td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Width

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();

            //添加列
            table.AppendContent( _wrapper );

            //设置标题,内容,宽度
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            _wrapper.SetContextAttribute( UiConst.Width, "100" );
            _wrapper.AppendContent( "b" );

            //结果
            var result = new StringBuilder();
            result.Append( "<nz-table>" );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th nzWidth=\"100px\">a</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "<td>b</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion

        #region Sort

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestSort() {
            //创建表格
            var table = new TableTagHelper().ToWrapper();
            table.SetContextAttribute( UiConst.EnableExtend, true );

            //添加列
            _wrapper.SetContextAttribute( UiConst.Column, "a" );
            _wrapper.SetContextAttribute( UiConst.Title, "b" );
            _wrapper.SetContextAttribute( UiConst.Sort, true );
            table.AppendContent( _wrapper );

            //结果
            var result = new StringBuilder();
            AppendExtendTable( result );
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "<th (nzSortOrderChange)=\"x_id.sortChange('a',$event)\" [nzShowSort]=\"true\" [nzSortFn]=\"true\">b</th>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of x_id.dataSource;index as index\">" );
            result.Append( "<td>{{row.a}}</td>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            result.Append( "</nz-table>" );
            AppendTotalTemplate( result );

            //验证
            Assert.Equal( result.ToString(), table.GetResult() );
        }

        #endregion
    }
}