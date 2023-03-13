using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 基础属性测试
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试原始标识
        /// </summary>
        [Fact]
        public void TestRawId() {
            _wrapper.SetContextAttribute( AngularConst.RawId, "a" );
            var result = new StringBuilder();
            result.Append( "<input id=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试引用变量
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<input #a=\"\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试名称
        /// </summary>
        [Fact]
        public void TestName() {
            _wrapper.SetContextAttribute( UiConst.Name, "a" );
            var result = new StringBuilder();
            result.Append( "<input name=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            _wrapper.SetContextAttribute( AngularConst.BindName, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [name]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试样式
        /// </summary>
        [Fact]
        public void TestStyle() {
            _wrapper.SetContextAttribute( UiConst.Style, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" style=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试样式类
        /// </summary>
        [Fact]
        public void TestClass() {
            _wrapper.SetContextAttribute( UiConst.Class, "a" );
            var result = new StringBuilder();
            result.Append( "<input class=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏
        /// </summary>
        [Fact]
        public void TestHidden() {
            _wrapper.SetContextAttribute( UiConst.Hidden, "true" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [hidden]=\"true\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加其它未配置的属性
        /// </summary>
        [Fact]
        public void TestOutputAttributes() {
            _wrapper.SetOutputAttribute( "a", "1" ).SetOutputAttribute( "b", "2" );
            var result = new StringBuilder();
            result.Append( "<input a=\"1\" b=\"2\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            _wrapper.SetContextAttribute( AngularConst.NgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [(ngModel)]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestBindNgModel() {
            _wrapper.SetContextAttribute( AngularConst.BindNgModel, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [ngModel]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试表单控件实例
        /// </summary>
        [Fact]
        public void TestFormControl() {
            _wrapper.SetContextAttribute( UiConst.FormControl, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [formControl]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表单控件名
        /// </summary>
        [Fact]
        public void TestFormControlName() {
            _wrapper.SetContextAttribute( UiConst.FormControlName, "a" );
            var result = new StringBuilder();
            result.Append( "<input formControlName=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表单控件名
        /// </summary>
        [Fact]
        public void TestBindFormControlName() {
            _wrapper.SetContextAttribute( AngularConst.BindFormControlName, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [formControlName]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<input (ngModelChange)=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

