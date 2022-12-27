using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
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
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"clear_id\">" );
            result.Append( "<input #model_id=\"ngModel\" nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "<ng-template #clear_id=\"\">" );
            result.Append( "<i (click)=\"model_id.reset()\" *ngIf=\"model_id.value\" class=\"ant-input-clear-icon\" nz-icon=\"\" nzTheme=\"fill\" nzType=\"close-circle\"></i>" );
            result.Append( "</ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

