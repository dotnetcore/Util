using System.IO;
using System.Text.Encodings.Web;
using Util.Biz.Enums;
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
    /// 下拉列表测试
    /// </summary>
    public class SelectTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 下拉列表
        /// </summary>
        private readonly Select _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectTest( ITestOutputHelper output ) {
            _output = output;
            _component = new Select();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Select component ) {
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
            result.Append( "<mat-select-wrapper></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var result = new String();
            result.Append( "<mat-select-wrapper url=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Url("a") ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            var result = new String();
            result.Append( "<mat-select-wrapper [dataSource]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.DataSource( "a" ) ) );
        }

        /// <summary>
        /// 测试按组显示
        /// </summary>
        [Fact]
        public void TestGroup() {
            var result = new String();
            result.Append( "<mat-select-wrapper [isGroup]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Group() ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder_1() {
            var result = new String();
            result.Append( "<mat-select-wrapper placeholder=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Placeholder( "a" ) ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder_2() {
            var result = new String();
            result.Append( "<mat-select-wrapper floatPlaceholder=\"never\" placeholder=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Placeholder( "a",FloatPlaceholder.Never ) ) );
        }

        /// <summary>
        /// 测试启用重置项
        /// </summary>
        [Fact]
        public void TestEnableResetOption_1() {
            var result = new String();
            result.Append( "<mat-select-wrapper resetOptionText=\"a\" [enableResetOption]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.EnableResetOption( "a" ) ) );
        }

        /// <summary>
        /// 测试启用重置项
        /// </summary>
        [Fact]
        public void TestEnableResetOption_2() {
            var result = new String();
            result.Append( "<mat-select-wrapper [enableResetOption]=\"false\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.EnableResetOption( false ) ) );
        }

        /// <summary>
        /// 测试启用多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var result = new String();
            result.Append( "<mat-select-wrapper [multiple]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Multiple() ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var result = new String();
            result.Append( "<mat-select-wrapper [(model)]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Model( "a" ) ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var result = new String();
            result.Append( "<mat-select-wrapper requiredMessage=\"a\" [required]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Required("a") ) );
        }

        /// <summary>
        /// 测试显示模板
        /// </summary>
        [Fact]
        public void TestTemplate() {
            var result = new String();
            result.Append( "<mat-select-wrapper template=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Template( "a" ) ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var result = new String();
            result.Append( "<mat-select-wrapper (onChange)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnChange( "a" ) ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            var result = new String();
            result.Append( "<mat-select-wrapper [selectItems]=\"[{" );
            result.Append( "&quot;text&quot;:&quot;a&quot;,&quot;value&quot;:&quot;1&quot;" );
            result.Append( "}]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( "a","1" ) ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            var result = new String();
            result.Append( "<mat-select-wrapper [selectItems]=\"[{" );
            result.Append( "&quot;text&quot;:&quot;a&quot;,&quot;value&quot;:&quot;1&quot;" );
            result.Append( "}]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( new Item( "a", "1" ) ) ) );
        }

        /// <summary>
        /// 测试绑定bool
        /// </summary>
        [Fact]
        public void TestBool() {
            var result = new String();
            result.Append( "<mat-select-wrapper [selectItems]=\"[" );
            result.Append( "{&quot;text&quot;:&quot;&#x662F;&quot;,&quot;value&quot;:&quot;true&quot;}," );
            result.Append( "{&quot;text&quot;:&quot;&#x5426;&quot;,&quot;value&quot;:&quot;false&quot;}" );
            result.Append( "]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Bool() ) );
        }

        /// <summary>
        /// 测试绑定枚举
        /// </summary>
        [Fact]
        public void TestEnum() {
            var result = new String();
            result.Append( "<mat-select-wrapper [selectItems]=\"[" );
            result.Append( "{&quot;text&quot;:&quot;&#x5973;&#x58EB;&quot;,&quot;value&quot;:&quot;1&quot;,&quot;sortId&quot;:1}," );
            result.Append( "{&quot;text&quot;:&quot;&#x5148;&#x751F;&quot;,&quot;value&quot;:&quot;2&quot;,&quot;sortId&quot;:2}" );
            result.Append( "]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( (Select)_component.Enum<Gender>() ) );
        }
    }
}
