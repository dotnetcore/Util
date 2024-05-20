using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Menus {
    /// <summary>
    /// 菜单项测试 - 多语言测试
    /// </summary>
    public partial class MenuItemTagHelperTest {
        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>a</span>" );
            result.Append( "</li>" );
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
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>{{'a'|i18n}}</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Update文本
        /// </summary>
        [Fact]
        public void TestTextUpdate() {
            _wrapper.SetContextAttribute( UiConst.TextUpdate, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>Update</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Update文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextUpdate_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextUpdate, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>{{'util.update'|i18n}}</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Delete文本
        /// </summary>
        [Fact]
        public void TestTextDelete() {
            _wrapper.SetContextAttribute( UiConst.TextDelete, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>Delete</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Delete文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextDelete_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextDelete, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>{{'util.delete'|i18n}}</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Detail文本
        /// </summary>
        [Fact]
        public void TestTextDetail() {
            _wrapper.SetContextAttribute( UiConst.TextDetail, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>Detail</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Detail文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextDetail_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextDetail, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>{{'util.detail'|i18n}}</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Enable文本
        /// </summary>
        [Fact]
        public void TestTextEnable() {
            _wrapper.SetContextAttribute( UiConst.TextEnable, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>Enable</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Enable文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextEnable_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextEnable, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>{{'util.enable'|i18n}}</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Disable文本
        /// </summary>
        [Fact]
        public void TestTextDisable() {
            _wrapper.SetContextAttribute( UiConst.TextDisable, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>Disable</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Disable文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextDisable_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextDisable, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<span>{{'util.disable'|i18n}}</span>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}