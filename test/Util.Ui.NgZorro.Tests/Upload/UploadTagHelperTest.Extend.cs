using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Upload {
    /// <summary>
    /// 上传测试 - 扩展测试
    /// </summary>
    public partial class UploadTagHelperTest {
        /// <summary>
        /// 测试启用扩展 - 禁用扩展
        /// </summary>
        [Fact]
        public void TestEnableExtend() {
            _wrapper.SetContextAttribute( UiConst.EnableExtend, false );
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-upload>" );
            result.Append( GetButton() );
            result.Append( "</nz-upload>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}