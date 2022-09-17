using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框组合测试
    /// </summary>
    public class InputGroupTagHelperTest {
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
        public InputGroupTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new InputGroupTagHelper().ToWrapper();
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
            result.Append( "<nz-input-group></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签
        /// </summary>
        [Fact]
        public void TestAddOnBefore() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBefore=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置标签
        /// </summary>
        [Fact]
        public void TestBindAddOnBefore() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnBefore, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnBefore]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置标签
        /// </summary>
        [Fact]
        public void TestAddOnAfter() {
            _wrapper.SetContextAttribute( UiConst.AddOnAfter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnAfter=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置标签
        /// </summary>
        [Fact]
        public void TestBindAddOnAfter() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnAfter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnAfter]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置图标
        /// </summary>
        [Fact]
        public void TestAddOnBeforeIcon() {
            _wrapper.SetContextAttribute( UiConst.AddOnBeforeIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnBeforeIcon=\"account-book\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前置图标
        /// </summary>
        [Fact]
        public void TestBindAddOnBeforeIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnBeforeIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnBeforeIcon]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置图标
        /// </summary>
        [Fact]
        public void TestAddOnAfterIcon() {
            _wrapper.SetContextAttribute( UiConst.AddOnAfterIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzAddOnAfterIcon=\"account-book\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后置图标
        /// </summary>
        [Fact]
        public void TestBindAddOnAfterIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindAddOnAfterIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzAddOnAfterIcon]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            _wrapper.SetContextAttribute( UiConst.Prefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzPrefix=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀
        /// </summary>
        [Fact]
        public void TestBindPrefix() {
            _wrapper.SetContextAttribute( AngularConst.BindPrefix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzPrefix]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀
        /// </summary>
        [Fact]
        public void TestSuffix() {
            _wrapper.SetContextAttribute( UiConst.Suffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSuffix=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀
        /// </summary>
        [Fact]
        public void TestBindSuffix() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffix]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀图标
        /// </summary>
        [Fact]
        public void TestPrefixIcon() {
            _wrapper.SetContextAttribute( UiConst.PrefixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzPrefixIcon=\"account-book\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试前缀图标
        /// </summary>
        [Fact]
        public void TestBindPrefixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindPrefixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzPrefixIcon]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestSuffixIcon() {
            _wrapper.SetContextAttribute( UiConst.SuffixIcon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSuffixIcon=\"account-book\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试后缀图标
        /// </summary>
        [Fact]
        public void TestBindSuffixIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindSuffixIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSuffixIcon]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索框
        /// </summary>
        [Fact]
        public void TestSearch() {
            _wrapper.SetContextAttribute( UiConst.Search, true );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSearch]=\"true\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试搜索框
        /// </summary>
        [Fact]
        public void TestBindSearch() {
            _wrapper.SetContextAttribute( AngularConst.BindSearch, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSearch]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-input-group nzSize=\"large\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzSize]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试紧凑模式
        /// </summary>
        [Fact]
        public void TestCompact() {
            _wrapper.SetContextAttribute( UiConst.Compact, true );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzCompact]=\"true\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试紧凑模式
        /// </summary>
        [Fact]
        public void TestBindCompact() {
            _wrapper.SetContextAttribute( AngularConst.BindCompact, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group [nzCompact]=\"a\"></nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-group>a</nz-input-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表单容器属性
        /// </summary>
        [Fact]
        public void TestFormContainer() {
            _wrapper.SetContextAttribute( UiConst.AddOnBefore, "a" );

            var input = new InputTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelText, "b" );
            _wrapper.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>b</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-input-group nzAddOnBefore=\"a\">" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-input-group>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}