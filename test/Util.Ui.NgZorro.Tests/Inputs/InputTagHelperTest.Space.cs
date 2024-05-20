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
        public void TestSpaceItem_1() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );

            var result = new StringBuilder();
            result.Append( "<input *nzSpaceItem=\"\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项 - 创建 nz-input-group
        /// </summary>
        [Fact]
        public void TestSpaceItem_2() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );

            var result = new StringBuilder();
            result.Append( "<nz-input-group *nzSpaceItem=\"\" [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项 - 创建 nz-form-item
        /// </summary>
        [Fact]
        public void TestSpaceItem_3() {
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

