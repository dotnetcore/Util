using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Label;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Label {
    /// <summary>
    /// 标签测试
    /// </summary>
    public class LabelTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LabelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new LabelTagHelper().ToWrapper<Customer>();
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
            result.Append( "<span></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "a" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本 - 多语言
        /// </summary>
        [Fact]
        public void TestText_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{'a'|i18n}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "a" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式
        /// </summary>
        [Fact]
        public void TestFor() {
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<span>a.nickname</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试属性表达式 - 多语言
        /// </summary>
        [Fact]
        public void TestFor_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetExpression( t => t.Nickname );
            var result = new StringBuilder();
            result.Append( "<span>" );
            result.Append( "{{'a.nickname'|i18n}}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}