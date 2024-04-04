using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 间距相关
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.Required, "true" );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "model" );
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );

            var result = new StringBuilder();
            result.Append( "<nz-form-item *nzSpaceItem=\"\">" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_id\">" );
            result.Append( "<input #v_id=\"xValidationExtend\" nz-input=\"\" x-validation-extend=\"\" [(ngModel)]=\"model\" [x-required-extend]=\"true\" />" );
            result.Append( "<ng-template #vt_id=\"\">" );
            result.Append( "{{v_id.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

