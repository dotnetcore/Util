using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.PageHeaders;
using Util.Ui.NgZorro;
using Util.Ui.NgZorro.Configs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.PageHeaders {
    /// <summary>
    /// 页头测试
    /// </summary>
    public class PageHeaderTagHelperTest {
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
        public PageHeaderTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new PageHeaderTagHelper().ToWrapper();
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
            result.Append( "<page-header></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header title=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTitle_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions{EnableI18n = true} );
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [title]=\"'a'|i18n\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试创建标题
        /// </summary>
        [Fact]
        public void TestTitle_Create() {
            _wrapper.SetContextAttribute( UiConst.TitleCreate, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header title=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试创建标题 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTitle_Create_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TitleCreate, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [title]=\"'a'|i18n\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试修改标题
        /// </summary>
        [Fact]
        public void TestTitle_Update() {
            _wrapper.SetContextAttribute( UiConst.TitleUpdate, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header title=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试修改标题 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTitle_Update_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TitleUpdate, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [title]=\"'a'|i18n\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 同时设置创建和修改标题
        /// </summary>
        [Fact]
        public void TestTitle_Create_Update() {
            _wrapper.SetContextAttribute( UiConst.TitleCreate, "a" );
            _wrapper.SetContextAttribute( UiConst.TitleUpdate, "b" );
            var result = new StringBuilder();
            result.Append( "<page-header [title]=\"isNew?'a':'b'\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题 - 同时设置创建和修改标题 - 支持多语言
        /// </summary>
        [Fact]
        public void TestTitle_Create_Update_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.TitleCreate, "a" );
            _wrapper.SetContextAttribute( UiConst.TitleUpdate, "b" );
            var result = new StringBuilder();
            result.Append( "<page-header [title]=\"(isNew?'a':'b')|i18n\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [title]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动设置标题
        /// </summary>
        [Fact]
        public void TestAutoTitle() {
            _wrapper.SetContextAttribute( UiConst.AutoTitle, true );
            var result = new StringBuilder();
            result.Append( "<page-header [autoTitle]=\"true\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动设置标题
        /// </summary>
        [Fact]
        public void TestBindAutoTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [autoTitle]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同步标题
        /// </summary>
        [Fact]
        public void TestSyncTitle() {
            _wrapper.SetContextAttribute( UiConst.SyncTitle, true );
            var result = new StringBuilder();
            result.Append( "<page-header [syncTitle]=\"true\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试同步标题
        /// </summary>
        [Fact]
        public void TestBindSyncTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindSyncTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [syncTitle]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试首页文本
        /// </summary>
        [Fact]
        public void TestHome() {
            _wrapper.SetContextAttribute( UiConst.Home, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header home=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试首页文本
        /// </summary>
        [Fact]
        public void TestBindHome() {
            _wrapper.SetContextAttribute( AngularConst.BindHome, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [home]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试首页链接
        /// </summary>
        [Fact]
        public void TestHomeLink() {
            _wrapper.SetContextAttribute( UiConst.HomeLink, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header homeLink=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试首页链接
        /// </summary>
        [Fact]
        public void TestBindHomeLink() {
            _wrapper.SetContextAttribute( AngularConst.BindHomeLink, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [homeLink]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试首页国际化
        /// </summary>
        [Fact]
        public void TestHomeI18n() {
            _wrapper.SetContextAttribute( UiConst.HomeI18n, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header homeI18n=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试首页国际化
        /// </summary>
        [Fact]
        public void TestBindHomeI18n() {
            _wrapper.SetContextAttribute( AngularConst.BindHomeI18n, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [homeI18n]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动生成导航
        /// </summary>
        [Fact]
        public void TestAutoBreadcrumb() {
            _wrapper.SetContextAttribute( UiConst.AutoBreadcrumb, true );
            var result = new StringBuilder();
            result.Append( "<page-header [autoBreadcrumb]=\"true\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动生成导航
        /// </summary>
        [Fact]
        public void TestBindAutoBreadcrumb() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoBreadcrumb, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [autoBreadcrumb]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试递归查找导航
        /// </summary>
        [Fact]
        public void TestRecursiveBreadcrumb() {
            _wrapper.SetContextAttribute( UiConst.RecursiveBreadcrumb, true );
            var result = new StringBuilder();
            result.Append( "<page-header [recursiveBreadcrumb]=\"true\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试递归查找导航
        /// </summary>
        [Fact]
        public void TestBindRecursiveBreadcrumb() {
            _wrapper.SetContextAttribute( AngularConst.BindRecursiveBreadcrumb, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [recursiveBreadcrumb]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [loading]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否定宽
        /// </summary>
        [Fact]
        public void TestWide() {
            _wrapper.SetContextAttribute( UiConst.Wide, true );
            var result = new StringBuilder();
            result.Append( "<page-header [wide]=\"true\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否定宽
        /// </summary>
        [Fact]
        public void TestBindWide() {
            _wrapper.SetContextAttribute( AngularConst.BindWide, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [wide]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否固定模式
        /// </summary>
        [Fact]
        public void TestFixed() {
            _wrapper.SetContextAttribute( UiConst.Fixed, true );
            var result = new StringBuilder();
            result.Append( "<page-header [fixed]=\"true\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否固定模式
        /// </summary>
        [Fact]
        public void TestBindFixed() {
            _wrapper.SetContextAttribute( AngularConst.BindFixed, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [fixed]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试固定偏移值
        /// </summary>
        [Fact]
        public void TestFixedOffsetTop() {
            _wrapper.SetContextAttribute( UiConst.FixedOffsetTop, "6" );
            var result = new StringBuilder();
            result.Append( "<page-header [fixedOffsetTop]=\"6\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义导航区域
        /// </summary>
        [Fact]
        public void TestBreadcrumb() {
            _wrapper.SetContextAttribute( UiConst.Breadcrumb, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [breadcrumb]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义Logo区域
        /// </summary>
        [Fact]
        public void TestLogo() {
            _wrapper.SetContextAttribute( UiConst.Logo, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [logo]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义操作区域
        /// </summary>
        [Fact]
        public void TestAction() {
            _wrapper.SetContextAttribute( UiConst.Action, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [action]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义内容区域
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.SetContextAttribute( UiConst.Content, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [content]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义额外信息区域
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [extra]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义标签区域
        /// </summary>
        [Fact]
        public void TestTab() {
            _wrapper.SetContextAttribute( UiConst.Tab, "a" );
            var result = new StringBuilder();
            result.Append( "<page-header [tab]=\"a\"></page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestAppendContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<page-header>a</page-header>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}