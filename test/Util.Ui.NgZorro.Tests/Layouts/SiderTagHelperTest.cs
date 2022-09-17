using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Layouts {
    /// <summary>
    /// 侧边栏布局测试
    /// </summary>
    public class SiderTagHelperTest {
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
        public SiderTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SiderTagHelper().ToWrapper();
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
            result.Append( "<nz-sider></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            _wrapper.SetContextAttribute( UiConst.Width, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider nzWidth=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzWidth]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试主题
        /// </summary>
        [Fact]
        public void TestTheme() {
            _wrapper.SetContextAttribute( UiConst.Theme, SiderTheme.Dark );
            var result = new StringBuilder();
            result.Append( "<nz-sider nzTheme=\"dark\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试主题
        /// </summary>
        [Fact]
        public void TestBindTheme() {
            _wrapper.SetContextAttribute( AngularConst.BindTheme, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzTheme]=\"Ab\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试响应式布局断点
        /// </summary>
        [Fact]
        public void TestBreakpoint() {
            _wrapper.SetContextAttribute( UiConst.Breakpoint, GridSize.Md );
            var result = new StringBuilder();
            result.Append( "<nz-sider nzBreakpoint=\"md\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试响应式布局断点
        /// </summary>
        [Fact]
        public void TestBindBreakpoint() {
            _wrapper.SetContextAttribute( AngularConst.BindBreakpoint, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzBreakpoint]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试收缩宽度
        /// </summary>
        [Fact]
        public void TestCollapsedWidth() {
            _wrapper.SetContextAttribute( UiConst.CollapsedWidth, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzCollapsedWidth]=\"1\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试收缩宽度
        /// </summary>
        [Fact]
        public void TestBindCollapsedWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindCollapsedWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzCollapsedWidth]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可收缩
        /// </summary>
        [Fact]
        public void TestCollapsible() {
            _wrapper.SetContextAttribute( UiConst.Collapsible, true );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzCollapsible]=\"true\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试可收缩
        /// </summary>
        [Fact]
        public void TestBindCollapsible() {
            _wrapper.SetContextAttribute( AngularConst.BindCollapsible, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzCollapsible]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试收缩状态
        /// </summary>
        [Fact]
        public void TestCollapsed() {
            _wrapper.SetContextAttribute( UiConst.Collapsed, true );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzCollapsed]=\"true\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试收缩状态
        /// </summary>
        [Fact]
        public void TestBindCollapsed() {
            _wrapper.SetContextAttribute( AngularConst.BindCollapsed, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzCollapsed]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试收缩状态
        /// </summary>
        [Fact]
        public void TestBindonCollapsed() {
            _wrapper.SetContextAttribute( AngularConst.BindonCollapsed, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [(nzCollapsed)]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试翻转折叠提示箭头方向
        /// </summary>
        [Fact]
        public void TestReverseArrow() {
            _wrapper.SetContextAttribute( UiConst.ReverseArrow, true );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzReverseArrow]=\"true\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试翻转折叠提示箭头方向
        /// </summary>
        [Fact]
        public void TestBindReverseArrow() {
            _wrapper.SetContextAttribute( AngularConst.BindReverseArrow, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzReverseArrow]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义触发器
        /// </summary>
        [Fact]
        public void TestTrigger() {
            _wrapper.SetContextAttribute( UiConst.Trigger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzTrigger]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试0触发器
        /// </summary>
        [Fact]
        public void TestZeroTrigger() {
            _wrapper.SetContextAttribute( AntDesignConst.ZeroTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider [nzZeroTrigger]=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider>" );
            result.Append( "a" );
            result.Append( "</nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnCollapsedChange() {
            _wrapper.SetContextAttribute( UiConst.OnCollapsedChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-sider (nzCollapsedChange)=\"a\"></nz-sider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}