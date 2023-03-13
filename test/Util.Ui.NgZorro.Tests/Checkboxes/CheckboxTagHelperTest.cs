using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Checkboxes;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Checkboxes {
    /// <summary>
    /// 复选框测试
    /// </summary>
    public partial class CheckboxTagHelperTest {
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
        public CheckboxTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CheckboxTagHelper().ToWrapper<Customer>();
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
            result.Append( "<label nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<label #a=\"\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            _wrapper.SetContextAttribute( UiConst.Name, "a" );
            var result = new StringBuilder();
            result.Append( "<label name=\"a\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            _wrapper.SetContextAttribute( AngularConst.BindName, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [name]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动获取焦点
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            _wrapper.SetContextAttribute( UiConst.AutoFocus, true );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzAutoFocus]=\"true\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试自动获取焦点
        /// </summary>
        [Fact]
        public void TestBindAutoFocus() {
            _wrapper.SetContextAttribute( AngularConst.BindAutoFocus, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzAutoFocus]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [(ngModel)]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzDisabled]=\"true\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzDisabled]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置中间状态
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            _wrapper.SetContextAttribute( UiConst.Indeterminate, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzIndeterminate]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" nzValue=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestBindValue() {
            _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzValue]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\">a</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\">{{a}}</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\">a</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容 - 如果设置内容,则label属性将无效
        /// </summary>
        [Fact]
        public void TestContent_2() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            _wrapper.AppendContent( "b" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\">b</label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件栅格跨度
        /// </summary>
        [Fact]
        public void TestControlSpan() {
            _wrapper.SetContextAttribute( UiConst.ControlSpan, 2 );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-control [nzSpan]=\"2\">" );
            result.Append( "<label nz-checkbox=\"\"></label>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<label *nzSpaceItem=\"\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中
        /// </summary>
        [Fact]
        public void TestChecked() {
            _wrapper.SetContextAttribute( UiConst.Checked, "a" );
            var result = new StringBuilder();
            result.Append( "<label nz-checkbox=\"\" [nzChecked]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选中状态变化事件
        /// </summary>
        [Fact]
        public void TestOnCheckedChange() {
            _wrapper.SetContextAttribute( UiConst.OnCheckedChange, "a" );
            var result = new StringBuilder();
            result.Append( "<label (nzCheckedChange)=\"a\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
