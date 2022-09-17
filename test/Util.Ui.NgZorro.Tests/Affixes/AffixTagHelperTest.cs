using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Affixes;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Affixes {
    /// <summary>
    /// 固钉测试
    /// </summary>
    public class AffixTagHelperTest {
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
        public AffixTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new AffixTagHelper().ToWrapper();
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
            result.Append( "<nz-affix></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试顶部偏移量
        /// </summary>
        [Fact]
        public void TestOffsetTop() {
            _wrapper.SetContextAttribute( UiConst.OffsetTop, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-affix [nzOffsetTop]=\"1\"></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试顶部偏移量
        /// </summary>
        [Fact]
        public void TestBindOffsetTop() {
            _wrapper.SetContextAttribute( AngularConst.BindOffsetTop, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-affix [nzOffsetTop]=\"a\"></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部偏移量
        /// </summary>
        [Fact]
        public void TestOffsetBottom() {
            _wrapper.SetContextAttribute( UiConst.OffsetBottom, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-affix [nzOffsetBottom]=\"1\"></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部偏移量
        /// </summary>
        [Fact]
        public void TestBindOffsetBottom() {
            _wrapper.SetContextAttribute( AngularConst.BindOffsetBottom, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-affix [nzOffsetBottom]=\"a\"></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试目标
        /// </summary>
        [Fact]
        public void TestTarget() {
            _wrapper.SetContextAttribute( UiConst.Target, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-affix [nzTarget]=\"a\"></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-affix>a</nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-affix (nzChange)=\"a\"></nz-affix>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}