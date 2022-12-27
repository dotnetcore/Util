using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tabs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tabs {
    /// <summary>
    /// 标签页测试
    /// </summary>
    public class TabSetTagHelperTest {
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
        public TabSetTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TabSetTagHelper().ToWrapper();
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
            result.Append( "<nz-tabset></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中标签索引
        /// </summary>
        [Fact]
        public void TestSelectedIndex() {
            _wrapper.SetContextAttribute( UiConst.SelectedIndex, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tabset nzSelectedIndex=\"1\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中标签索引
        /// </summary>
        [Fact]
        public void TestBindSelectedIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindSelectedIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzSelectedIndex]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中标签索引
        /// </summary>
        [Fact]
        public void TestBindonSelectedIndex() {
            _wrapper.SetContextAttribute( AngularConst.BindonSelectedIndex, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [(nzSelectedIndex)]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否使用动画切换选项卡
        /// </summary>
        [Fact]
        public void TestAnimated() {
            _wrapper.SetContextAttribute( UiConst.Animated, true );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzAnimated]=\"true\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否使用动画切换选项卡
        /// </summary>
        [Fact]
        public void TestBindAnimated() {
            _wrapper.SetContextAttribute( AngularConst.BindAnimated, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzAnimated]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, TabSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-tabset nzSize=\"small\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzSize]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签栏附加内容
        /// </summary>
        [Fact]
        public void TestTabBarExtraContent() {
            _wrapper.SetContextAttribute( UiConst.TabBarExtraContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzTabBarExtraContent]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签栏样式
        /// </summary>
        [Fact]
        public void TestTabBarStyle() {
            _wrapper.SetContextAttribute( UiConst.TabBarStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzTabBarStyle]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestTabPosition() {
            _wrapper.SetContextAttribute( UiConst.TabPosition, TabPosition.Left );
            var result = new StringBuilder();
            result.Append( "<nz-tabset nzTabPosition=\"left\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestBindTabPosition() {
            _wrapper.SetContextAttribute( AngularConst.BindTabPosition, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzTabPosition]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, TabType.EditableCard );
            var result = new StringBuilder();
            result.Append( "<nz-tabset nzType=\"editable-card\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzType]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签间隙
        /// </summary>
        [Fact]
        public void TestTabBarGutter() {
            _wrapper.SetContextAttribute( UiConst.TabBarGutter, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-tabset nzTabBarGutter=\"1\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签间隙
        /// </summary>
        [Fact]
        public void TestBindTabBarGutter() {
            _wrapper.SetContextAttribute( AngularConst.BindTabBarGutter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzTabBarGutter]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否隐藏全部标签
        /// </summary>
        [Fact]
        public void TestHideAll() {
            _wrapper.SetContextAttribute( UiConst.HideAll, true );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzHideAll]=\"true\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否隐藏全部标签
        /// </summary>
        [Fact]
        public void TestBindHideAll() {
            _wrapper.SetContextAttribute( AngularConst.BindHideAll, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzHideAll]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持路由联动
        /// </summary>
        [Fact]
        public void TestLinkRouter() {
            _wrapper.SetContextAttribute( UiConst.LinkRouter, true );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzLinkRouter]=\"true\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否支持路由联动
        /// </summary>
        [Fact]
        public void TestBindLinkRouter() {
            _wrapper.SetContextAttribute( AngularConst.BindLinkRouter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzLinkRouter]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否以严格模式匹配路由联动
        /// </summary>
        [Fact]
        public void TestLinkExact() {
            _wrapper.SetContextAttribute( UiConst.LinkExact, true );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzLinkExact]=\"true\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否以严格模式匹配路由联动
        /// </summary>
        [Fact]
        public void TestBindLinkExact() {
            _wrapper.SetContextAttribute( AngularConst.BindLinkExact, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzLinkExact]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签守卫函数
        /// </summary>
        [Fact]
        public void TestCanDeactivate() {
            _wrapper.SetContextAttribute( UiConst.CanDeactivate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzCanDeactivate]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签是否居中显示
        /// </summary>
        [Fact]
        public void TestCentered() {
            _wrapper.SetContextAttribute( UiConst.Centered, true );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzCentered]=\"true\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签是否居中显示
        /// </summary>
        [Fact]
        public void TestBindCentered() {
            _wrapper.SetContextAttribute( AngularConst.BindCentered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzCentered]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否隐藏添加按钮
        /// </summary>
        [Fact]
        public void TestHideAdd() {
            _wrapper.SetContextAttribute( UiConst.HideAdd, true );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzHideAdd]=\"true\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否隐藏添加按钮
        /// </summary>
        [Fact]
        public void TestBindHideAdd() {
            _wrapper.SetContextAttribute( AngularConst.BindHideAdd, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzHideAdd]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加按钮图标
        /// </summary>
        [Fact]
        public void TestAddIcon() {
            _wrapper.SetContextAttribute( UiConst.AddIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-tabset nzAddIcon=\"account-book\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加按钮图标
        /// </summary>
        [Fact]
        public void TestBindAddIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindAddIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset [nzAddIcon]=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset>a</nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中标签索引变化事件
        /// </summary>
        [Fact]
        public void TestOnSelectedIndexChange() {
            _wrapper.SetContextAttribute( UiConst.OnSelectedIndexChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset (nzSelectedIndexChange)=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中标签变化事件
        /// </summary>
        [Fact]
        public void TestOnSelectChange() {
            _wrapper.SetContextAttribute( UiConst.OnSelectChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset (nzSelectChange)=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标签事件
        /// </summary>
        [Fact]
        public void TestOnAdd() {
            _wrapper.SetContextAttribute( UiConst.OnAdd, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset (nzAdd)=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭标签事件
        /// </summary>
        [Fact]
        public void TestOnClose() {
            _wrapper.SetContextAttribute( UiConst.OnClose, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tabset (nzClose)=\"a\"></nz-tabset>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}