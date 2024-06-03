using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Images;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Images {
    /// <summary>
    /// 图片分组测试
    /// </summary>
    public class ImageGroupTagHelperTest {
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
        public ImageGroupTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ImageGroupTagHelper().ToWrapper();
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
            result.Append( "<nz-image-group></nz-image-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试缩放的每步倍数
        /// </summary>
        [Fact]
        public void TestScaleStep() {
            _wrapper.SetContextAttribute( UiConst.ScaleStep, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-image-group [nzScaleStep]=\"a\"></nz-image-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}