using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms {
    /// <summary>
    /// 复选框测试
    /// </summary>
    public class CheckBoxTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 复选框
        /// </summary>
        private readonly CheckBox _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CheckBoxTest( ITestOutputHelper output ) {
            _output = output;
            _component = new CheckBox();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( CheckBox component ) {
            component.WriteTo( new StringWriter(), HtmlEncoder.Default );
            var result = component.ToString();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<mat-checkbox></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-checkbox #a=\"\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var result = new String();
            result.Append( "<mat-checkbox name=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Name( "a" ) ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var result = new String();
            result.Append( "<mat-checkbox [name]=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindName( "a" ) ) );
        }

        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var result = new String();
            result.Append( "<mat-checkbox>a</mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( "a" ) ) );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            var result = new String();
            result.Append( "<mat-checkbox>{{a}}</mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindLabel( "a" ) ) );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestPosition() {
            var result = new String();
            result.Append( "<mat-checkbox labelPosition=\"before\">a</mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( "a", true ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable() {
            var result = new String();
            result.Append( "<mat-checkbox [disabled]=\"true\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable() ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var result = new String();
            result.Append( "<mat-checkbox color=\"primary\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Color( Color.Primary ) ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var result = new String();
            result.Append( "<mat-checkbox [(ngModel)]=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Model( "a" ) ) );
        }

        /// <summary>
        /// 测试设置不确定样式
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            var result = new String();
            result.Append( "<mat-checkbox [indeterminate]=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Indeterminate( "a" ) ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var result = new String();
            result.Append( "<mat-checkbox [required]=\"true\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Required() ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var result = new String();
            result.Append( "<mat-checkbox (change)=\"a\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnChange( "a" ) ) );
        }

        /// <summary>
        /// 测试独立
        /// </summary>
        [Fact]
        public void TestStandalone() {
            var result = new String();
            result.Append( "<mat-checkbox [ngModelOptions]=\"{standalone: true}\"></mat-checkbox>" );
            Assert.Equal( result.ToString(), GetResult( _component.Standalone() ) );
        }
    }
}
