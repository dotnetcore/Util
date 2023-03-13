using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - ngIf*
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试*ngIf - 仅输入框组件
        /// </summary>
        [Fact]
        public void TestNgIf_1() {
            _wrapper.SetContextAttribute( AngularConst.NgIf, "a" );
            var result = new StringBuilder();
            result.Append( "<input *ngIf=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试ngIf* - 生成form-item容器
        /// </summary>
        [Fact]
        public void TestNgIf_2() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" )
                .SetContextAttribute( AngularConst.NgIf,"a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item *ngIf=\"a\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

