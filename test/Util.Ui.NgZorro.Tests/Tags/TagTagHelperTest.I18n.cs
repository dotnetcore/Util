using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tags {
    /// <summary>
    /// 标签测试 - 多语言支持
    /// </summary>
    public partial class TagTagHelperTest {
        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tag>a</nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestText_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tag>{{'a'|i18n}}</nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Enabled文本
        /// </summary>
        [Fact]
        public void TestTextEnabled() {
            _wrapper.SetContextAttribute( UiConst.TextEnabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tag>Enabled</nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Enabled文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextEnabled_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextEnabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tag>{{'util.enabled'|i18n}}</nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Not Enabled文本
        /// </summary>
        [Fact]
        public void TestTextNotEnabled() {
            _wrapper.SetContextAttribute( UiConst.TextNotEnabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tag>Not Enabled</nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Not Enabled文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextNotEnabled_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextNotEnabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tag>{{'util.notEnabled'|i18n}}</nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}