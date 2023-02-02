using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Cards {
    /// <summary>
    /// 卡片测试
    /// </summary>
    public partial class CardTagHelperTest {
        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card nzTitle=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzTitle]=\"'a'|i18n\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card [nzTitle]=\"a\"></nz-card>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}