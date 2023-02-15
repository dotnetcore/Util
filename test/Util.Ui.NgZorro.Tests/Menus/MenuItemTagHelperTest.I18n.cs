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
            result.Append( "<li nz-menu-item=\"\">a</li>" );
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
            result.Append( "<li nz-menu-item=\"\">{{'a'|i18n}}</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Update文本
        /// </summary>
        [Fact]
        public void TestTextUpdate() {
            _wrapper.SetContextAttribute( UiConst.TextUpdate, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">Update</li>" );
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
            result.Append( "<li nz-menu-item=\"\">{{'util.update'|i18n}}</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Delete文本
        /// </summary>
        [Fact]
        public void TestTextDelete() {
            _wrapper.SetContextAttribute( UiConst.TextDelete, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">Delete</li>" );
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
            result.Append( "<li nz-menu-item=\"\">{{'util.delete'|i18n}}</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Detail文本
        /// </summary>
        [Fact]
        public void TestTextDetail() {
            _wrapper.SetContextAttribute( UiConst.TextDetail, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">Detail</li>" );
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
            result.Append( "<li nz-menu-item=\"\">{{'util.detail'|i18n}}</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Enable文本
        /// </summary>
        [Fact]
        public void TestTextEnable() {
            _wrapper.SetContextAttribute( UiConst.TextEnable, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">Enable</li>" );
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
            result.Append( "<li nz-menu-item=\"\">{{'util.enable'|i18n}}</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Disable文本
        /// </summary>
        [Fact]
        public void TestTextDisable() {
            _wrapper.SetContextAttribute( UiConst.TextDisable, true );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">Disable</li>" );
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
            result.Append( "<li nz-menu-item=\"\">{{'util.disable'|i18n}}</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}