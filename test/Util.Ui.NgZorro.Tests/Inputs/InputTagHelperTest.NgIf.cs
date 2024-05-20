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
            result.Append( "<ng-container *ngIf=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</ng-container>" );
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

        /// <summary>
        /// 测试ngIf* - 生成nz-input-group容器
        /// </summary>
        [Fact]
        public void TestNgIf_3() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" )
                .SetContextAttribute( AngularConst.NgIf, "a" );
            var result = new StringBuilder();
            result.Append( "<ng-container *ngIf=\"a\">" );
            result.Append( "<nz-input-group [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "</ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试ngIf* - 生成form-item容器 和 nz-input-group容器
        /// </summary>
        [Fact]
        public void TestNgIf_4() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true )
                .SetContextAttribute( AngularConst.NgModel, "code" )
                .SetContextAttribute( UiConst.LabelText, "a" )
                .SetContextAttribute( AngularConst.NgIf, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item *ngIf=\"b\">" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-group [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

