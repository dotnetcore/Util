using System.Text;
using Util.Ui.NgZorro.Components.Typographies;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Typographies {
    /// <summary>
    /// h1-h6组件测试
    /// </summary>
    public class HTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public HTagHelperTest( ITestOutputHelper output ) {
            _output = output;
        }

        /// <summary>
        /// 测试h1
        /// </summary>
        [Fact]
        public void TestH1() {
            var component = new H1TagHelper().ToWrapper();
            var result = new StringBuilder();
            result.Append( "<h1 nz-typography=\"\"></h1>" );
            Assert.Equal( result.ToString(), component.GetResult() );
        }

        /// <summary>
        /// 测试h2
        /// </summary>
        [Fact]
        public void TestH2() {
            var component = new H2TagHelper().ToWrapper();
            var result = new StringBuilder();
            result.Append( "<h2 nz-typography=\"\"></h2>" );
            Assert.Equal( result.ToString(), component.GetResult() );
        }

        /// <summary>
        /// 测试h3
        /// </summary>
        [Fact]
        public void TestH3() {
            var component = new H3TagHelper().ToWrapper();
            var result = new StringBuilder();
            result.Append( "<h3 nz-typography=\"\"></h3>" );
            Assert.Equal( result.ToString(), component.GetResult() );
        }

        /// <summary>
        /// 测试h4
        /// </summary>
        [Fact]
        public void TestH4() {
            var component = new H4TagHelper().ToWrapper();
            var result = new StringBuilder();
            result.Append( "<h4 nz-typography=\"\"></h4>" );
            Assert.Equal( result.ToString(), component.GetResult() );
        }

        /// <summary>
        /// 测试h5
        /// </summary>
        [Fact]
        public void TestH5() {
            var component = new H5TagHelper().ToWrapper();
            var result = new StringBuilder();
            result.Append( "<h5 nz-typography=\"\"></h5>" );
            Assert.Equal( result.ToString(), component.GetResult() );
        }

        /// <summary>
        /// 测试h6
        /// </summary>
        [Fact]
        public void TestH6() {
            var component = new H6TagHelper().ToWrapper();
            var result = new StringBuilder();
            result.Append( "<h6 nz-typography=\"\"></h6>" );
            Assert.Equal( result.ToString(), component.GetResult() );
        }
    }
}