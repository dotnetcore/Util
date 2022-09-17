using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
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

        #endregion

        #region LineNumber

        /// <summary>
        /// 测试行号标题
        /// </summary>
        [Fact]
        public void TestType_LineNumber() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.LineNumber );
            var result = new StringBuilder();
            result.Append( "<th>{{x_id.config.text.lineNumber}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试表头复选框
        /// </summary>
        [Fact]
        public void TestType_Checkbox() {
            _wrapper.SetContextAttribute( UiConst.Type, TableColumnType.Checkbox );
            var result = new StringBuilder();
            result.Append( "<th (nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!x_id.dataSource.length\" [nzIndeterminate]=\"x_id.isMasterIndeterminate()\" " );
            result.Append( "[nzShowCheckbox]=\"x_id.multiple\">" );
            result.Append( "</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}