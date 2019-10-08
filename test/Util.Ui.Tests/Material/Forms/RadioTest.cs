using System.IO;
using System.Text.Encodings.Web;
using Util.Biz.Enums;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Extensions;
using Util.Ui.Material.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms {
    /// <summary>
    /// 单选框测试
    /// </summary>
    public class RadioTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 单选框
        /// </summary>
        private readonly Radio _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RadioTest( ITestOutputHelper output ) {
            _output = output;
            _component = new Radio();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( Radio component ) {
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
            result.Append( "<mat-radio-wrapper></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var result = new String();
            result.Append( "<mat-radio-wrapper #a=\"\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Id( "a" ) ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var result = new String();
            result.Append( "<mat-radio-wrapper name=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Name( "a" ) ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [name]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindName( "a" ) ) );
        }

        /// <summary>
        /// 测试是否垂直布局
        /// </summary>
        [Fact]
        public void TestVertical() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [vertical]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Vertical() ) );
        }

        /// <summary>
        /// 测试是否显示标签
        /// </summary>
        [Fact]
        public void TestShowLabel() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [showLabel]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( true ) ) );
        }

        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var result = new String();
            result.Append( "<mat-radio-wrapper label=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( "a" ) ) );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [label]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.BindLabel( "a" ) ) );
        }

        /// <summary>
        /// 测试标签位置
        /// </summary>
        [Fact]
        public void TestPosition() {
            var result = new String();
            result.Append( "<mat-radio-wrapper label=\"a\" labelPosition=\"before\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Label( "a", true ) ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [disabled]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Disable() ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var result = new String();
            result.Append( "<mat-radio-wrapper url=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Url( "a" ) ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [dataSource]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.DataSource( "a" ) ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [(model)]=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Model( "a" ) ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [required]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Required() ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var result = new String();
            result.Append( "<mat-radio-wrapper (onChange)=\"a\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.OnChange( "a" ) ) );
        }

        /// <summary>
        /// 测试独立
        /// </summary>
        [Fact]
        public void TestStandalone() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [standalone]=\"true\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Standalone() ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [dataSource]=\"[{" );
            result.Append( "'text':'a','value':'1'" );
            result.Append( "}]\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( "a", "1" ) ) );
        }

        /// <summary>
        /// 测试添加项
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [dataSource]=\"[{" );
            result.Append( "'text':'a','value':'1'" );
            result.Append( "}]\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Add( new Item( "a", "1" ) ) ) );
        }

        /// <summary>
        /// 测试绑定bool
        /// </summary>
        [Fact]
        public void TestBool() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [dataSource]=\"[" );
            result.Append( "{'text':'是','value':true}," );
            result.Append( "{'text':'否','value':false}" );
            result.Append( "]\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( _component.Bool() ) );
        }

        /// <summary>
        /// 测试绑定枚举
        /// </summary>
        [Fact]
        public void TestEnum() {
            var result = new String();
            result.Append( "<mat-radio-wrapper [dataSource]=\"[" );
            result.Append( "{'text':'女','value':1,'sortId':1}," );
            result.Append( "{'text':'男','value':2,'sortId':2}" );
            result.Append( "]\"></mat-radio-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( (Radio)_component.Enum<Gender>() ) );
        }
    }
}