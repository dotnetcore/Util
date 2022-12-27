using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.InputNumbers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.InputNumbers {
    /// <summary>
    /// 数字输入框测试
    /// </summary>
    public partial class InputNumberTagHelperTest {
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
        public InputNumberTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new InputNumberTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-input-number></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框标识
        /// </summary>
        [Fact]
        public void TestInputId() {
            _wrapper.SetContextAttribute( UiConst.InputId, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzId=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [(ngModel)]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestBindNgModel() {
            _wrapper.SetContextAttribute( AngularConst.BindNgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [ngModel]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzAutoFocus]=\"true\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动聚焦
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzAutoFocus]=\"Ab\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzDisabled]=\"true\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzDisabled]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大值
        /// </summary>
        [Fact]
        public void TestMax() {
            _wrapper.SetContextAttribute( UiConst.Max, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzMax=\"1\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最大值
        /// </summary>
        [Fact]
        public void TestBindMax() {
            _wrapper.SetContextAttribute( AngularConst.BindMax, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzMax]=\"1\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小值
        /// </summary>
        [Fact]
        public void TestMin() {
            _wrapper.SetContextAttribute( UiConst.Min, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzMin=\"1\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试最小值
        /// </summary>
        [Fact]
        public void TestBindMin() {
            _wrapper.SetContextAttribute( AngularConst.BindMin, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzMin]=\"1\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试格式化函数
        /// </summary>
        [Fact]
        public void TestFormatter() {
            _wrapper.SetContextAttribute( UiConst.Formatter,"a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzFormatter]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试转换函数
        /// </summary>
        [Fact]
        public void TestParser() {
            _wrapper.SetContextAttribute( UiConst.Parser, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzParser]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试精度
        /// </summary>
        [Fact]
        public void TestPrecision() {
            _wrapper.SetContextAttribute( UiConst.Precision, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzPrecision=\"1\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试精度
        /// </summary>
        [Fact]
        public void TestBindPrecision() {
            _wrapper.SetContextAttribute( AngularConst.BindPrecision, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzPrecision]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试精度模式
        /// </summary>
        [Fact]
        public void TestPrecisionMode() {
            _wrapper.SetContextAttribute( UiConst.PrecisionMode, InputNumberPrecisionMode.ToFixed );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzPrecisionMode=\"toFixed\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试精度模式
        /// </summary>
        [Fact]
        public void TestBindPrecisionMode() {
            _wrapper.SetContextAttribute( AngularConst.BindPrecisionMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzPrecisionMode]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzSize=\"large\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入框大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzSize]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试步数
        /// </summary>
        [Fact]
        public void TestStep() {
            _wrapper.SetContextAttribute( UiConst.Step, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzStep=\"1\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试步数
        /// </summary>
        [Fact]
        public void TestBindStep() {
            _wrapper.SetContextAttribute( AngularConst.BindStep, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzStep]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入模式
        /// </summary>
        [Fact]
        public void TestInputMode() {
            _wrapper.SetContextAttribute( UiConst.InputMode, InputMode.Search );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzInputMode=\"search\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入模式
        /// </summary>
        [Fact]
        public void TestBindInputMode() {
            _wrapper.SetContextAttribute( AngularConst.BindInputMode, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzInputMode]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number nzPlaceHolder=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number [nzPlaceHolder]=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number>a</nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            _wrapper.SetContextAttribute( UiConst.OnFocus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number (nzFocus)=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            _wrapper.SetContextAttribute( UiConst.OnBlur, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-input-number (nzBlur)=\"a\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<nz-input-number *nzSpaceItem=\"\"></nz-input-number>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}