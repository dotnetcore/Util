using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.I18n;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgAlain.Tests.I18n {
    /// <summary>
    /// i18n多语言显示组件测试
    /// </summary>
    public class I18nTagHelperTest {
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
        public I18nTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new I18nTagHelper().ToWrapper();
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
        /// 测试键
        /// </summary>
        [Fact]
        public void TestKey() {
            _wrapper.SetContextAttribute( UiConst.Key, "a" );
            var result = new StringBuilder();
            result.Append( "<span [innerHTML]=\"'a'|i18n\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试参数 - 参数有大括号
        /// </summary>
        [Fact]
        public void TestParam_1() {
            _wrapper.SetContextAttribute( UiConst.Key, "a" );
            _wrapper.SetContextAttribute( UiConst.Param, " {id:1}" );
            var result = new StringBuilder();
            result.Append( "<span [innerHTML]=\"'a'|i18n:{id:1}\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试参数 - 参数没有大括号
        /// </summary>
        [Fact]
        public void TestParam_2() {
            _wrapper.SetContextAttribute( UiConst.Key, "a" );
            _wrapper.SetContextAttribute( UiConst.Param, "  id:1,name:'a' " );
            var result = new StringBuilder();
            result.Append( "<span [innerHTML]=\"'a'|i18n:{id:1,name:'a'}\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}