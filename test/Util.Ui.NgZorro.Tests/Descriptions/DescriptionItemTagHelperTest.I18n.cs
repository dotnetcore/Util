using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Descriptions {
    /// <summary>
    /// 描述列表项测试 - 多语言支持
    /// </summary>
    public partial class DescriptionItemTagHelperTest {
        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item nzTitle=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题- 多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzTitle]=\"'a'|i18n\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions-item [nzTitle]=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}