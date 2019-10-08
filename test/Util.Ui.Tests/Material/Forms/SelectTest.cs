using System.IO;
using System.Text.Encodings.Web;
using Util.Biz.Enums;
using Util.Ui.Configs;
using Util.Ui.Enums;
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
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-select-wrapper #a=\"\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var result = new String();
            result.Append( "<mat-select-wrapper name=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Name( "a" ) ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var result = new String();
            result.Append( "<mat-select-wrapper [name]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindName( "a" ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable() {
            var result = new String();
            result.Append( "<mat-select-wrapper [disabled]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable() ) );
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
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var result = new String();
            result.Append( "<mat-select-wrapper placeholder=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Placeholder( "a" ) ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var result = new String();
            result.Append( "<mat-select-wrapper [placeholder]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindPlaceholder( "a" ) ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder_Float() {
            var result = new String();
            result.Append( "<mat-select-wrapper floatPlaceholder=\"never\" placeholder=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Placeholder( "a", FloatType.Never ) ) );
        }

        /// <summary>
        /// 测试设置起始提示
        /// </summary>
        [Fact]
        public void TestHint_Start() {
            var result = new String();
            result.Append( "<mat-select-wrapper startHint=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Hint( "a" ) ) );
        }

        /// <summary>
        /// 测试设置结束提示
        /// </summary>
        [Fact]
        public void TestHint_End() {
            var result = new String();
            result.Append( "<mat-select-wrapper endHint=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Hint( "a",true ) ) );
        }

        /// <summary>
        /// 测试设置前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            var result = new String();
            result.Append( "<mat-select-wrapper prefixText=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Prefix( "a" ) ) );
        }

        /// <summary>
        /// 测试设置后缀文本
        /// </summary>
        [Fact]
        public void TestSuffix_Text() {
            var result = new String();
            result.Append( "<mat-select-wrapper suffixText=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( "a" ) ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标
        /// </summary>
        [Fact]
        public void TestSuffix_FontAwesomeIcon() {
            var result = new String();
            result.Append( "<mat-select-wrapper suffixFontAwesomeIcon=\"fa-apple\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( FontAwesomeIcon.Apple ) ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标
        /// </summary>
        [Fact]
        public void TestSuffix_MaterialIcon() {
            var result = new String();
            result.Append( "<mat-select-wrapper suffixMaterialIcon=\"android\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( MaterialIcon.Android ) ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标单击事件
        /// </summary>
        [Fact]
        public void TestSuffix_FontAwesomeIcon_Click() {
            var result = new String();
            result.Append( "<mat-select-wrapper (onSuffixIconClick)=\"a\" suffixFontAwesomeIcon=\"fa-apple\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( FontAwesomeIcon.Apple, "a" ) ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标单击事件
        /// </summary>
        [Fact]
        public void TestSuffix_MaterialIcon_Click() {
            var result = new String();
            result.Append( "<mat-select-wrapper (onSuffixIconClick)=\"a\" suffixMaterialIcon=\"android\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Suffix( MaterialIcon.Android, "a" ) ) );
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
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var result = new String();
            result.Append( "<mat-select-wrapper (onFocus)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnFocus( "a" ) ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var result = new String();
            result.Append( "<mat-select-wrapper (onBlur)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnBlur( "a" ) ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var result = new String();
            result.Append( "<mat-select-wrapper (onKeydown)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnKeydown( "a" ) ) );
        }

        /// <summary>
        /// 测试独立
        /// </summary>
        [Fact]
        public void TestStandalone() {
            var result = new String();
            result.Append( "<mat-select-wrapper [standalone]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Standalone() ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            var result = new String();
            result.Append( "<mat-select-wrapper [dataSource]=\"[{" );
            result.Append( "'text':'a','value':'1'" );
            result.Append( "}]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( "a","1" ) ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            var result = new String();
            result.Append( "<mat-select-wrapper [dataSource]=\"[{" );
            result.Append( "'text':'a','value':'1'" );
            result.Append( "}]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( new Item( "a", "1" ) ) ) );
        }

        /// <summary>
        /// 测试绑定bool
        /// </summary>
        [Fact]
        public void TestBool() {
            var result = new String();
            result.Append( "<mat-select-wrapper [dataSource]=\"[" );
            result.Append( "{'text':'是','value':true}," );
            result.Append( "{'text':'否','value':false}" );
            result.Append( "]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Bool() ) );
        }

        /// <summary>
        /// 测试绑定枚举
        /// </summary>
        [Fact]
        public void TestEnum() {
            var result = new String();
            result.Append( "<mat-select-wrapper [dataSource]=\"[" );
            result.Append( "{'text':'女','value':1,'sortId':1}," );
            result.Append( "{'text':'男','value':2,'sortId':2}" );
            result.Append( "]\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( (Select)_component.Enum<Gender>() ) );
        }
    }
}
