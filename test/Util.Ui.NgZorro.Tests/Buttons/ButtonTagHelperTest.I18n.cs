using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 国际化相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">a</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本 - 支持国际化
        /// </summary>
        [Fact]
        public void TestText_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'a'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否Ok文本
        /// </summary>
        [Fact]
        public void TestOk() {
            _wrapper.SetContextAttribute( UiConst.Ok, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Ok</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否Ok文本 - 支持国际化
        /// </summary>
        [Fact]
        public void TestOk_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Ok, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.ok'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否Cancel文本
        /// </summary>
        [Fact]
        public void TestCancel() {
            _wrapper.SetContextAttribute( UiConst.Cancel, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Cancel</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否Cancel文本 - 支持国际化
        /// </summary>
        [Fact]
        public void TestCancel_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Cancel, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.cancel'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
