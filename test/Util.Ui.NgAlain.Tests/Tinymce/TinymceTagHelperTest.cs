using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.Tinymce;
using Util.Ui.NgAlain.Enums;
using Util.Ui.NgAlain.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.Tinymce {
    /// <summary>
    /// Tinymce富文本编辑器测试
    /// </summary>
    public partial class TinymceTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TinymceTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TinymceTagHelper().ToWrapper<Customer>();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试品牌
        /// </summary>
        [Fact]
        public void TestBranding() {
            _wrapper.SetContextAttribute( UiConst.Branding, true );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [branding]=\"true\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否允许粘贴图片
        /// </summary>
        [Fact]
        public void TestPasteDataImages() {
            _wrapper.SetContextAttribute( UiConst.PasteDataImages, false );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\" [pasteDataImages]=\"false\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试菜单栏
        /// </summary>
        [Fact]
        public void TestMenubar() {
            _wrapper.SetContextAttribute( UiConst.Menubar, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" menubar=\"a\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试工具栏模式
        /// </summary>
        [Fact]
        public void TestToolbarMode() {
            _wrapper.SetContextAttribute( UiConst.ToolbarMode, TinymceToolbarMode.Scrolling );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" toolbarMode=\"scrolling\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试插件列表
        /// </summary>
        [Fact]
        public void TestPlugins() {
            _wrapper.SetContextAttribute( UiConst.Plugins, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" plugins=\"a\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试工具栏
        /// </summary>
        [Fact]
        public void TestToolbar() {
            _wrapper.SetContextAttribute( UiConst.Toolbar, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" toolbar=\"a\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, false );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\" [disabled]=\"false\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\" [disabled]=\"a\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试必填项验证
        /// </summary>
        [Fact]
        public void TestRequired() {
            _wrapper.SetContextAttribute( UiConst.Required, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\" [required]=\"a\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位文本
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" placeholder=\"a\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位文本
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\" [placeholder]=\"a\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试配置
        /// </summary>
        [Fact]
        public void TestConfig() {
            _wrapper.SetContextAttribute( UiConst.Config, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"a\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [(ngModel)]=\"a\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestBindNgModel() {
            _wrapper.SetContextAttribute( AngularConst.BindNgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\" [ngModel]=\"a\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签文本
        /// </summary>
        [Fact]
        public void TestLabelText() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\"></tinymce>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestAppendContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [config]=\"x_id.config\">a</tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnChange, "a" );
            var result = new StringBuilder();
            result.Append( "<tinymce #x_id=\"xTinymceExtend\" x-tinymce-extend=\"\" [change]=\"a\" [config]=\"x_id.config\"></tinymce>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}