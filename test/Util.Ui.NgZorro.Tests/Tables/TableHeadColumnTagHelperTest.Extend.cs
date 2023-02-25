using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头单元格测试  - 指令扩展测试
    /// </summary>
    public partial class TableHeadColumnTagHelperTest {

        #region Title

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>{{'a'|i18n}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region TitleOperation

        /// <summary>
        /// 测试Operation标题
        /// </summary>
        [Fact]
        public void TestTitleOperation() {
            _wrapper.SetContextAttribute( UiConst.TitleOperation, true );
            var result = new StringBuilder();
            result.Append( "<th>Operation</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Operation标题 - 多语言
        /// </summary>
        [Fact]
        public void TestTitleOperation_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TitleOperation, true );
            var result = new StringBuilder();
            result.Append( "<th>{{'util.operation'|i18n}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试表头复选框
        /// </summary>
        [Fact]
        public void TestCheckbox() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowCheckbox = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
            result.Append( "[nzShowCheckbox]=\"true\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
            result.Append( "</th>" );
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Radio

        /// <summary>
        /// 测试表头单选框
        /// </summary>
        [Fact]
        public void TestRadio_1() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzWidth]=\"x_id.config.table.radioWidth\"></th>" );
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表头单选框 - 已设置复选框
        /// </summary>
        [Fact]
        public void TestRadio_2() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowCheckbox = true, IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
            result.Append( "[nzShowCheckbox]=\"true\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
            result.Append( "</th>" );
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region LineNumber

        /// <summary>
        /// 测试序号
        /// </summary>
        [Fact]
        public void TestLineNumber_1() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsShowLineNumber = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
            result.Append( "<th>{{'a'|i18n}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试序号 - 同时设置复选框
        /// </summary>
        [Fact]
        public void TestLineNumber_2() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetItem( new TableShareConfig( "id" ) {
                IsShowCheckbox = true,
                IsShowLineNumber = true
            } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
            result.Append( "[nzShowCheckbox]=\"true\" [nzWidth]=\"x_id.config.table.checkboxWidth\">" );
            result.Append( "</th>" );
            result.Append( "<th [nzWidth]=\"x_id.config.table.lineNumberWidth\">{{'util.lineNumber'|i18n}}</th>" );
            result.Append( "<th>{{'a'|i18n}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Sort

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestSort() {
            _wrapper.SetItem( new TableShareConfig( "id" ) );
            _wrapper.SetContextAttribute( UiConst.Sort, "a" );
            var result = new StringBuilder();
            result.Append( "<th (nzSortOrderChange)=\"x_id.sortChange('a',$event)\" [nzShowSort]=\"true\" [nzSortFn]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}