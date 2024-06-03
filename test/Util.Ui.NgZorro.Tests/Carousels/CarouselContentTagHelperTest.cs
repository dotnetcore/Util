using System.Text;
using Util.Ui.NgZorro.Components.Carousels;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Carousels {
    /// <summary>
    /// 走马灯内容区域测试
    /// </summary>
    public class CarouselContentTagHelperTest {
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
        public CarouselContentTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CarouselContentTagHelper().ToWrapper();
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
            result.Append( "<div nz-carousel-content=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}