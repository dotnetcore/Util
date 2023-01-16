using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Buttons;
using Util.Ui.NgZorro.Components.Icons;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试
    /// </summary>
    public partial class ButtonTagHelperTest {
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
        public ButtonTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ButtonTagHelper().ToWrapper();
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
            result.Append( "<button nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<button #a=\"\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Primary );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzType=\"primary\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接按钮
        /// </summary>
        [Fact]
        public void TestLinkType() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzType]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestRouterLink() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link ).SetContextAttribute( AngularConst.RouterLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" routerLink=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestBindRouterLink() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link ).SetContextAttribute( AngularConst.BindRouterLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [routerLink]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试活动路由链接
        /// </summary>
        [Fact]
        public void TestRouterLinkActive() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link ).SetContextAttribute( AngularConst.RouterLinkActive, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" routerLinkActive=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试活动路由链接
        /// </summary>
        [Fact]
        public void TestBindRouterLinkActive() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link ).SetContextAttribute( AngularConst.BindRouterLinkActive, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [routerLinkActive]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, ButtonSize.Small );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzSize=\"small\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzSize]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮形状
        /// </summary>
        [Fact]
        public void TestShape() {
            _wrapper.SetContextAttribute( UiConst.Shape, ButtonShape.Circle );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" nzShape=\"circle\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮形状
        /// </summary>
        [Fact]
        public void TestBindShape() {
            _wrapper.SetContextAttribute( AngularConst.BindShape, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzShape]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [disabled]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [disabled]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试危险按钮
        /// </summary>
        [Fact]
        public void TestDanger() {
            _wrapper.SetContextAttribute( UiConst.Danger, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzDanger]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试危险按钮
        /// </summary>
        [Fact]
        public void TestBindDanger() {
            _wrapper.SetContextAttribute( AngularConst.BindDanger, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzDanger]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzLoading]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestBindLoading() {
            _wrapper.SetContextAttribute( AngularConst.BindLoading, "true" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzLoading]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试幽灵按钮
        /// </summary>
        [Fact]
        public void TestGhost() {
            _wrapper.SetContextAttribute( UiConst.Ghost, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzGhost]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试幽灵按钮
        /// </summary>
        [Fact]
        public void TestBindGhost() {
            _wrapper.SetContextAttribute( AngularConst.BindGhost, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzGhost]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Block按钮
        /// </summary>
        [Fact]
        public void TestBlock() {
            _wrapper.SetContextAttribute( UiConst.Block, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzBlock]=\"true\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Block按钮
        /// </summary>
        [Fact]
        public void TestBindBlock() {
            _wrapper.SetContextAttribute( AngularConst.BindBlock, "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" [nzBlock]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置图标
        /// </summary>
        [Fact]
        public void TestIcon() {
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.Check );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"check\"></i>a" );
            result.Append( "</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置图标
        /// </summary>
        [Fact]
        public void TestIcon_2() {
            var icon = new IconTagHelper().ToWrapper();
            icon.SetContextAttribute( UiConst.Type, AntDesignIcon.Check );
            _wrapper.AppendContent( icon );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"check\"></i>" );
            result.Append( "</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\">a</button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<button (click)=\"a\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
