using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Statistics;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Statistics {
    /// <summary>
    /// 倒计时测试
    /// </summary>
    public class CountdownTagHelperTest {
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
        public CountdownTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CountdownTagHelper().ToWrapper();
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
            result.Append( "<nz-countdown></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试格式化
        /// </summary>
        [Fact]
        public void TestFormat() {
            _wrapper.SetContextAttribute( UiConst.Format, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown nzFormat=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试格式化
        /// </summary>
        [Fact]
        public void TestBindFormat() {
            _wrapper.SetContextAttribute( AngularConst.BindFormat, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown [nzFormat]=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            _wrapper.SetContextAttribute( UiConst.Prefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown nzPrefix=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀
        /// </summary>
        [Fact]
        public void TestBindPrefix() {
            _wrapper.SetContextAttribute( AngularConst.BindPrefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown [nzPrefix]=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀
        /// </summary>
        [Fact]
        public void TestSuffix() {
            _wrapper.SetContextAttribute( UiConst.Suffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown nzSuffix=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀
        /// </summary>
        [Fact]
        public void TestBindSuffix() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown [nzSuffix]=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown nzTitle=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown [nzTitle]=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown nzValue=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestBindValue() {
            _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown [nzValue]=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模板
        /// </summary>
        [Fact]
        public void TestValueTemplate() {
            _wrapper.SetContextAttribute( UiConst.ValueTemplate, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown [nzValueTemplate]=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown>a</nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试倒计时完成事件
        /// </summary>
        [Fact]
        public void TestOnCountdownFinish() {
            _wrapper.SetContextAttribute( UiConst.OnCountdownFinish, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-countdown (nzCountdownFinish)=\"a\"></nz-countdown>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}