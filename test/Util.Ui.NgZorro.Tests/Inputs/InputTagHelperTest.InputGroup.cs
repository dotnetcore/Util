using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 输入框组合相关
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试前置标签
        /// </summary>
        [Fact]
        public void TestAddOnBefore() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBefore=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签 - 设置大小
        /// </summary>
        [Fact]
        public void TestAddOnBefore_Size() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBefore=\"a\" nzSize=\"large\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签 - 设置大小
        /// </summary>
        [Fact]
        public void TestAddOnBefore_BindSize() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            _wrapper.SetContextAttribute( AngularConst.BindSize, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBefore=\"a\" [nzSize]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签 - 设置状态
        /// </summary>
        [Fact]
        public void TestAddOnBefore_Status() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            _wrapper.SetContextAttribute( UiConst.Status, FormControlStatus.Error );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBefore=\"a\" nzStatus=\"error\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签 - 设置状态
        /// </summary>
        [Fact]
        public void TestAddOnBefore_BindStatus() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            _wrapper.SetContextAttribute( AngularConst.BindStatus, "b" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBefore=\"a\" [nzStatus]=\"b\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签
        /// </summary>
        [Fact]
        public void TestBindAddOnBefore() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnBefore, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnBefore]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置标签
        /// </summary>
        [Fact]
        public void TestAddOnAfter() {
            _wrapper.SetContextAttribute( UiConst.AddOnAfter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnAfter=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置标签
        /// </summary>
        [Fact]
        public void TestBindAddOnAfter() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnAfter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnAfter]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置图标
        /// </summary>
        [Fact]
        public void TestAddOnBeforeIcon() {
            _wrapper.SetContextAttribute( UiConst.AddOnBeforeIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBeforeIcon=\"account-book\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置图标
        /// </summary>
        [Fact]
        public void TestBindAddOnBeforeIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnBeforeIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnBeforeIcon]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置图标
        /// </summary>
        [Fact]
        public void TestAddOnAfterIcon() {
            _wrapper.SetContextAttribute( UiConst.AddOnAfterIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnAfterIcon=\"account-book\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置图标
        /// </summary>
        [Fact]
        public void TestBindAddOnAfterIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnAfterIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnAfterIcon]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置图标 - 同时设置前置图标
        /// </summary>
        [Fact]
        public void TestAddOnAfterIcon_2() {
            _wrapper.SetContextAttribute( UiConst.AddOnBeforeIcon, AntDesignIcon.AccountBook ).SetContextAttribute( UiConst.AddOnAfterIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnAfterIcon=\"account-book\" nzAddOnBeforeIcon=\"account-book\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            _wrapper.SetContextAttribute( UiConst.Prefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzPrefix=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀
        /// </summary>
        [Fact]
        public void TestBindPrefix() {
            _wrapper.SetContextAttribute( AngularConst.BindPrefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzPrefix]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀
        /// </summary>
        [Fact]
        public void TestSuffix() {
            _wrapper.SetContextAttribute( UiConst.Suffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSuffix=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀
        /// </summary>
        [Fact]
        public void TestBindSuffix() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀图标
        /// </summary>
        [Fact]
        public void TestPrefixIcon() {
            _wrapper.SetContextAttribute( UiConst.PrefixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzPrefixIcon=\"account-book\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀图标
        /// </summary>
        [Fact]
        public void TestBindPrefixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindPrefixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzPrefixIcon]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestSuffixIcon() {
            _wrapper.SetContextAttribute( UiConst.SuffixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSuffixIcon=\"account-book\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffixIcon]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标 - 属性设置在input上,外层添加input-group标签
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon_2() {
            var inputGroup = new InputGroupTagHelper().ToWrapper();
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            inputGroup.AppendContent( _wrapper );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffixIcon]=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), inputGroup.GetResult() );
        }

        /// <summary>
        /// 测试允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear() {
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除 - 全局设置
        /// </summary>
        [Fact]
        public void TestAllowClear_2() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableAllowClear = true } );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除 - 手工创建输入框组
        /// </summary>
        [Fact]
        public void TestAllowClear_3() {
            //设置输入框允许清除
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );

            //创建输入框组
            var inputGroup = new InputGroupTagHelper().ToWrapper();
            inputGroup.SetContextAttribute( UiConst.Size, InputSize.Small );
            inputGroup.AppendContent( _wrapper );

            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSize=\"small\" [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );

            //执行
            var html = inputGroup.GetResult();
            _output.WriteLine( html );

            //验证
            Assert.Equal( result.ToString(), html );
        }

        /// <summary>
        /// 测试允许清除 - 设置表单控件实例 ,禁用允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear_4() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableAllowClear = true } );
            _wrapper.SetContextAttribute( UiConst.FormControl, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [formControl]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除 - 未设置ngModel,禁用允许清除
        /// </summary>
        [Fact]
        public void TestAllowClear_5() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableAllowClear = true } );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除 - 指定后缀图标
        /// </summary>
        [Fact]
        public void TestAllowClear_6() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableAllowClear = true } );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( UiConst.Suffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSuffix=\"a\">" );
            result.Append( "<input nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试允许清除 - 指定后缀图标
        /// </summary>
        [Fact]
        public void TestAllowClear_7() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableAllowClear = true } );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            _wrapper.SetContextAttribute( AngularConst.BindSuffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"a\">" );
            result.Append( "<input nz-input=\"\" [(ngModel)]=\"code\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试密码类型
        /// </summary>
        [Fact]
        public void TestType_Password() {
            _wrapper.SetContextAttribute( UiConst.Type, InputType.Password );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"xi_id.passwordVisible = !xi_id.passwordVisible\" nz-icon=\"\" [nzType]=\"xi_id.passwordVisible?'eye-invisible':'eye'\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #xi_id=\"xInputExtend\" nz-input=\"\" x-input-extend=\"\" [type]=\"xi_id.passwordVisible?'text':'password'\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试密码类型允许清除
        /// </summary>
        [Fact]
        public void TestPassword_AllowClear() {
            _wrapper.SetContextAttribute( UiConst.Type, InputType.Password );
            _wrapper.SetContextAttribute( UiConst.AllowClear, true );
            _wrapper.SetContextAttribute( AngularConst.NgModel, "code" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"tmp_id\">" );
            result.Append( "<ng-template #tmp_id=\"\">" );
            result.Append( "<span (click)=\"xi_id.passwordVisible = !xi_id.passwordVisible\" nz-icon=\"\" [nzType]=\"xi_id.passwordVisible?'eye-invisible':'eye'\"></span>" );
            result.Append( "<span (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></span>" );
            result.Append( "</ng-template>" );
            result.Append( "<input #model_id=\"ngModel\" #xi_id=\"xInputExtend\" nz-input=\"\" x-input-extend=\"\" [(ngModel)]=\"code\" [type]=\"xi_id.passwordVisible?'text':'password'\" />" );
            result.Append( "</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

