using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Menus {
    /// <summary>
    /// 菜单测试
    /// </summary>
    public class MenuTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new MenuTagHelper().ToWrapper();
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
            result.Append( "<ul nz-menu=\"\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestMode() {
            _wrapper.SetContextAttribute( UiConst.Mode, MenuMode.Inline );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" nzMode=\"inline\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模式
        /// </summary>
        [Fact]
        public void TestBindMode() {
            _wrapper.SetContextAttribute( AngularConst.BindMode, "a" );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzMode]=\"a\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许选中
        /// </summary>
        [Fact]
        public void TestSelectable() {
            _wrapper.SetContextAttribute( UiConst.Selectable, false );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzSelectable]=\"false\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许选中
        /// </summary>
        [Fact]
        public void TestBindSelectable() {
            _wrapper.SetContextAttribute( AngularConst.BindSelectable, "a" );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzSelectable]=\"a\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试主题
        /// </summary>
        [Fact]
        public void TestTheme() {
            _wrapper.SetContextAttribute( UiConst.Theme, MenuTheme.Light );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" nzTheme=\"light\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试主题
        /// </summary>
        [Fact]
        public void TestBindTheme() {
            _wrapper.SetContextAttribute( AngularConst.BindTheme, "a" );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzTheme]=\"a\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试折叠状态
        /// </summary>
        [Fact]
        public void TestInlineCollapsed() {
            _wrapper.SetContextAttribute( UiConst.InlineCollapsed, false );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzInlineCollapsed]=\"false\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试折叠状态
        /// </summary>
        [Fact]
        public void TestBindInlineCollapsed() {
            _wrapper.SetContextAttribute( AngularConst.BindInlineCollapsed, "a" );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzInlineCollapsed]=\"a\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缩进宽度
        /// </summary>
        [Fact]
        public void TestInlineIndent() {
            _wrapper.SetContextAttribute( UiConst.InlineIndent, 2 );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzInlineIndent]=\"2\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缩进宽度
        /// </summary>
        [Fact]
        public void TestBindInlineIndent() {
            _wrapper.SetContextAttribute( AngularConst.BindInlineIndent, "a" );
            var result = new StringBuilder();
            result.Append( "<ul nz-menu=\"\" [nzInlineIndent]=\"a\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<ul (nzClick)=\"a\" nz-menu=\"\"></ul>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}