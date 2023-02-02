using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头单元格测试  - 多语言支持
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
    }
}