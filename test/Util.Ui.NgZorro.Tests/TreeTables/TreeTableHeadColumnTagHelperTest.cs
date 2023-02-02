using System.Text;
using Util.Helpers;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.TreeTables {
    /// <summary>
    /// 树形表头单元格测试
    /// </summary>
    public class TreeTableHeadColumnTagHelperTest {

        #region 测试初始化

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
        public TreeTableHeadColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TableHeadColumnTagHelper().ToWrapper();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        #endregion

        #region Checkbox

        /// <summary>
        /// 测试表头复选框
        /// </summary>
        [Fact]
        public void TestCheckbox() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsTreeTable = true, IsShowCheckbox = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "a" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表头复选框 - 多语言
        /// </summary>
        [Fact]
        public void TestCheckbox_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsTreeTable = true, IsShowCheckbox = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "{{'a'|i18n}}" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion

        #region Radio

        /// <summary>
        /// 测试表头单选框
        /// </summary>
        [Fact]
        public void TestRadio_1() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsTreeTable = true, IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表头单选框 - 支持多语言
        /// </summary>
        [Fact]
        public void TestRadio_i18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsTreeTable = true, IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>{{'a'|i18n}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表头单选框 - 已设置复选框
        /// </summary>
        [Fact]
        public void TestRadio_2() {
            _wrapper.SetItem( new TableShareConfig( "id" ) { IsTreeTable = true, IsShowCheckbox = true, IsShowRadio = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<th>" );
            result.Append( "<label " );
            result.Append( "(nzCheckedChange)=\"x_id.masterToggle()\" " );
            result.Append( "nz-checkbox=\"\" " );
            result.Append( "[nzChecked]=\"x_id.isMasterChecked()\" " );
            result.Append( "[nzIndeterminate]=\"x_id.isMasterIndeterminate()\">" );
            result.Append( "a" );
            result.Append( "</label>" );
            result.Append( "</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        #endregion
    }
}