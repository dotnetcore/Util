using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tabs {
    /// <summary>
    /// 标签测试 - 多语言测试
    /// </summary>
    public partial class TabTagHelperTest {
        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab nzTitle=\"a\"></nz-tab>" );
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
            result.Append( "<nz-tab [nzTitle]=\"'a'|i18n\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzTitle]=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}