using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Rates;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Rates {
    /// <summary>
    /// 评分测试
    /// </summary>
    public class RateTagHelperTest {
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
        public RateTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new RateTagHelper().ToWrapper();
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
            result.Append( "<nz-rate></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzAllowClear]=\"true\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestBindAllowClear() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowClear, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzAllowClear]=\"Ab\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许半选
        /// </summary>
        [Fact]
        public void TestAllowHalf() {
            _wrapper.SetContextAttribute( UiConst.AllowHalf, true );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzAllowHalf]=\"true\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许半选
        /// </summary>
        [Fact]
        public void TestBindAllowHalf() {
            _wrapper.SetContextAttribute( AngularConst.BindAllowHalf, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzAllowHalf]=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzAutoFocus]=\"true\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzAutoFocus]=\"Ab\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自定义字符
        /// </summary>
        [Fact]
        public void TestCharacter() {
            _wrapper.SetContextAttribute( UiConst.Character, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzCharacter]=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数量
        /// </summary>
        [Fact]
        public void TestCount() {
            _wrapper.SetContextAttribute( UiConst.Count, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-rate nzCount=\"1\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数量
        /// </summary>
        [Fact]
        public void TestBindCount() {
            _wrapper.SetContextAttribute( AngularConst.BindCount, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzCount]=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzDisabled]=\"true\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzDisabled]=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示信息
        /// </summary>
        [Fact]
        public void TestTooltips() {
            _wrapper.SetContextAttribute( UiConst.Tooltips, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate [nzTooltips]=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate>a</nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate (ngModelChange)=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            _wrapper.SetContextAttribute( UiConst.OnFocus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate (nzOnFocus)=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            _wrapper.SetContextAttribute( UiConst.OnBlur, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate (nzOnBlur)=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试滑动变更事件
        /// </summary>
        [Fact]
        public void TestOnHoverChange() {
            _wrapper.SetContextAttribute( UiConst.OnHoverChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate (nzOnHoverChange)=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeyDown() {
            _wrapper.SetContextAttribute( UiConst.OnKeydown, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-rate (nzOnKeyDown)=\"a\"></nz-rate>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}