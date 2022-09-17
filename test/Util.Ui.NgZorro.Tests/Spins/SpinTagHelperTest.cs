using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spins;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Spins {
    /// <summary>
    /// 加载中测试
    /// </summary>
    public class SpinTagHelperTest {
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
        public SpinTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SpinTagHelper().ToWrapper();
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
            result.Append( "<nz-spin></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试延迟显示时间
        /// </summary>
        [Fact]
        public void TestDelay() {
            _wrapper.SetContextAttribute( UiConst.Delay, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-spin nzDelay=\"1\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试延迟显示时间
        /// </summary>
        [Fact]
        public void TestBindDelay() {
            _wrapper.SetContextAttribute( AngularConst.BindDelay, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzDelay]=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载指示符
        /// </summary>
        [Fact]
        public void TestIndicator() {
            _wrapper.SetContextAttribute( UiConst.Indicator, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzIndicator]=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, SpinSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-spin nzSize=\"large\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzSize]=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否旋转
        /// </summary>
        [Fact]
        public void TestSpinning() {
            _wrapper.SetContextAttribute( UiConst.Spinning, true );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzSpinning]=\"true\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否旋转
        /// </summary>
        [Fact]
        public void TestBindSpinning() {
            _wrapper.SetContextAttribute( AngularConst.BindSpinning, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzSpinning]=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否简单模式
        /// </summary>
        [Fact]
        public void TestSimple() {
            _wrapper.SetContextAttribute( UiConst.Simple, true );
            var result = new StringBuilder();
            result.Append( "<nz-spin nzSimple=\"\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否简单模式
        /// </summary>
        [Fact]
        public void TestBindSimple() {
            _wrapper.SetContextAttribute( AngularConst.BindSimple, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzSimple]=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestTip() {
            _wrapper.SetContextAttribute( UiConst.Tip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin nzTip=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestBindTip() {
            _wrapper.SetContextAttribute( AngularConst.BindTip, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin [nzTip]=\"a\"></nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-spin>a</nz-spin>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}