using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Collapses;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Collapses {
    /// <summary>
    /// 折叠面板测试
    /// </summary>
    public class CollapsePanelTagHelperTest {
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
        public CollapsePanelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CollapsePanelTagHelper().ToWrapper();
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
            result.Append( "<nz-collapse-panel></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzDisabled]=\"true\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzDisabled]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板头内容
        /// </summary>
        [Fact]
        public void TestHeader() {
            _wrapper.SetContextAttribute( UiConst.Header, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel nzHeader=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板头内容
        /// </summary>
        [Fact]
        public void TestBindHeader() {
            _wrapper.SetContextAttribute( AngularConst.BindHeader, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzHeader]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestExpandedIcon() {
            _wrapper.SetContextAttribute( UiConst.ExpandedIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel nzExpandedIcon=\"account-book\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestBindExpandedIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindExpandedIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzExpandedIcon]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右上角额外内容
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel nzExtra=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试右上角额外内容
        /// </summary>
        [Fact]
        public void TestBindExtra() {
            _wrapper.SetContextAttribute( AngularConst.BindExtra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzExtra]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示箭头
        /// </summary>
        [Fact]
        public void TestShowArrow() {
            _wrapper.SetContextAttribute( UiConst.ShowArrow, true );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzShowArrow]=\"true\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示箭头
        /// </summary>
        [Fact]
        public void TestBindShowArrow() {
            _wrapper.SetContextAttribute( AngularConst.BindShowArrow, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzShowArrow]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否展开面板
        /// </summary>
        [Fact]
        public void TestActive() {
            _wrapper.SetContextAttribute( UiConst.Active, true );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzActive]=\"true\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否展开面板
        /// </summary>
        [Fact]
        public void TestBindActive() {
            _wrapper.SetContextAttribute( AngularConst.BindActive, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [nzActive]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否展开面板
        /// </summary>
        [Fact]
        public void TestBindonActive() {
            _wrapper.SetContextAttribute( AngularConst.BindonActive, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel [(nzActive)]=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel>a</nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试面板展开变化事件
        /// </summary>
        [Fact]
        public void TestOnActiveChange() {
            _wrapper.SetContextAttribute( UiConst.OnActiveChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse-panel (nzActiveChange)=\"a\"></nz-collapse-panel>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}