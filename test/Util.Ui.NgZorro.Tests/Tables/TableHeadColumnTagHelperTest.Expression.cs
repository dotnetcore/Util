using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头单元格测试  - 表达式支持
    /// </summary>
    public partial class TableHeadColumnTagHelperTest {
        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestFor() {
            _wrapper.SetExpression( UiConst.For, t => t.Code );
            var result = new StringBuilder();
            result.Append( "<th>code</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestFor_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( UiConst.For, t => t.Code );
            var result = new StringBuilder();
            result.Append( "<th>{{'code'|i18n}}</th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}