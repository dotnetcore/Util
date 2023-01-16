using System;
using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试
    /// </summary>
    public partial class InputTagHelperTest : IDisposable {
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
        public InputTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new InputTagHelper().ToWrapper<Customer>();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Id.Reset();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            return GetResult(_wrapper);
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperWrapper wrapper ) {
            var result = wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置占位符提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" placeholder=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置占位符提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [placeholder]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [disabled]=\"true\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [disabled]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadonly() {
            _wrapper.SetContextAttribute( UiConst.Readonly, true );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [readOnly]=\"true\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestBindReadonly() {
            _wrapper.SetContextAttribute( AngularConst.BindReadonly, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [readOnly]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" nzSize=\"large\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [nzSize]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, InputType.Password );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" type=\"password\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型 - 电子邮件
        /// </summary>
        [Fact]
        public void TestType_Email() {
            _wrapper.SetContextAttribute( UiConst.Type, InputType.Email );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" type=\"email\" [email]=\"true\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [type]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入事件
        /// </summary>
        [Fact]
        public void TestOnInput() {
            _wrapper.SetContextAttribute( UiConst.OnInput, "a" );
            var result = new StringBuilder();
            result.Append( "<input (input)=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

