using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tabs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tabs {
    /// <summary>
    /// 标签测试
    /// </summary>
    public partial class TabTagHelperTest {
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
        public TabTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TabTagHelper().ToWrapper();
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
            result.Append( "<nz-tab></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

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

        /// <summary>
        /// 测试是否强制渲染
        /// </summary>
        [Fact]
        public void TestForceRender() {
            _wrapper.SetContextAttribute( UiConst.ForceRender, true );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzForceRender]=\"true\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否强制渲染
        /// </summary>
        [Fact]
        public void TestBindForceRender() {
            _wrapper.SetContextAttribute( AngularConst.BindForceRender, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzForceRender]=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzDisabled]=\"true\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzDisabled]=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示关闭按钮
        /// </summary>
        [Fact]
        public void TestClosable() {
            _wrapper.SetContextAttribute( UiConst.Closable, true );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzClosable]=\"true\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示关闭按钮
        /// </summary>
        [Fact]
        public void TestBindClosable() {
            _wrapper.SetContextAttribute( AngularConst.BindClosable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzClosable]=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭按钮图标
        /// </summary>
        [Fact]
        public void TestCloseIcon() {
            _wrapper.SetContextAttribute( UiConst.CloseIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-tab nzCloseIcon=\"account-book\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭按钮图标
        /// </summary>
        [Fact]
        public void TestBindCloseIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab [nzCloseIcon]=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab>a</nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab (nzClick)=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试上下文菜单事件
        /// </summary>
        [Fact]
        public void TestOnContextmenu() {
            _wrapper.SetContextAttribute( UiConst.OnContextmenu, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab (nzContextmenu)=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中事件
        /// </summary>
        [Fact]
        public void TestOnSelect() {
            _wrapper.SetContextAttribute( UiConst.OnSelect, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab (nzSelect)=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试取消选中事件
        /// </summary>
        [Fact]
        public void TestOnDeselect() {
            _wrapper.SetContextAttribute( UiConst.OnDeselect, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab (nzDeselect)=\"a\"></nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}