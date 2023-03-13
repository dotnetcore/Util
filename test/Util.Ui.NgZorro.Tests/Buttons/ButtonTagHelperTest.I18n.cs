using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 多语言相关
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
        /// 测试文本 - 支持多语言
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
        /// 测试Ok文本
        /// </summary>
        [Fact]
        public void TestTextOk() {
            _wrapper.SetContextAttribute( UiConst.TextOk, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Ok</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Ok文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextOk_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextOk, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.ok'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Cancel文本
        /// </summary>
        [Fact]
        public void TestTextCancel() {
            _wrapper.SetContextAttribute( UiConst.TextCancel, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Cancel</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Cancel文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextCancel_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextCancel, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.cancel'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Create文本
        /// </summary>
        [Fact]
        public void TestTextCreate() {
            _wrapper.SetContextAttribute( UiConst.TextCreate, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Create</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Create文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextCreate_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextCreate, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.create'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Update文本
        /// </summary>
        [Fact]
        public void TestTextUpdate() {
            _wrapper.SetContextAttribute( UiConst.TextUpdate, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Update</button>" );
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
            result.Append( "<button nz-button=\"\">{{'util.update'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Delete文本
        /// </summary>
        [Fact]
        public void TestTextDelete() {
            _wrapper.SetContextAttribute( UiConst.TextDelete, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Delete</button>" );
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
            result.Append( "<button nz-button=\"\">{{'util.delete'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Detail文本
        /// </summary>
        [Fact]
        public void TestTextDetail() {
            _wrapper.SetContextAttribute( UiConst.TextDetail, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Detail</button>" );
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
            result.Append( "<button nz-button=\"\">{{'util.detail'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Query文本
        /// </summary>
        [Fact]
        public void TestTextQuery() {
            _wrapper.SetContextAttribute( UiConst.TextQuery, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Query</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Query文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextQuery_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextQuery, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.query'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Refresh文本
        /// </summary>
        [Fact]
        public void TestTextRefresh() {
            _wrapper.SetContextAttribute( UiConst.TextRefresh, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Refresh</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Refresh文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextRefresh_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextRefresh, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.refresh'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Save文本
        /// </summary>
        [Fact]
        public void TestTextSave() {
            _wrapper.SetContextAttribute( UiConst.TextSave, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Save</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Save文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextSave_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextSave, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.save'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Enable文本
        /// </summary>
        [Fact]
        public void TestTextEnable() {
            _wrapper.SetContextAttribute( UiConst.TextEnable, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Enable</button>" );
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
            result.Append( "<button nz-button=\"\">{{'util.enable'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Disable文本
        /// </summary>
        [Fact]
        public void TestTextDisable() {
            _wrapper.SetContextAttribute( UiConst.TextDisable, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Disable</button>" );
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
            result.Append( "<button nz-button=\"\">{{'util.disable'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Select All文本
        /// </summary>
        [Fact]
        public void TestTextSelectAll() {
            _wrapper.SetContextAttribute( UiConst.TextSelectAll, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Select All</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Select All文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextSelectAll_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextSelectAll, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.selectAll'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Deselect All文本
        /// </summary>
        [Fact]
        public void TestTextDeselectAll() {
            _wrapper.SetContextAttribute( UiConst.TextDeselectAll, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">Deselect All</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Deselect All文本 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTextDeselectAll_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TextDeselectAll, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">{{'util.deselectAll'|i18n}}</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
