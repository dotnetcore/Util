using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Radios;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Radios {
    /// <summary>
    /// 单选框组合测试
    /// </summary>
    public partial class RadioGroupTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RadioGroupTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new RadioGroupTagHelper().ToWrapper<Customer>();
            Id.SetId( "id" );
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
            result.Append( "<nz-radio-group></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试名称
        /// </summary>
        [Fact]
        public void TestName() {
            _wrapper.SetContextAttribute( UiConst.Name, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group name=\"a\" nzName=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            _wrapper.SetContextAttribute( AngularConst.BindName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [name]=\"a\" [nzName]=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [nzDisabled]=\"true\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [nzDisabled]=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, ButtonSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group nzSize=\"large\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [nzSize]=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试风格
        /// </summary>
        [Fact]
        public void TestButtonStyle() {
            _wrapper.SetContextAttribute( UiConst.ButtonStyle, RadioStyle.Outline );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group nzButtonStyle=\"outline\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试风格
        /// </summary>
        [Fact]
        public void TestBindButtonStyle() {
            _wrapper.SetContextAttribute( AngularConst.BindButtonStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [nzButtonStyle]=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [(ngModel)]=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestBindNgModel() {
            _wrapper.SetContextAttribute( AngularConst.BindNgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group [ngModel]=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-radio-group (ngModelChange)=\"a\"></nz-radio-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}